using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public double Grade { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Grade = 85.5, Age = 20 },
            new Student { Name = "Bob", Grade = 72.0, Age = 21 },
            new Student { Name = "Charlie", Grade = 90.2, Age = 22 },
            new Student { Name = "Diana", Grade = 65.3, Age = 19 }
        };

        Console.Write("Enter grade threshold: ");
        if (double.TryParse(Console.ReadLine(), out double threshold))
        {
            var filtered = students
                .Where(s => s.Grade > threshold)
                .OrderByDescending(s => s.Grade);

            Console.WriteLine("\nStudents with grade above threshold:");
            foreach (var s in filtered)
                Console.WriteLine($"{s.Name} - Grade: {s.Grade}, Age: {s.Age}");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
