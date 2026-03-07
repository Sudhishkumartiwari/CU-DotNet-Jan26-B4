namespace BonusCalculator
{
    public class Calculator
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public Calculator(decimal baseSalary, int performanceRating, int yearsOfExperience, decimal departmentMultiplier, double attendancePercentage)
        {
            BaseSalary = baseSalary;
            PerformanceRating = performanceRating;
            YearsOfExperience = yearsOfExperience;
            DepartmentMultiplier = departmentMultiplier;
            AttendancePercentage = attendancePercentage;
        }

        public decimal NetAnnualBonus{
          get {
            if (BaseSalary <= 0)
                return 0;
                
            decimal bonusPercentage;
            decimal taxRate;
            switch (PerformanceRating)
            {
                case 5 :
                    bonusPercentage = 0.25m;
                    break;
                case 4 :
                    bonusPercentage = 0.18m;
                    break;
                case 3 :
                    bonusPercentage = 0.12m;
                    break;
                case 2 :
                    bonusPercentage = 0.05m;
                    break;
                case 1 :
                    bonusPercentage = 0.00m;
                    break;
                default:
                    throw new InvalidOperationException("Invalid performance rating.");
            }
            

            decimal bonus = BaseSalary * bonusPercentage;

            if (YearsOfExperience > 10)
                bonus += BaseSalary * 0.05m;
            else if (YearsOfExperience > 5)
                bonus += BaseSalary * 0.03m;

            if (AttendancePercentage < 85)
                bonus *= 0.80m;

            bonus *= DepartmentMultiplier;

            decimal maxBonus = BaseSalary * 0.40m;
            if (bonus > maxBonus)
                bonus = maxBonus;

            switch (bonus)
            {
                case <= 150000:
                    taxRate = 0.10m;
                    break;
                case > 150000 and <= 300000:
                    taxRate = 0.20m;
                    break;
                default:
                    taxRate = 0.30m;
                    break;
            }

            decimal finalBonus = bonus * (1 - taxRate);
            return Math.Round(finalBonus, 2);
          }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter base salary:");
            decimal baseSalary = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter performance rating (1-5):");
            int performanceRating = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter years of experience:");
            int yearsOfExperience = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter department multiplier:");
            decimal departmentMultiplier = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter attendance percentage:");
            double attendancePercentage = double.Parse(Console.ReadLine());

            var calculator = new Calculator(baseSalary, performanceRating, yearsOfExperience, departmentMultiplier, attendancePercentage);
            Console.WriteLine($"Net Annual Bonus: {calculator.NetAnnualBonus:C}");
        }


    }
}


