using System;
using System.Collections.Generic;

namespace Lab5.V1
{
    public class StartupIncubator
    {
        public string Name { get; set; }


        public int InvolvedStudents { get; set; }

        private List<string> _projects;
        private decimal _totalInvestments;

        public int ProjectsCount => _projects.Count;

        // Основний конструктор
        public StartupIncubator(string name)
        {
            Name = name;
            _projects = new List<string>();
            _totalInvestments = 0;
            InvolvedStudents = 0;
        }

        // КОНСТРУКТОР КОПІЇ (Завдання 7)
        public StartupIncubator(StartupIncubator other)
        {
            Name = other.Name + " (Копія)";
            InvolvedStudents = other.InvolvedStudents;
            // Створюємо порожній список та обнуляємо інвестиції згідно з умовою
            _projects = new List<string>();
            _totalInvestments = 0;
        }

        public void RegisterProject(string projectName, decimal investment)
        {
            _projects.Add(projectName);
            _totalInvestments += investment;
        }

        public string GetIncubatorStats()
        {
            return $"Інкубатор '{Name}': Проєктів: {ProjectsCount}, Інвестиції: {_totalInvestments:N0} грн, Студентів: {InvolvedStudents}";
        }

        // --- ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ---

        // 1. Бінарний (+): Обсяг інвестицій (decimal)
        public static StartupIncubator operator +(StartupIncubator s, decimal amount)
        {
            s._totalInvestments += amount;
            return s;
        }

        public static StartupIncubator operator -(StartupIncubator s, decimal amount)
        {
            s._totalInvestments -= amount;
            return s;
        }

        // 2. Унарний (++ та --): Залучені студенти
        public static StartupIncubator operator ++(StartupIncubator s)
        {
            s.InvolvedStudents++;
            return s;
        }

        public static StartupIncubator operator --(StartupIncubator s)
        {
            s.InvolvedStudents--;
            return s;
        }

        // 3. Порівняння за кількістю проєктів (== та !=)
        public static bool operator ==(StartupIncubator s1, StartupIncubator s2)
        {
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
                return ReferenceEquals(s1, s2);

            return s1.ProjectsCount == s2.ProjectsCount;
        }

        public static bool operator !=(StartupIncubator s1, StartupIncubator s2) => !(s1 == s2);

        // При перевантаженні == та != обов'язково треба перевизначити Equals та GetHashCode
        public override bool Equals(object obj)
        {
            if (obj is StartupIncubator other)
                return this == other;
            return false;
        }

        public override int GetHashCode() => ProjectsCount.GetHashCode();
    }
}