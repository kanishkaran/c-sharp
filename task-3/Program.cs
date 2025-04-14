
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> items = new List<string>();
        string input;

        do
        {
            Console.WriteLine("\nCommands: ADD, REMOVE, SHOW, EXIT");
            Console.Write("Enter command: ");
            input = Console.ReadLine().Trim().ToUpper();

            if (input == "ADD")
            {
                Console.Write("Enter item to add: ");
                string item = Console.ReadLine().Trim();
                items.Add(item);
                Console.WriteLine("Item added.");
            }
            else if (input == "REMOVE")
            {
                Console.Write("Enter item to remove: ");
                string item = Console.ReadLine().Trim();
                if (items.Remove(item))
                    Console.WriteLine("Item removed.");
                else
                    Console.WriteLine("Item not found.");
            }
            else if (input == "SHOW")
            {
                Console.WriteLine("List contents:");
                foreach (string item in items)
                    Console.WriteLine("- " + item);
            }
        } while (input != "EXIT");
    }
}
