using System;

namespace Lab4.V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Service.ClearLog();

            Service.SaveAndPrint("=== СЦЕНАРІЙ ДЕМОНСТРАЦІЇ УСІХ МЕТОДІВ (Версія 1) ===\n");

            // 1. ДЕМОНСТРАЦІЯ КЛАСУ University
            Service.SaveAndPrint("[ЕТАП 1]: Робота з Університетом");
            University knu = new University("КНУ ім. Шевченка", 25000, 14, 600, 30);

            knu.AverageZno = 188.5;
            knu.CalculateRating();
            knu.CalculateBudget();

            Service.SaveAndPrint(knu.GetInfo());

            knu.ChangeName("Київський національний університет імені Тараса Шевченка");
            Service.SaveAndPrint("-> Перевірка ChangeName: " + knu.Name);

            knu.AddFaculty();
            Service.SaveAndPrint("-> Перевірка AddFaculty. Факультетів: " + knu.UnitsCount);
            knu.RemoveFaculty();
            Service.SaveAndPrint("-> Перевірка RemoveFaculty. Факультетів: " + knu.UnitsCount + "\n");

            // 2. ДЕМОНСТРАЦІЯ КЛАСУ Faculty
            Service.SaveAndPrint("[ЕТАП 2]: Робота з Факультетом");
            Faculty fit = new Faculty("ФІТ", 1500, knu.Name);
            Service.SaveAndPrint(fit.GetInfo());

            fit.AddSpecialty("122 Комп'ютерні науки (Англомовна програма)");
            Service.SaveAndPrint("\n-> Перевірка AddSpecialty. Напрямків: " + fit.UnitsCount);

            fit.RemoveSpecialty("Мережеві та інтернет технології");
            Service.SaveAndPrint("-> Перевірка RemoveSpecialty. Напрямків: " + fit.UnitsCount);

            fit.IncreaseStudentCount(50);
            Service.SaveAndPrint("-> Перевірка IncreaseStudentCount. Студентів: " + fit.StudentCount);

            fit.DecreaseStudentCount(120);
            Service.SaveAndPrint("-> Перевірка DecreaseStudentCount. Студентів: " + fit.StudentCount + "\n");

            Service.SaveAndPrint("=== ВСІ МЕТОДИ УСПІШНО ПРОТЕСТОВАНО ===");
            Console.WriteLine("Натисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}