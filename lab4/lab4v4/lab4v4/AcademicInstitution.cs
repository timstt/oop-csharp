using System;

namespace Lab4.V4
{
    public class AcademicInstitution
    {
        private string _name;
        private int _studentCount;
        private int _unitsCount;

        protected AcademicInstitution(string name, int students, int units)
        {
            _name = name;
            _studentCount = students;
            _unitsCount = units;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int StudentCount
        {
            get { return _studentCount; }
            set { _studentCount = value; }
        }

        public int UnitsCount
        {
            get { return _unitsCount; }
            set { _unitsCount = value; }
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }

        public void IncreaseStudentCount(int count)
        {
            if (count > 0)
            {
                _studentCount = _studentCount + count;
            }
        }

        public void DecreaseStudentCount(int count)
        {
            if (count > 0)
            {
                _studentCount = _studentCount - count;
                if (_studentCount < 0)
                {
                    _studentCount = 0;
                }
            }
        }

        public virtual string GetInfo()
        {
            return "Установа: " + _name + ", Студентів: " + _studentCount + ", Підрозділів: " + _unitsCount;
        }
    }
}