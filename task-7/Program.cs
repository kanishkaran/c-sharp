using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static async Task Main()
        {
            var tasks = new List<Task> 
            {
                FetchSomeFiles(),
                FetchSomeImages()
            };

            await Task.WhenAll(tasks);
        }

        static async Task FetchSomeFiles()
        {   
            Console.WriteLine("Fetching Information for file...");

            string TextContent = await File.ReadAllTextAsync("./Sample.txt");

            Console.WriteLine($"Fetched Files \n {TextContent}");
        }

        static async Task FetchSomeImages()
        {
            Console.WriteLine("Fetching Some Images..");

            await Task.Delay(2000);

            Console.WriteLine("Images Fetched..");
        }

    }
}