using System;

class DRomb
{
    // Захищені поля
    protected int d1, d2; // діагоналі
    protected int c; // колір ромба

    // Конструктор
    public DRomb(int diagonal1, int diagonal2, int color)
    {
        d1 = diagonal1;
        d2 = diagonal2;
        c = color;
    }

    // Методи
    public void DisplayLengths()
    {
        Console.WriteLine($"Діагональ 1: {d1}");
        Console.WriteLine($"Діагональ 2: {d2}");
    }

    public double Perimeter()
    {
        return 2 * (d1 + d2);
    }

    public double Area()
    {
        return 0.5 * d1 * d2;
    }

    public bool IsSquare()
    {
        return d1 == d2;
    }

    // Властивості
    public int Diagonal1
    {
        get { return d1; }
        set { d1 = value; }
    }

    public int Diagonal2
    {
        get { return d2; }
        set { d2 = value; }
    }

    public int Color
    {
        get { return c; }
    }
}

// Базовий клас
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

// Похідний клас - Студент
class Student : Person
{
    public string University { get; set; }
    public int Year { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, University: {University}, Year: {Year}");
    }
}

// Похідний клас - Викладач
class Teacher : Person
{
    public string Department { get; set; }
    public string Subject { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Subject: {Subject}");
    }
}

// Похідний клас - Завідувач кафедри
class DepartmentHead : Teacher
{
    public string DepartmentName { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Subject: {Subject}, Department Name: {DepartmentName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Оберіть, яку частину коду ви хочете виконати:");
        Console.WriteLine("1. Виконати роботу з ромбами.");
        Console.WriteLine("2. Виконати роботу з людьми.");
        Console.Write("Введіть номер: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                // Робота з ромбами
                DRombWork();
                break;
            case 2:
                // Робота з людьми
                PeopleWork();
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    static void DRombWork()
    {
        // Задання масиву ромбів
        DRomb[] rhombuses = new DRomb[3];
        rhombuses[0] = new DRomb(4, 6, 1);
        rhombuses[1] = new DRomb(5, 5, 2); // Квадрат
        rhombuses[2] = new DRomb(3, 8, 3);

        // Вивід інформації про ромби
        for (int i = 0; i < rhombuses.Length; i++)
        {
            Console.WriteLine($"Ромб {i + 1}:");
            rhombuses[i].DisplayLengths();
            Console.WriteLine($"Периметр: {rhombuses[i].Perimeter()}");
            Console.WriteLine($"Площа: {rhombuses[i].Area()}");
            Console.WriteLine($"Чи є квадратом: {rhombuses[i].IsSquare()}");
            Console.WriteLine($"Колір: {rhombuses[i].Color}");
            Console.WriteLine();
        }

        // Визначення кількості квадратів
        int squareCount = 0;
        foreach (DRomb rhombus in rhombuses)
        {
            if (rhombus.IsSquare())
            {
                squareCount++;
            }
        }
        Console.WriteLine($"Кількість квадратів: {squareCount}");
    }

    static void PeopleWork()
    {
        // Створюємо масив базового класу Person
        Person[] people = new Person[4];

        // Наповнюємо масив різними об'єктами похідних класів
        people[0] = new Student { Name = "John", Age = 20, University = "Harvard", Year = 2 };
        people[1] = new Teacher { Name = "Alice", Age = 35, Department = "Computer Science", Subject = "Programming" };
        people[2] = new DepartmentHead { Name = "Bob", Age = 45, Department = "Computer Science", Subject = "Algorithms", DepartmentName = "CS Department" };
        people[3] = new Student { Name = "Emma", Age = 22, University = "MIT", Year = 4 };

        // Сортування масиву за критерієм - вік
        Array.Sort(people, (p1, p2) => p1.Age.CompareTo(p2.Age));

        // Виведення впорядкованого масиву
        foreach (var person in people)
        {
            person.Show();
        }
    }
}
