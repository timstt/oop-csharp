# Object-Oriented Programming in C#

Laboratory assignments for the **Object-Oriented Programming** course (Software Engineering, Taras Shevchenko National University of Kyiv), implemented in **C#** (.NET Framework 4.8, console applications).

The labs build up the core OOP ideas step by step: classes and encapsulation, composition, inheritance and abstract classes, interfaces, operator overloading, and finally events and custom exceptions in one larger model.

## Labs

| Lab | Topic | What it does | Folder |
|-----|-------|--------------|--------|
| 1 | Basics and encapsulation | Console program with validated input, polynomial and function calculations wrapped in a class with private constants | [Lab1](./Lab1) |
| 2 | Classes for arrays and matrices | `Vector` and `Matrix` classes: random generation, sorting, binary search, statistics over a matrix (totals, minimum, maximum), `Service` class for output | [lab2](./lab2) |
| 3 | Class design: University and Faculty | Fields, properties, constructors (default, parameterized, copy), methods for rating and budget, relationship between `University`, `Faculty` and `StartupIncubator`; three versions | [lab3](./lab3) |
| 4 | Inheritance and interfaces | Base class `AcademicInstitution`, derived `University` and `Faculty`, `override`, `IComparable` (sort by rating), `IComparer`, `IEnumerable` / `IEnumerator` in a catalog class | [lab4](./lab4) |
| 5 | Abstract classes and operator overloading | Abstract `AcademicInstitution`, `StartupIncubator` with overloaded operators (`+`, `-`, `++`, `--`, `==`, `!=`), `Equals` and `GetHashCode`, indexer in a set of universities | [lab5](./lab5) |
| 6 | Smart kitchen: final model | Many cooperating classes: aggregation and association, abstract `SmartDevice`, custom exception `SmartKitchenException`, delegates and events (`OnScanStarted`, `OnBadProductDetected` and others) | [lab6](./lab6) |

## OOP concepts covered

- Encapsulation, properties, constructors, copy constructors
- Composition, aggregation, association
- Inheritance, abstract classes, `override`
- Interfaces: `IComparable`, `IComparer`, `IEnumerable`, `IEnumerator`
- Operator overloading, indexers, `Equals` / `GetHashCode`
- Custom exceptions
- Delegates and events

## Tech stack

- C#
- .NET Framework 4.8
- Console applications (Visual Studio solutions)

## Getting started

1. Clone the repository:
   ```bash
   git clone https://github.com/timstt/oop-csharp.git
   ```
2. Open the `.sln` file of the lab you want in Visual Studio (for example, `lab6/lab6v4.sln`).
3. Press **F5** to build and run.

## Author

**Tymofii Stukalo**, software engineering student.
GitHub: [@timstt](https://github.com/timstt)
