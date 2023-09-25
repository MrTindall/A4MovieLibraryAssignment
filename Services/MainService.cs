using System;

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
        Console.WriteLine("Use this as the main in a sense, put code here so it will be called by the main");
        Console.ReadLine();
       
    }
}