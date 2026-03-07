using System;

namespace Program
{
    class InsuranceProgram
    {  
    static void Main(string[] args)
    {
        string[] policyHoldernames = new string[5];
        decimal[] annualPremiums = new decimal[5];

        decimal totalPremium = 0;
        decimal highestPremium = 0;
        decimal lowestPremium = decimal.MaxValue;
        decimal averagePremium = 0;

        for(int i = 0; i < 5 ; i++)
            {
                string name = " ";
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write($"Enter name for policyholder {i+1} :");
                    name = Console.ReadLine();
                }
                policyHoldernames[i]= name;

                decimal premium =0;
                bool isValidPremium = false;
                while (!isValidPremium)
                {
                    Console.Write($"Enter Annual Premium for {name}:");
                    string input = Console.ReadLine();

                    if(decimal.TryParse(input , out premium )&& premium > 0)
                    {
                        isValidPremium = true;
                    }
                }
                annualPremiums[i] = premium;
                totalPremium += premium;

                if(premium > highestPremium)
                {
                    highestPremium  = premium;
                }
                if(premium < lowestPremium)
                {
                    lowestPremium = premium;
                }
            }

            averagePremium = totalPremium /5;
            Console.WriteLine("insurance premium summary");
            Console.WriteLine("--------------------------------------------------");    
            Console.WriteLine("{0,-20} {1,-15} {2,-10}", "Name", "Premium", "Category");
            Console.WriteLine("--------------------------------------------------");

            for(int i =0; i< 5; i++)
            {
                string upperName = policyHoldernames[i].ToUpper();
                string category = "";

                if (annualPremiums[i] < 10000)
                {
                    category = "LOW";
                }
                else if (annualPremiums[i] <= 25000)
                {
                    category = "MEDIUM";
                }
                else
                {
                    category = "HIGH";
                }

                Console.WriteLine("{0,-20}{1, -15:F2}{2,-10}",upperName,annualPremiums[i],category);

            }
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Total Premium   : {totalPremium:F2}");
            Console.WriteLine($"Average Premium : {averagePremium:F2}");
            Console.WriteLine($"Highest Premium : {highestPremium:F2}");
            Console.WriteLine($"Lowest Premium  : {lowestPremium:F2}");

       }
    }
}






