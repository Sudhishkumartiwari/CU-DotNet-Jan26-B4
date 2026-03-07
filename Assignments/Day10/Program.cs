using System;

namespace SalesOrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] dailySales = new decimal[7];
            string[] categories = new string[7];

            ReadWeeklySales(dailySales);

            decimal totalSales = CalculateTotal(dailySales);
            decimal averageSales = CalculateAverage(totalSales, dailySales.Length);

            decimal highestValue = FindHighestSale(dailySales, out int highestDay);
            decimal lowestValue = FindLowestSale(dailySales, out int lowestDay);

            decimal discountAmount = CalculateDiscount(totalSales);
            decimal taxAmount = CalculateTax(totalSales - discountAmount);
            decimal finalPayable = CalculateFinalAmount(totalSales, discountAmount, taxAmount);

            GenerateSalesCategory(dailySales, categories);

            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"{"Total Sales",-20} : {totalSales:N2}");
            Console.WriteLine($"{"Average Daily Sale",-20} : {averageSales:N2}");
            Console.WriteLine($"{"Highest Sale",-20} : {highestValue:N2} (Day {highestDay})");
            Console.WriteLine($"{"Lowest Sale",-20} : {lowestValue:N2} (Day {lowestDay})");
            Console.WriteLine($"{"Discount Applied",-20} : {discountAmount:N2}");
            Console.WriteLine($"{"Tax Amount",-20} : {taxAmount:N2}");
            Console.WriteLine($"{"Final Payable",-20} : {finalPayable:N2}");
            
            Console.WriteLine("\nDay-wise Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }

        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= 0)
                    {
                        sales[i] = value;
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a non-negative decimal value.");
                    }
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal sum = 0;
            foreach (decimal sale in sales) sum += sale;
            return sum;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return days > 0 ? total / days : 0;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal high = sales[0];
            day = 1;
            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > high)
                {
                    high = sales[i];
                    day = i + 1;
                }
            }
            return high;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal low = sales[0];
            day = 1;
            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < low)
                {
                    low = sales[i];
                    day = i + 1;
                }
            }
            return low;
        }

        static decimal CalculateDiscount(decimal total)
        {
            decimal rate = (total >= 50000) ? 0.10m : 0.05m;
            return total * rate;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal baseDiscount = CalculateDiscount(total);
            return isFestivalWeek ? baseDiscount + (total * 0.05m) : baseDiscount;
        }

        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return (total - discount) + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000) categories[i] = "Low";
                else if (sales[i] <= 15000) categories[i] = "Medium";
                else categories[i] = "High";
            }
        }
    }
}