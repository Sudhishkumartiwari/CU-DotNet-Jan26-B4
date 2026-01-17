using System;

class Program
{
    static void Main()
    {

        int count = 2;
        int i = 0;
        string[] names = new string[count];
        decimal[] premiums = new decimal[count];
        decimal total = 0, avg, high, low;

        while (i < count)
        {
            while (true)
            {
                Console.Write("Enter name: ");
                names[i] = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(names[i]))
                    break;
            }
            while (true)
            {
                Console.Write("Enter premium: ");
                {
                    premiums[i] = decimal.Parse(Console.ReadLine());
                    if (premiums[i] > 0)
                        break;
                    else
                        Console.WriteLine("Premium must be greater than 0. Try again.");
                }
            }
            Console.WriteLine();
            i++;
        }
        high = premiums[0];
        low = premiums[0];
        i = 0;
        while (i < count)
        {
            total += premiums[i];

            if (premiums[i] > high)
                high = premiums[i];

            if (premiums[i] < low)
                low = premiums[i];

            i++;
        }
        avg = total / count;
        Console.WriteLine("\nINSURANCE PREMIUM SUMMARY");
        Console.WriteLine("{0,-20} {1,12:F2} {2,12}", "NAME", "PREMIUM", "CATEGORY");
        i = 0;
        while (i < count)
        {
            string cat;

            if (premiums[i] < 10000)
                cat = "LOW";
            else if (premiums[i] <= 25000)
                cat = "MEDIUM";
            else
                cat = "HIGH";

            Console.WriteLine("{0,-20} {1,12:F2} {2,12}",
                names[i].ToUpper(), premiums[i], cat);

            i++;
        }
        Console.WriteLine($"Total Premium   : {total:F2}");
        Console.WriteLine($"Average Premium : {avg:F2}");
        Console.WriteLine($"Highest Premium : {high:F2}");
        Console.WriteLine($"Lowest Premium  : {low:F2}");
    }
}
