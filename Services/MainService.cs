using System;
using System.Reflection.PortableExecutable;

namespace ApplicationTemplate.Services;

public class MainService : IMainService
{
   
    public MainService()
    {
        
    }
    public void Invoke()
    {
        IFileManager _fileManager = new FileManager();
        string filePath = "movies.csv";

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Read from File");
        Console.WriteLine("2. Write to File");
        Console.WriteLine("3. Quit");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            _fileManager.ReadFile(filePath);
        }
        else if (choice == "2")
        {
            _fileManager.WriteFile(filePath);
        }

    }
}