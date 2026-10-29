using System;

namespace Lab5.V1
{
    public abstract class AcademicInstitution
    {
        protected string _name;
        protected int _studentCount;
        protected int _unitsCount;

        protected AcademicInstitution(string name, int students, int units)
        {
            _name = name;
            _studentCount = students;
            _unitsCount = units;
        }

        public string Name => _name;
        public int StudentCount => _studentCount;
        public int UnitsCount
        {
            get => _unitsCount;
            protected set => _unitsCount = value;
        }

        // Віртуальні методи для поліморфізму
        public virtual void ChangeName(string newName) => _name = newName;

        public virtual void IncreaseStudentCount(int count)
        {
            if (count > 0) _studentCount += count;
        }

        public virtual void DecreaseStudentCount(int count)
        {
            if (count > 0)
            {
                _studentCount -= count;
                if (_studentCount < 0) _studentCount = 0;
            }
        }

        public abstract string GetInfo(); // Абстрактний метод
    }
}