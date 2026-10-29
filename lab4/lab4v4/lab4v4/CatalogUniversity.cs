using System;
using System.Collections;

namespace Lab4.V4
{
    // Реалізуємо IComparer, IEnumerable та IEnumerator
    public class CatalogUniversity : IComparer, IEnumerable, IEnumerator
    {
        private University[] _universities;
        private int _position = -1; // Позиція для перебору (IEnumerator)

        public CatalogUniversity(University[] universities)
        {
            _universities = universities;
        }

        public University[] GetArray()
        {
            return _universities;
        }

        // --- 1. РЕАЛІЗАЦІЯ IComparer (Порівняння за бюджетом) ---
        public int Compare(object x, object y)
        {
            University u1 = x as University;
            University u2 = y as University;

            if (u1 != null && u2 != null)
            {
                if (u1.AnnualBudget > u2.AnnualBudget) return 1;
                if (u1.AnnualBudget < u2.AnnualBudget) return -1;
                return 0;
            }
            return 0;
        }

        // --- 2. РЕАЛІЗАЦІЯ IEnumerable ---
        public IEnumerator GetEnumerator()
        {
            // Повертаємо сам об'єкт, бо він реалізує IEnumerator
            return this;
        }

        // --- 3. РЕАЛІЗАЦІЯ IEnumerator ---
        public bool MoveNext()
        {
            _position = _position + 1; //+= 1
            if (_position < _universities.Length)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                return _universities[_position];
            }
        }
    }
}