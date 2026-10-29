using System;

namespace lab2
{
    /// <summary>
    /// Клас Service відповідає за взаємодію з користувачем: 
    /// виведення даних у консоль та керування головним меню програми.
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// Виводить у консоль заголовок та всі елементи одновимірного масиву.
        /// </summary>
        /// <param name="message">Текстове повідомлення (заголовок), що описує масив.</param>
        /// <param name="array">Масив цілих чисел (вектор), який потрібно надрукувати.</param>
        public void PrintVector(string message, int[] array)
        {
            Console.WriteLine("\n" + message);
            for (int i = 0; i < array.Length; i++) // Проходимо циклом по всій довжині масиву 
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Відображає результати пошуку: перелік знайдених чисел або повідомлення про їх відсутність.
        /// </summary>
        /// <param name="results">Масив чисел, знайдених у заданому діапазоні.</param>
        public void PrintSearchResults(int[] results)
        {
            Console.WriteLine("\nРезультати бінарного пошуку (знайдені значення в діапазоні):");
            if (results.Length == 0) // Перевіряємо, чи масив результатів порожній
            {
                Console.WriteLine("Нічого не знайдено.");
            }
            else
            {
                for (int i = 0; i < results.Length; i++) // Якщо результати є, перебираємо їх
                {
                    Console.Write(results[i] + " "); // Виводимо кожне знайдене число
                }
                Console.WriteLine("\nКількість знайдених елементів: " + results.Length); // Виводимо загальну кількість
            }
        }

        /// <summary>
        /// Виводить двовимірний масив (матрицю) у вигляді форматованої таблиці.
        /// </summary>
        /// <param name="matrix">Двовимірний масив цілих чисел для відображення.</param>
        public void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("\nМатриця вакцинації (Рядки - Країни, Стовпці - Місяці):");
            int rows = matrix.GetLength(0); // Отримуємо кількість рядків (перший вимір)
            int cols = matrix.GetLength(1); // Отримуємо кількість стовпців (другий вимір)

            for (int i = 0; i < rows; i++) // Цикл для переходу по країнах (рядках)
            {
                Console.Write("Країна " + i + ": ");
                for (int j = 0; j < cols; j++) // Цикл для переходу по місяцях (стовпцях) всередині країни
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Проводить аналіз об'єкта Matrix та виводить статистику: загальну суму, мінімуми та максимуми.
        /// </summary>
        /// <param name="matrix">Екземпляр класу Matrix, що містить дані для аналізу.</param>
        public void PrintMatrixResults(Matrix matrix)
        {
            Console.WriteLine("\n--- Результати аналізу вакцинації ---");
            Console.WriteLine("Загальна кількість вакцинованих у світі: " + matrix.GetTotalVaccinated()); // Виклик сумування всіх елементів
            Console.WriteLine("Країна з найменшою кількістю вакцинованих (індекс): " + matrix.GetCountryWithMinVaccinated()); // Виклик пошуку мін. рядка
            Console.WriteLine("Місяць з найбільшою кількістю вакцинованих (індекс): " + matrix.GetMonthWithMaxVaccinated()); // Виклик пошуку макс. стовпця
        }

        /// <summary>
        /// Керує логікою вибору пунктів меню та організовує взаємодію між користувачем та функціоналом класів Vector і Matrix.
        /// </summary>
        /// <param name="vector">Об'єкт для роботи з одновимірним масивом.</param>
        /// <param name="matrix">Об'єкт для роботи з двовимірним масивом.</param>
        /// <param name="rnd">Спільний об'єкт Random для генерації випадкових чисел.</param>
        /// <summary>
        /// Керує логікою вибору пунктів меню за допомогою циклу do-while.
        /// </summary>
        /// <summary>
        /// Керує логікою вибору пунктів меню за допомогою циклу do-while.
        /// </summary>
        public void RunMenu(Vector vector, Matrix matrix, Random rnd)
        {
            int choice; 

            do
            {
                Console.WriteLine("\n============================================================================");
                Console.WriteLine("                            ЛАБОРАТОРНА РОБОТА 2");
                Console.WriteLine("Студент: Стукало Тимофій | Група: ІПЗ-11");
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("УМОВА ЗАВДАННЯ:");
                Console.WriteLine(" ЗАВДАННЯ 1 (Вектор):");
                Console.WriteLine("  - Згенерувати одновимірний масив випадкових чисел [-100, 100].");
                Console.WriteLine("  - Відсортувати додатні елементи масиву (метод бульбашки).");
                Console.WriteLine("  - Перевпорядкувати масив: спочатку від'ємні, потім додатні.");
                Console.WriteLine("  - Знайти всі числа із заданого діапазону [min, max] за допомогою");
                Console.WriteLine("    рекурсивного бінарного пошуку.");
                Console.WriteLine();
                Console.WriteLine(" ЗАВДАННЯ 2 (Матриця):");
                Console.WriteLine("  - Згенерувати матрицю (рядки - країни, стовпці - місяці),");
                Console.WriteLine("    яка відображає кількість вакцинованих.");
                Console.WriteLine("  - Знайти загальну кількість вакцинованих у світі.");
                Console.WriteLine("  - Визначити країну (індекс рядка) з найменшою кількістю вакцинованих.");
                Console.WriteLine("  - Визначити місяць (індекс стовпця) з найбільшою кількістю вакцинованих.");
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("1. Запустити Завдання 1 (Робота з Вектором)");
                Console.WriteLine("2. Запустити Завдання 2 (Робота з Матрицею)");
                Console.WriteLine("0. Вихід з програми");
                Console.WriteLine("============================================================================");

                Console.Write("Оберіть пункт: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть розмір вектора: ");
                        int vSize = int.Parse(Console.ReadLine());
                        vector.GenerateElements(vSize, rnd);
                        PrintVector("Згенерований вектор:", vector.Elements);

                        vector.BubbleSortPositives();
                        PrintVector("Після сортування додатних:", vector.Elements);

                        vector.ReorderElements();
                        PrintVector("Після переставлення (-, +, 0):", vector.Elements);

                        Console.Write("Початок діапазону: ");
                        int minR = int.Parse(Console.ReadLine());
                        Console.Write("Кінець діапазону: ");
                        int maxR = int.Parse(Console.ReadLine());
                        PrintSearchResults(vector.GetElementsInRange(minR, maxR));
                        break;

                    case 2:
                        Console.Write("Кількість країн: ");
                        int rows = int.Parse(Console.ReadLine());
                        Console.Write("Кількість місяців: ");
                        int cols = int.Parse(Console.ReadLine());

                        matrix.GenerateMatrix(rows, cols, 0, 100, rnd);
                        PrintMatrix(matrix.Data);
                        PrintMatrixResults(matrix);
                        break;

                    case 0:
                        Console.WriteLine("Вихід з програми...");
                        break;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }

            } while (choice != 0); // Умова: цикл працює, поки введений вибір не дорівнює 0
        }
    }
}