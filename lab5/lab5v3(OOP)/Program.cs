//версія цього коду написана за допомогою ШІ асистента
using System;

namespace Lab5.V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Service.ClearLog();

            Service.SaveAndPrint("=== ЛАБОРАТОРНА РОБОТА №5 (ВЕРСІЯ 3) ===\n");

            // --- ТЕСТ 1: Клас SetOfUniversity та індексатори ---
            Service.SaveAndPrint("[ЕТАП 1]: Робота з SetOfUniversity (Індексатори)");
            SetOfUniversity uniSet = new SetOfUniversity();

            University knu = new University("КНУ", 25000, 14, 600, 30);
            knu.CalculateRating(); knu.CalculateBudget();

            University kpi = new University("КПІ", 30000, 18, 500, 25);
            kpi.CalculateRating(); kpi.CalculateBudget();

            uniSet.Add(knu);
            uniSet.Add(kpi);

            Service.SaveAndPrint($"Університет за індексом 0: {uniSet[0].Name}");
            Service.SaveAndPrint($"Університет за індексом 1: {uniSet[1].Name}\n");

            // --- ТЕСТ 2: Перевантаження операторів University ---
            Service.SaveAndPrint("[ЕТАП 2]: Статичний поліморфізм операторів (Університет)");
            knu = knu + 2; // Бінарний + (Додаємо факультети)
            Service.SaveAndPrint($"Після knu + 2 факультетів: {knu.UnitsCount}");

            knu = knu + (short)5; // Бінарний + (Додаємо міжнародні проєкти)
            Service.SaveAndPrint("Після додавання 5 міжн. проєктів. " + knu.GetInfo());

            knu++; // Унарний ++ (Збільшуємо бюджет на 100 000)
            Service.SaveAndPrint($"Після knu++ (бюджет збільшено). " + knu.GetInfo());

            bool isKnuBetter = knu > kpi;
            Service.SaveAndPrint($"Порівняння рейтингів (knu > kpi): {isKnuBetter}\n");


            // --- ТЕСТ 3: Перевантаження операторів Faculty ---
            Service.SaveAndPrint("[ЕТАП 3]: Статичний поліморфізм операторів (Факультет)");
            Faculty fit = new Faculty("ФІТ", 1500, "КНУ", 5);
            fit = fit - 1; // Бінарний - (Зменшення кафедр)
            Service.SaveAndPrint($"Після fit - 1 (кафедр стало): {fit.DepartmentsCount}");

            fit++; // Унарний ++ (Збільшення спеціальностей)
            Service.SaveAndPrint($"Після fit++ (спеціальностей стало): {fit.UnitsCount}\n");


            // --- ТЕСТ 4: Інкубатор (Конструктор копії та оператори) ---
            Service.SaveAndPrint("[ЕТАП 4]: Інкубатор та Конструктор Копії");
            StartupIncubator hub = new StartupIncubator("IT-Innovation Hub");
            hub.RegisterProject("AI Assistant", 500000);
            hub.InvolvedStudents = 10;

            // Копіювання
            StartupIncubator clonedHub = new StartupIncubator(hub);

            Service.SaveAndPrint("Оригінал: " + hub.GetIncubatorStats());
            Service.SaveAndPrint("Копія: " + clonedHub.GetIncubatorStats());

            // Оператори
            hub = hub + 250000m; // Збільшення інвестицій
            hub++; // Збільшення залучених студентів
            Service.SaveAndPrint("Оригінал після hub + 250000 та hub++: " + hub.GetIncubatorStats());

            bool areEqual = (hub == clonedHub);
            Service.SaveAndPrint($"Порівняння кількості проєктів (hub == clonedHub): {areEqual}");

            Service.SaveAndPrint("\n=== ПРОГРАМУ ЗАВЕРШЕНО ===");
            Console.ReadLine();
        }
    }
}