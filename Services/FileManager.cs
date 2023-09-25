using System;
using System.IO;
using System.Linq;

namespace ApplicationTemplate.Services;

public class FileManager : IFileManager
{
    public void ReadFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        int linesToRead = 10;
        sr.ReadLine();



        while (!sr.EndOfStream)
    {
            Console.WriteLine("Press Enter to read the next 10 lines or press Escape to exit.");
            Console.WriteLine();
        for (int i = 0; i < linesToRead; i++)
        {
            var line = sr.ReadLine();
            if (line == null)
            {
                break;
            }
            Console.WriteLine($"{line}");
        }

        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Escape)
        {
            break; 
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            Console.WriteLine(); 
        }
    }

    sr.Close();
    }

    public void WriteFile(string path)
    {
        int genreCount;
        bool isValidInput = false;
        string[] genreArray = new string[100];

        var movieID = GetLastMovieId(path) + 1; 

        Console.WriteLine("Enter Title");
        var title = Console.ReadLine();

        while (true)
        {
            do
            {
                Console.Write("How many Genres is this movie? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out genreCount))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (!isValidInput);

            for (int i = 0; i < genreCount; i++)
            {
                Console.WriteLine($"Genre {i + 1}:");
                genreArray[i] = Console.ReadLine();
            }
            break;
        }

        string genreString = string.Join("|", genreArray.Take(genreCount));

        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine($"{movieID},{title},{genreString}");
        }
    }

    public int GetLastMovieId(string path)
    {
        if (!File.Exists(path))
        {
            return 0; 
        }

        var lines = File.ReadLines(path);
        var lastLine = lines.LastOrDefault(); 
        if (lastLine != null)
        {
            var parts = lastLine.Split(',');
            if (parts.Length > 0 && int.TryParse(parts[0], out int lastMovieId))
            {
                return lastMovieId;
            }
        }

        return 0; 
    }
}
