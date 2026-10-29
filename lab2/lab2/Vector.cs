using System;

namespace lab2
{
    /// <summary>
    /// Клас Vector для роботи з одновимірним масивом цілих чисел.
    /// Реалізує методи сортування, перевпорядкування та бінарного пошуку.
    /// </summary>
    internal class Vector
    {
        private int count; // Кількість елементів у векторі
        private int[] elements; // Одновимірний масив елементів

        /// <summary>
        /// Властивість для доступу до елементів вектора (тільки для читання).
        /// </summary>
        public int[] Elements
        {
            get
            {
                return elements;
            }
        }

        /// <summary>
        /// Генерує масив випадкових чисел у діапазоні від -100 до 100.
        /// </summary>
        /// <param name="size">Розмір масиву.</param>
        /// <param name="random">Об'єкт Random для генерації.</param>
        public void GenerateElements(int size, Random random)
        {
            count = size; // Зберігаємо розмір у поле класу
            elements = new int[size]; // Виділяємо пам'ять під масив

            for (int i = 0; i < count; i++) // Цикл для заповнення кожного елемента
            {
                elements[i] = random.Next(-50, 101);
            }
        }

        /// <summary>
        /// Сортує методом бульбашки тільки ДОДАТНІ елементи масиву, залишаючи інші на місцях.
        /// </summary>
        public void BubbleSortPositives()
        {
            for (int i = 0; i < count; i++) // Зовнішній цикл по всьому масиву
            {
                if (elements[i] <= 0) // Якщо поточний елемент не додатний (0 або від'ємний) // порушення структурності, 
                    continue; // Пропускаємо його і йдемо до наступного ітератора i, 

                for (int j = i + 1; j < count; j++) // Внутрішній цикл для порівняння з наступними
                {
                    if (elements[j] > 0 && elements[i] > elements[j])// Якщо наступний елемент теж додатний І він менший за поточний
                    {
                        int temp = elements[i]; 
                        elements[i] = elements[j]; 
                        elements[j] = temp; 
                    }
                }
            }
        }

        /// <summary>
        /// Перевпорядковує масив: спочатку всі від'ємні, потім усі додатні.
        /// Нулі в цій логіці ігноруються або відкидаються.
        /// </summary>
        public void ReorderElements()
        {
            int[] newArray = new int[count]; // Створюємо новий тимчасовий масив такого ж розміру
            int k = 0; // Індекс (вказівник) для заповнення нового масиву

            // Перший прохід: записуємо лише від'ємні числа
            for (int i = 0; i < count; i++)
                if (elements[i] < 0) newArray[k++] = elements[i]; // Якщо < 0, додаємо і зсуваємо вказівник k

            // Другий прохід: додаємо лише додатні числа після від'ємних
            for (int i = 0; i < count; i++)
                if (elements[i] > 0) newArray[k++] = elements[i]; // Якщо > 0, додаємо і зсуваємо k

            elements = newArray; 
        }

        /// <summary>
        /// Рекурсивний алгоритм бінарного пошуку в посортованому масиві.
        /// </summary>
        /// <param name="arr">Масив, у якому шукаємо.</param>
        /// <param name="left">Ліва межа пошуку.</param>
        /// <param name="right">Права межа пошуку.</param>
        /// <param name="target">Число, яке потрібно знайти.</param>
        /// <returns>True, якщо число знайдено, інакше False.</returns>
        private bool BinarySearch(int[] arr, int left, int right, int target)
        {
            if (left > right) // Базовий випадок рекурсії: якщо межі перетнулися
                return false;

            int mid = (left + right) / 2; // Знаходимо середину поточного діапазону

            if (arr[mid] == target) // Якщо число в центрі — це те, що ми шукаємо
                return true;

            if (arr[mid] > target)
                return BinarySearch(arr, left, mid - 1, target); 
            else // Якщо центральне число менше за ціль
                return BinarySearch(arr, mid + 1, right, target); 
        }

        /// <summary>
        /// Шукає елементи з діапазону [min, max], які присутні в масиві, використовуючи бінарний пошук.
        /// </summary>
        /// <param name="min">Нижня межа діапазону пошуку.</param>
        /// <param name="max">Верхня межа діапазону пошуку.</param>
        /// <returns>Масив унікальних чисел, знайдених у векторі.</returns>
        public int[] GetElementsInRange(int min, int max) //єдиної відповідальності 
        {
            int[] sortedCopy = new int[count]; // Створюємо копію масиву для сортування
            for (int i = 0; i < count; i++) 
                sortedCopy[i] = elements[i]; // Копіюємо елементи

            // Сортування копії (бульбашкою) для коректної роботи бінарного пошуку
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (sortedCopy[j] > sortedCopy[j + 1])
                    {
                        int temp = sortedCopy[j];
                        sortedCopy[j] = sortedCopy[j + 1];
                        sortedCopy[j + 1] = temp;
                    }
                }
            }

            int foundCount = 0;
            for (int i = min; i <= max; i++) // Перевіряємо кожне ціле число з діапазону //дублювання коду 
            {
                if (BinarySearch(sortedCopy, 0, count - 1, i)) // Якщо число i є в масиві
                    foundCount++; // Збільшуємо лічильник знайдених
            }

            // Заповнюємо фінальний масив результатів
            int[] result = new int[foundCount]; // Створюємо масив точно під кількість знайдених
            int index = 0; // Індекс для вставки в масив результатів
            for (int i = min; i <= max; i++) //дублювання коду 
            {
                if (BinarySearch(sortedCopy, 0, count - 1, i))
                    result[index++] = i; // Додаємо число в результат і збільшуємо індекс
            }

            return result; 
        }
    }
}