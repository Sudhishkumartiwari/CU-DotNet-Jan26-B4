using System;

class Program
{
    static void Main()
    {
        string rawInput = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(rawInput)) return;

        string[] parts = rawInput.Split('|');
        string userName = parts[0].Trim();
        string message = parts[1].Trim().ToLower();

        string standardMessage = "login successful";
        string status;

        if (!message.Contains("successful"))
        {
            status = "LOGIN FAILED";
        } 
        else if (message.Equals(standardMessage))
        {
            status = "LOGIN SUCCESS";
        }
        else
        {
            status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
        }

        Console.WriteLine($"{"User",-10}:{userName}");
        Console.WriteLine($"{"Message",-10}:{message}");
        Console.WriteLine($"{"Status",-10}:{status}");

    }
}