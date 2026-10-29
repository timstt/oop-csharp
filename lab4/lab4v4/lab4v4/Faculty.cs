using System;
using System.Collections.Generic;

namespace Lab4.V1
{
    public class Faculty : AcademicInstitution
    {
        private string _linkedUniversity;
        private List<string> _specialties;

        public Faculty(string name, int students, string university)
            : base(name, students, 5)
        {
            _linkedUniversity = university;

            _specialties = new List<string>
            {
                "Інженерія програмного забезпечення",
                "Комп'ютерні науки",
                "Кібербезпека та захист інформації",
                "Інформаційні системи та технології",
                "Мережеві та інтернет технології"
            };

            UnitsCount = _specialties.Count;
        }

        public string LinkedUniversity
        {
            get { return _linkedUniversity; }
            set { _linkedUniversity = value; }
        }

        public List<string> Specialties
        {
            get { return _specialties; }
            set { _specialties = value; }
        }

        public void AddSpecialty(string specialtyName)
        {
            if (specialtyName != "" && !_specialties.Contains(specialtyName))
            {
                _specialties.Add(specialtyName);
                UnitsCount = _specialties.Count;
            }
        }

        public void RemoveSpecialty(string specialtyName)
        {
            if (_specialties.Contains(specialtyName))
            {
                _specialties.Remove(specialtyName);
                UnitsCount = _specialties.Count;
            }
        }

        public override string GetInfo()
        {
            string info = "Факультет: " + Name + " (" + _linkedUniversity + ")\n" +
                          "Студентів: " + StudentCount + "\n" +
                          "Кількість спеціальностей: " + UnitsCount + "\n" +
                          "Список напрямків:";

            foreach (string spec in _specialties)
            {
                info = info + "\n - " + spec;
            }

            return info;
        }
    }
}