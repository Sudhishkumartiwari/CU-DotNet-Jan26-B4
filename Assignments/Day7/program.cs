using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;

        string[] parts = input.Split('|');
        if (parts.Length != 5)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        bool isValid = true;
        string gateCode = parts[0];
        if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
            isValid = false;

        if (parts[1].Length != 1 || !char.IsUpper(parts[1][0]))
            isValid = false;
        char userInitial = parts[1][0];

        if (!byte.TryParse(parts[2], out byte level) || level < 1 || level > 7)
            isValid = false;

        if (!bool.TryParse(parts[3], out bool isActive))
            isValid = false;

        if (!byte.TryParse(parts[4], out byte attempts) || attempts > 200)
            isValid = false;

        if (!isValid)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string status;
        if (!isActive)
        {
            status = "ACCESS DENIED | INACTIVE USER";
        }
        else if (attempts > 100)
        {
            status = "ACCESS DENIED | TOO MANY ATTEMPTS";
        }
        else if (level >= 5)
        {
            status = "ACCESS GRANTED | HIGH SECURITY";
        }
        else
        {
            status = "ACCESS GRANTED | STANDARD";
        }

        Console.WriteLine($"{"Gate",-10}: {gateCode}");
        Console.WriteLine($"{"User",-10}: {userInitial}");
        Console.WriteLine($"{"Level",-10}: {level}");
        Console.WriteLine($"{"Attempts",-10}: {attempts}");
        Console.WriteLine($"{"Status",-10}: {status}");
    }
}