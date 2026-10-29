using System;
using System.Text;

namespace Console_Lab1
{
    /// <summary>
    /// Клас, що містить логіку та взаємодію з користувачем.
    /// </summary>
    public class LabLogic
    {
        // Приватні константи, інкапсуляція 
        private const float A = 3.5f;
        private const float B = 3.0f;
        private const float C = 10.0f;
        private const float D = 8.3f;

        /// <summary>
        /// Запитує x (перевіряє введення), обчислює та повертає значення полінома.
        /// </summary>
        public float CalculatePolynomial()
        {
            float x;
            Console.WriteLine("Введіть значення x:");

            while (!float.TryParse(Console.ReadLine(), out x))// Цикл буде крутитися, поки користувач не введе правильне число
            {
                Console.WriteLine("Помилка! Введіть число, а не букви:");
            }

            float result = A * (float)Math.Pow(x, 4) + B * (float)Math.Pow(x, 3) + C * (float)Math.Pow(x, 2) + D;
            return result;
        }

        /// <summary>
        /// Запитує a і b, обчислює та повертає значення виразу.
        /// </summary>
        public float CalculateEquation()
        {
            float a, b;

            Console.WriteLine("Введіть значення a:");
            while (!float.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Помилка! Введіть число:");
            }

            Console.WriteLine("Введіть значення b:");
            while (!float.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Помилка! Введіть число:");
            }

            float result = 1 + (float)Math.Abs((a + b) / (a - b)) + (float)Math.Sqrt((a - 1) / (b - 1));
            return result;
        }

        /// <summary>
        /// Запитує x, обчислює та виводить функцію f(x).
        /// </summary>
        public void CalculateFunction()
        {
            float x;
            Console.WriteLine("Введіть значення x:");

            while (!float.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Помилка! Введіть число:");
            }

            float result;

            if (x == 0)
            {
                result = 1;
                Console.WriteLine("Результат f(x): " + result);
            }
            else if (x > 0 && x < Math.PI)
            {
                result = (float)Math.Sin(x);
                Console.WriteLine("Результат f(x): " + result);
            }
            else if (x >= Math.PI && x <= 2 * Math.PI)
            {
                result = (float)Math.Cos(x);
                Console.WriteLine("Результат f(x): " + result);
            }
            else
            {
                Console.WriteLine("Значення поза діапазоном [0, 2Pi]");
            }
        }

        /// <summary>
        /// Запитує годину і повертає назву частини доби.
        /// </summary>
        public string GetTimeOfDay()
        {
            int time;
            string result = "";

            Console.WriteLine("Введіть годину (ціле число):");
            while (!int.TryParse(Console.ReadLine(), out time))
            {
                Console.WriteLine("Помилка! Введіть ціле число:");
            }

            if (time >= 0 && time < 6)
            {
                result = "Ніч";
            }
            else if (time >= 6 && time < 12)
            {
                result = "Ранок";
            }
            else if (time >= 12 && time < 18)
            {
                result = "День";
            }
            else if (time >= 18 && time <= 24)
            {
                result = "Вечір";
            }
            else
            {
                result = "Некоректна година";
            }

            return result;
        }

        /// <summary>
        /// Запитує оцінки та виводить статистику.
        /// </summary>
        public void CalculateGrades()
        {
            int sum = 0;
            int best = 0;
            int worst = 101;
            int current;

            Console.WriteLine("Введіть оцінки з 10 дисциплін:");

            for (int i = 1; i <= 10; i++) 
            {
                Console.Write("Оцінка " + i + ": ");

                if (!int.TryParse(Console.ReadLine(), out current))// Якщо ввели не число, просимо ввести знову для тієї ж оцінки (i--)
                {
                    Console.WriteLine("Це не число. Спробуйте ще раз.");
                    i--;
                    continue;
                }

                if (current < 1 || current > 100)
                {
                    Console.WriteLine("Помилка! Оцінка має бути в діапазоні від 1 до 100.");
                    i--;      // Повертаємося назад, щоб переввести цю ж оцінку
                    continue; // Пропускаємо решту коду
                }

                sum += current;

                if (current > best)
                {
                    best = current;
                }

                if (current < worst)
                {
                    worst = current;
                }
            }

            Console.WriteLine("\n--- Результати ---");
            Console.WriteLine("Загальна сума балів: " + sum);
            Console.WriteLine("Найкраща оцінка: " + best);
            Console.WriteLine("Найгірша оцінка: " + worst);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Console.InputEncoding = Encoding.UTF8;

            LabLogic logic = new LabLogic();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Студент Стукало Тимофій, гр. ІПЗ-11, Варіант 4");
                Console.WriteLine("======== МЕНЮ ========");
                Console.WriteLine("1. Обчислення поліному");
                Console.WriteLine("2. Обчислення виразу");
                Console.WriteLine("3. Функція f(x)");
                Console.WriteLine("4. Частини доби");
                Console.WriteLine("5. Статистика оцінок");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Результат: " + logic.CalculatePolynomial());
                            break;

                        case 2:
                            Console.WriteLine("Результат: " + logic.CalculateEquation());
                            break;

                        case 3:
                            logic.CalculateFunction();
                            break;

                        case 4:
                            Console.WriteLine("Зараз: " + logic.GetTimeOfDay());
                            break;

                        case 5:
                            logic.CalculateGrades();
                            break;

                        case 0:
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Невірний пункт меню.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Будь ласка, введіть число.");
                }

               if (isRunning)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                }
            }
        }
    }
}