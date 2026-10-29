using System;
using System.Collections.Generic;

public class Faculty
{
    // --- ПОЛЯ ТА ВЛАСТИВОСТІ ФАКУЛЬТЕТУ (З ВЕРСІЇ 1) ---
    private string _name;
    private string _dean;
    private int _departmentCount;
    private int _specialtyCount;
    private int _studentCount;
    private string _linkedUniversityName;
    private List<string> _specialties;

    public string Name { get { return _name; } set { _name = value; } }
    public string Dean { get { return _dean; } set { _dean = value; } }
    public int StudentCount { get { return _studentCount; } set { _studentCount = value; } }
    public string LinkedUniversityName { get { return _linkedUniversityName; } set { _linkedUniversityName = value; } }
    public int DepartmentCount { get { return _departmentCount; } }
    public int SpecialtyCount { get { return _specialtyCount; } }

    public Faculty(string name, string dean, int students, string university)
    {
        _name = name;
        _dean = dean;
        _studentCount = students;
        _linkedUniversityName = university;
        _specialties = new List<string>();
        _departmentCount = 0;
        _specialtyCount = 0;
    }

    public void AddSpecialty(string specialtyName)
    {
        if (!string.IsNullOrEmpty(specialtyName) && !_specialties.Contains(specialtyName))
        {
            _specialties.Add(specialtyName);
            _specialtyCount = _specialties.Count;
            _departmentCount = _specialtyCount;
        }
    }

    // ====================================================================
    // ВЕРСІЯ 2: ВКЛАДЕНИЙ КЛАС StartupIncubator
    // ====================================================================
    public class StartupIncubator
    {
        // Атрибути за Таблицею 5.2
        private string _incubatorName;
        private int _mentorCount;
        private int _activeProjectCount;
        private int _involvedStudentCount;
        private double _investmentAmount;
        private List<string> _startupList;

        private static Random _rnd = new Random();

        // Властивості
        public string IncubatorName { get { return _incubatorName; } set { _incubatorName = value; } }
        public int MentorCount { get { return _mentorCount; } set { _mentorCount = value; } }
        public int ActiveProjectCount { get { return _activeProjectCount; } }
        public double InvestmentAmount { get { return _investmentAmount; } set { _investmentAmount = value; } }

        public StartupIncubator(string name, double investment)
        {
            _incubatorName = name;
            _investmentAmount = investment;
            _mentorCount = 0;
            _activeProjectCount = 0;
            _involvedStudentCount = 0;
            _startupList = new List<string>();
        }

        // Операція: Додати студентський стартап
        public void AddStartup(string startupName)
        {
            if (!_startupList.Contains(startupName))
            {
                _startupList.Add(startupName);
                _activeProjectCount = _startupList.Count;
            }
        }

        // Операція: Призначити ментора
        public void AssignMentor(int count)
        {
            _mentorCount = _mentorCount + count;
        }

        // Операція: Вибрати найкращий стартап проєкт (Алгоритм матриці 5x10)
        public int SelectBestStartup()
        {
            int experts = 5;
            int projects = 10;
            int[,] scores = new int[experts, projects];
            double[] averageScores = new double[projects];

            // 1. Заповнюємо матрицю випадковими оцінками (1-10)
            for (int i = 0; i < experts; i++)
            {
                for (int j = 0; j < projects; j++)
                {
                    scores[i, j] = _rnd.Next(1, 11);
                }
            }

            // 2. Рахуємо суму і середнє арифметичне по стовпцях (для кожного проєкту)
            for (int j = 0; j < projects; j++)
            {
                int sum = 0;
                for (int i = 0; i < experts; i++)
                {
                    sum = sum + scores[i, j];
                }
                averageScores[j] = (double)sum / experts;
            }

            // 3. Шукаємо проєкт з найменшим середнім балом
            double minScore = averageScores[0];
            int bestProjectIndex = 0;

            for (int j = 1; j < projects; j++)
            {
                if (averageScores[j] < minScore)
                {
                    minScore = averageScores[j];
                    bestProjectIndex = j; // Запам'ятовуємо індекс найкращого (де найменший бал)
                }
            }

            return bestProjectIndex + 1; // Повертаємо номер проєкту (від 1 до 10)
        }

        // Операція: Розрахувати рейтинг результативності студентів
        public double[] CalculatePerformanceRating(int studentCount)
        {
            _involvedStudentCount = studentCount;
            double[] studentPerformances = new double[_involvedStudentCount];

            // Розраховуємо показник для кожного студента
            for (int i = 0; i < _involvedStudentCount; i++)
            {
                double share = _rnd.NextDouble(); // генерація від 0.0 до 1.0
                studentPerformances[i] = share * _investmentAmount;
            }

            // Сортуємо масив за зростанням, а потім перевертаємо (щоб було за спаданням)
            Array.Sort(studentPerformances);
            Array.Reverse(studentPerformances);

            return studentPerformances;
        }
    }
}