using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person { Name = "Alice", Age = 25 };
        Person p2 = new Person { Name = "Bob", Age = 30 };

        p1.Introduce();
        p2.Introduce();
    }
}
