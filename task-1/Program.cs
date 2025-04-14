Console.WriteLine("Enter a Number: ");

int num = Convert.ToInt32(Console.ReadLine());

double fact = 1;
for (int i = 1; i <= num; i++)
{
    fact *= i;
}

Console.WriteLine($"Factorial of {num} is {fact}");
