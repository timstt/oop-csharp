using System;
using System.Collections.Generic;

namespace Lab5.V1
{
    public class SetOfUniversity
    {
        private List<University> _universities = new List<University>();

        public void Add(University uni)
        {
            _universities.Add(uni);
        }

        // ІНДЕКСАТОР (Завдання 6)
        public University this[int index]
        {
            get
            {
                if (index >= 0 && index < _universities.Count)
                    return _universities[index];
                throw new IndexOutOfRangeException("Університету з таким індексом не існує!");
            }
            set
            {
                if (index >= 0 && index < _universities.Count)
                    _universities[index] = value;
                else
                    throw new IndexOutOfRangeException("Університету з таким індексом не існує!");
            }
        }

        public int Count => _universities.Count;
    }
}