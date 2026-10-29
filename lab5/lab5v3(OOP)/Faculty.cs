using System;
using System.Collections.Generic;

namespace Lab5.V1
{
    public class Faculty : AcademicInstitution
    {
        private const int DefaultSpecialtiesCount = 5;
        private string _linkedUniversity;
        private List<string> _specialties;

        public int DepartmentsCount { get; set; } // Кількість кафедр
        public StartupIncubator Incubator { get; set; }

        public Faculty(string name, int students, string university, int departments = 3)
            : base(name, students, DefaultSpecialtiesCount)
        {
            _linkedUniversity = university;
            DepartmentsCount = departments;
            _specialties = new List<string> { "Інженерія ПЗ", "Кібербезпека", "Комп'ютерні науки" };
            UnitsCount = _specialties.Count;
        }

        public override string GetInfo()
        {
            string info = $"Факультет: {_name} ({_linkedUniversity}), Кафедр: {DepartmentsCount}, Студентів: {_studentCount}, Спеціальностей: {UnitsCount}";
            return info;
        }

        // --- ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ---

        // 1. Бінарні: Збільшити/зменшити кількість кафедр
        public static Faculty operator +(Faculty f, int departments) { f.DepartmentsCount += departments; return f; }
        public static Faculty operator -(Faculty f, int departments) { f.DepartmentsCount -= departments; return f; }

        // 2. Бінарні: Порівняння за кількістю студентів
        public static bool operator >(Faculty f1, Faculty f2) => f1.StudentCount > f2.StudentCount;
        public static bool operator <(Faculty f1, Faculty f2) => f1.StudentCount < f2.StudentCount;

        // 3. Унарні: Збільшити/зменшити кількість спеціальностей
        public static Faculty operator ++(Faculty f) { f.UnitsCount++; return f; }
        public static Faculty operator --(Faculty f) { f.UnitsCount--; return f; }
    }
}