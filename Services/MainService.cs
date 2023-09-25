using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
   
    public MainService()
    {
        
    }
    public void Invoke()
    {
        IFileManager _fileManager = new FileManager();

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Read from File");
        Console.WriteLine("2. Write to File");
        Console.WriteLine("3. Quit");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            _fileManager.ReadFile("movies.csv");
        }

    }
}