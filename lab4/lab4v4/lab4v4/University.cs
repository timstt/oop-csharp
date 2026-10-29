using System;

namespace Lab4.V4
{
    // Реалізуємо IComparable для порівняння за рейтингом
    public class University : AcademicInstitution, IComparable
    {
        private int _scientificPapers;
        private int _internationalProjects;
        private double _rating;
        private decimal _annualBudget;
        private double _averageZno;

        public University(string name, int students, int faculties, int papers, int projects)
            : base(name, students, faculties)
        {
            _scientificPapers = papers;
            _internationalProjects = projects;
            _rating = 0;
            _annualBudget = 0;
            _averageZno = 0;
        }

        public int ScientificPapers
        {
            get { return _scientificPapers; }
            set { _scientificPapers = value; }
        }

        public int InternationalProjects
        {
            get { return _internationalProjects; }
            set { _internationalProjects = value; }
        }

        public double Rating
        {
            get { return _rating; }
        }

        public decimal AnnualBudget
        {
            get { return _annualBudget; }
        }

        public double AverageZno
        {
            get { return _averageZno; }
            set { _averageZno = value; }
        }

        public void CalculateRating()
        {
            _rating = (_scientificPapers * 0.5) + (_internationalProjects * 10);
        }

        public void CalculateBudget()
        {
            _annualBudget = (decimal)(_rating * 15000);
        }

        // МЕТОД ІНТЕРФЕЙСУ IComparable (Сортування за рейтингом)
        public int CompareTo(object obj)
        {
            University other = obj as University;
            if (other != null)
            {
                if (this._rating > other._rating) return 1;
                if (this._rating < other._rating) return -1;
                return 0;
            }
            return 0;
        }

        public override string GetInfo()
        {
            return "Університет: " + Name + ", Рейтинг: " + _rating.ToString("F1") + ", Бюджет: " + _annualBudget.ToString("N0") + " грн.";
        }
    }
}