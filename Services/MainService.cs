using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>

public interface IFileManager
{
    void ReadFile(string path);
    void WriteFile(string path);
}

public class FileManager : IFileManager
{
    public void ReadFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        int linesRead = 0;
        int linesToRead = 10;

        sr.ReadLine();
        Console.WriteLine();
        while (linesRead < linesToRead && !sr.EndOfStream)
        {
            var line = sr.ReadLine();
            Console.WriteLine($"{line}");
            var lineArray = line.Split(',');
            linesRead++;
           
        }
        sr.Close();
    }

    public void WriteFile(string path)
    {
        throw new NotImplementedException();
    }
}

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