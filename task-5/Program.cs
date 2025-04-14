using System;
using System.IO;


string InputPath = "./input.txt";
string OutputPath = "./output.txt";

try{
    var contents = File.ReadAllLines(InputPath);

    int LineCount = contents.Length;


    int WordCount = 0;

    foreach (string Lines in contents)
    {
        string[] line = Lines.Split(' ');
        foreach (string word in line)
        {
            WordCount++;
        }
    }
    ;

    using(StreamWriter writer = new StreamWriter(OutputPath)){
        writer.WriteLine($"There are {LineCount} Lines in the Document");
        writer.WriteLine($"Also {WordCount} words.");
    };
}

catch(FileNotFoundException){
    Console.WriteLine("Input File not Found!");
}
catch(IOException ex){
    Console.WriteLine("IOException Occured "+ ex.Message);
}


