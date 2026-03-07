using System;

namespace SalesAnalysisSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] dailySales = new decimal[7];
            string[] categories = new string[7];

            for (int i = 0; i < dailySales.Length; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= 0) 
                    {
                        dailySales[i] = value;
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Sales must be 0 or greater."); 
                    }
                }

                if (dailySales[i] < 5000)
                    categories[i] = "Low"; 
                else if (dailySales[i] <= 15000)
                    categories[i] = "Medium"; 
                else
                    categories[i] = "High";
            }

            decimal totalSales = 0;
            decimal highestSale = dailySales[0];
            int highestDay = 1;
            decimal lowestSale = dailySales[0];
            int lowestDay = 1;

            for (int i = 0; i < dailySales.Length; i++)
            {
                totalSales += dailySales[i];

                if (dailySales[i] > highestSale)
                {
                    highestSale = dailySales[i];
                    highestDay = i + 1;
                }

                if (dailySales[i] < lowestSale)
                {
                    lowestSale = dailySales[i];
                    lowestDay = i + 1;
                }
            }

            decimal averageSale = totalSales / dailySales.Length;

            int daysAboveAverage = 0;
            for (int i = 0; i < dailySales.Length; i++)
            {
                if (dailySales[i] > averageSale)
                {
                    daysAboveAverage++;
                }
            }

            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {totalSales:N2}"); 
            Console.WriteLine($"Average Daily Sale : {averageSale:N2}"); 
            Console.WriteLine($"Highest Sale       : {highestSale:N2} (Day {highestDay})"); 
            Console.WriteLine($"Lowest Sale        : {lowestSale:N2} (Day {lowestDay})"); 
            Console.WriteLine($"Days Above Average : {daysAboveAverage}");

            Console.WriteLine("\nDay-wise Sales Category Summary:"); 
            for (int i = 0; i < dailySales.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}"); 
            }
        }
    }
}