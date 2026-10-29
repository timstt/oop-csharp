using System;
using System.Collections.Generic;

public class Faculty
{
    private string _name;
    private int _departmentCount;
    private int _specialtyCount;
    private int _studentCount;
    private string _linkedUniversityName;
    private List<string> _specialties;

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

    public string LinkedUniversityName
    {
        get { return _linkedUniversityName; }
        set { _linkedUniversityName = value; }
    }

    public int DepartmentCount
    {
        get { return _departmentCount; }
    }

    public int SpecialtyCount
    {
        get { return _specialtyCount; }
    }

    public Faculty()
    {
        _name = "Unknown Faculty";
        _studentCount = 0;
        _linkedUniversityName = "None";
        _specialties = new List<string>();
        _departmentCount = 0;
        _specialtyCount = 0;
    }

    public Faculty(string name, string dean, int students, string university)
    {
        _name = name;
        _studentCount = students;
        _linkedUniversityName = university;
        _specialties = new List<string>();
        _departmentCount = 0;
        _specialtyCount = 0;
    }

    public Faculty(Faculty other)
    {
        _name = other._name;
        _studentCount = other._studentCount;
        _linkedUniversityName = other._linkedUniversityName;
        _departmentCount = other._departmentCount;
        _specialtyCount = other._specialtyCount;
        _specialties = new List<string>(other._specialties);
    }

    public void AddSpecialty(string specialtyName)
    {
        if (!string.IsNullOrEmpty(specialtyName) && !_specialties.Contains(specialtyName))
        {
            _specialties.Add(specialtyName);
            _specialtyCount = _specialties.Count;
            _departmentCount = _specialtyCount; // Кафедри = Спеціальності
        }
    }

    public void RemoveSpecialty(string specialtyName)
    {
        if (_specialties.Remove(specialtyName))
        {
            _specialtyCount = _specialties.Count;
            _departmentCount = _specialtyCount;
        }
    }

    public void UpdateStudentCount(int delta)
    {
        _studentCount = _studentCount + delta;
        if (_studentCount < 0)
        {
            _studentCount = 0;
        }
    }
}