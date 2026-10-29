using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Service service = new Service("В2-Звіт", "log_v2.txt");
        service.ClearFile();

        service.SaveAndPrint("--- СТАРТ ВЕРСІЇ 2 ---");

        // 1. Створюємо базовий факультет
        Faculty fit = new Faculty("ФІТ", "Декан", 1200, "КНУ");
        fit.AddSpecialty("121 - ІПЗ");

        // 2. Створюємо СТАРТАП-ІНКУБАТОР (вкладений клас)
        // Назва інкубатора та обсяг інвестицій (наприклад, 100 000 грн)
        Faculty.StartupIncubator incubator = new Faculty.StartupIncubator("IT Hub FIT", 100000.0);

        incubator.AddStartup("ШІ для медицини");
        incubator.AddStartup("Розумний дім");
        incubator.AssignMentor(3);

        service.SaveAndPrint("Інкубатор: " + incubator.IncubatorName);
        service.SaveAndPrint("Кількість активних проєктів: " + incubator.ActiveProjectCount.ToString());
        service.SaveAndPrint("Загальні інвестиції: " + incubator.InvestmentAmount.ToString("N0") + " грн");

        // 3. Демонстрація алгоритму матриці 5х10
        int bestProjectNumber = incubator.SelectBestStartup();
        service.SaveAndPrint("За оцінками експертів найкращим став проєкт №" + bestProjectNumber.ToString() + " (найменший бал).");

        // 4. Демонстрація рейтингу студентів (доля участі * інвестиції)
        int studentsInvolved = 5; // Для прикладу беремо 5 студентів
        double[] ratings = incubator.CalculatePerformanceRating(studentsInvolved);

        service.SaveAndPrint("--- Рейтинг студентів (Топ-3 найрезультативніших) ---");
        for (int i = 0; i < 3; i++) // Виводимо перших трьох (масив вже відсортований за спаданням)
        {
            service.SaveAndPrint("Місце " + (i + 1) + ": " + ratings[i].ToString("N2") + " од. результативності");
        }

        Console.WriteLine("\nРоботу Версії 2 завершено. Натисніть Enter.");
        service.ReadFromConsole();
    }
}