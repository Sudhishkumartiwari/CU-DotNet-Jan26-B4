using System;

public class LineDrawer
{
    public static void DisplayLine()
    {
        DisplayLine('-', 40);
    }
    public static void DisplayLine(char symbol)
    {
        DisplayLine(symbol, 40);
    }
    public static void DisplayLine(char symbol, int length)
    {
        string line = new string(symbol, length);
        Console.WriteLine(line);
    }

    public static void Main()
    {
        DisplayLine();
        DisplayLine('+');
        DisplayLine('$', 60);
    }
}