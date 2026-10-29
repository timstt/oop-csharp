using System;

namespace Lab5.V1
{
    public class University : AcademicInstitution
    {
        private int _scientificPapers;
        private int _internationalProjects;
        private double _rating;
        private decimal _annualBudget;
        private double _averageZno;

        public StartupIncubator Incubator { get; set; }

        public University(string name, int students, int faculties, int papers, int projects)
            : base(name, students, faculties)
        {
            _scientificPapers = papers;
            _internationalProjects = projects;
        }

        public double AverageZno { get => _averageZno; set => _averageZno = value; }
        public double Rating => _rating;

        public void CalculateRating() => _rating = (_scientificPapers * 0.5) + (_internationalProjects * 10);
        public void CalculateBudget() => _annualBudget = (decimal)(_rating * 15000);

        public override string GetInfo()
        {
            string info = $"Університет: {_name}, Факультетів: {UnitsCount}, Проєктів: {_internationalProjects}, " +
                          $"Рейтинг: {_rating:F1}, Бюджет: {_annualBudget:N0} грн.";
            if (Incubator != null) info += $"\n   [Має інкубатор: {Incubator.Name}]";
            return info;
        }

        // --- ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ (Статичний поліморфізм) ---

        // 1. Бінарні: Збільшити/зменшити кількість факультетів (int)
        public static University operator +(University u, int faculties) { u.UnitsCount += faculties; return u; }
        public static University operator -(University u, int faculties) { u.UnitsCount -= faculties; return u; }

        // 2. Бінарні: Додати/видалити кількість міжнародних проєктів (використовуємо short для уникнення конфлікту типів)
        public static University operator +(University u, short projects) { u._internationalProjects += projects; return u; }
        public static University operator -(University u, short projects) { u._internationalProjects -= projects; return u; }

        // 3. Бінарні: Порівняння за рейтингом Osvita.ua
        public static bool operator >(University u1, University u2) => u1.Rating > u2.Rating;
        public static bool operator <(University u1, University u2) => u1.Rating < u2.Rating;

        // 4. Унарні: Збільшити/зменшити річний бюджет (наприклад, кроком у 100 000)
        public static University operator ++(University u) { u._annualBudget += 100000; return u; }
        public static University operator --(University u) { u._annualBudget -= 100000; return u; }
    }
}