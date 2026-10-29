using System;

namespace lab2
{
    /// <summary>
    /// Клас Matrix для обробки двовимірних масивів даних про вакцинацію.
    /// Містить методи для генерації даних та пошуку статистичних показників.
    /// </summary>
    internal class Matrix
    {
        private int rows; // Кількість країн (рядки матриці)
        private int cols; // Кількість місяців (стовпці матриці)
        private int[,] data; // Двовимірний масив для зберігання кількості вакцинованих

        /// <summary>
        /// Властивість для доступу до даних матриці.
        /// </summary>
        public int[,] Data
        {
            get
            {
                return data;
            }
        }

        /// <summary>
        /// Генерує матрицю випадковими числами у вказаному діапазоні.
        /// </summary>
        /// <param name="rowCount">Кількість країн.</param>
        /// <param name="colCount">Кількість місяців.</param>
        /// <param name="min">Мінімальне значення вакцинованих.</param>
        /// <param name="max">Максимальне значення вакцинованих.</param>
        /// <param name="random">Об'єкт Random для генерації.</param>
        public void GenerateMatrix(int rowCount, int colCount, int min, int max, Random random)
        {
            this.rows = rowCount; // Зберігаємо кількість країн у поле класу
            this.cols = colCount; // Зберігаємо кількість місяців у поле класу
            this.data = new int[rows, cols]; // Виділяємо пам'ять під двовимірний масив

            for (int i = 0; i < rows; i++) // Цикл по рядках (країнах)
            {
                for (int j = 0; j < cols; j++) // Цикл по стовпцях (місяцях)
                {
                    data[i, j] = random.Next(min, max + 1); // Заповнюємо клітинку випадковим числом
                }
            }
        }

        /// <summary>
        /// Обчислює загальну суму всіх елементів матриці.
        /// </summary>
        /// <returns>Загальна кількість вакцинованих за весь період.</returns>
        public long GetTotalVaccinated()
        {
            int total = 0; // Використовуємо long, щоб уникнути переповнення суми
            for (int i = 0; i < rows; i++) // Перебираємо всі країни
            {
                for (int j = 0; j < cols; j++) // Перебираємо всі місяці для кожної країни
                {
                    total += data[i, j]; // Додаємо значення поточної клітинки до загальної суми
                }
            }
            return total; // Повертаємо накопичений результат
        }

        /// <summary>
        /// Знаходить індекс країни з мінімальною сумарною кількістю вакцинованих.
        /// </summary>
        /// <returns>Індекс (номер) рядка з мінімальною сумою.</returns>
        public int GetCountryWithMinVaccinated()
        {
            int minCountryIndex = 0; 
            int minSum = int.MaxValue; 

            for (int i = 0; i < rows; i++) // Цикл по кожній країні (рядку)
            {
                int currentCountrySum = 0;
                for (int j = 0; j < cols; j++) // Рахуємо вакцинованих за всі місяці цієї країни
                {
                    currentCountrySum += data[i, j]; // Додаємо кожен місяць до суми країни
                }

                if (currentCountrySum < minSum) // Якщо сума поточної країни менша за знайдену раніше
                {
                    minSum = currentCountrySum; 
                    minCountryIndex = i; 
                }
            }
            return minCountryIndex; 
        }

        /// <summary>
        /// Знаходить індекс місяця з найбільшою сумарною кількістю вакцинованих по всіх країнах.
        /// </summary>
        /// <returns>Індекс (номер) стовпця з максимальною сумою.</returns>
        public int GetMonthWithMaxVaccinated()
        {
            int maxMonthIndex = 0; 
            long maxSum = -1;

            for (int j = 0; j < cols; j++) // Зовнішній цикл по місяцях (стовпцях)
            {
                long currentMonthSum = 0;
                for (int i = 0; i < rows; i++) // Внутрішній цикл по країнах (рядках)
                {
                    currentMonthSum += data[i, j]; // Додаємо дані кожної країни за конкретний місяць
                }

                if (currentMonthSum > maxSum) // Якщо сума поточного місяця більша за максимальну
                {
                    maxSum = currentMonthSum; 
                    maxMonthIndex = j; // Запам'ятовуємо індекс цього місяця
                }
            }
            return maxMonthIndex; 
        }
    }
}