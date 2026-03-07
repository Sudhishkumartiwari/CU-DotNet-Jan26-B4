
namespace LoanPortfolioManager{
    
    public class Loan
    {
        public string? ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
    }


    class Program
    {
       public static void Main(string[] args)
       {
        string filePath = "loans.csv";

        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {

            if (new FileInfo(filePath).Length == 0)
            {
                writer.WriteLine("Client,Principal,Rate");
            }

            Console.WriteLine("Enter Client Name:");
            string? name = Console.ReadLine();
            
            Console.WriteLine("Enter Principal Amount:");
            double.TryParse(Console.ReadLine(), out double principal); 

            Console.WriteLine("Enter Interest Rate (e.g., 5.5):");
            double.TryParse(Console.ReadLine(), out double rate);

            writer.WriteLine($"{name},{principal},{rate}");
        }

       
        Console.WriteLine("\nCLIENT      | PRINCIPAL    | INTEREST    | RISK LEVEL");
        Console.WriteLine("-------------------------------------------------------");

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); 

            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    double.TryParse(parts[1], out double principal);
                    double.TryParse(parts[2], out double rate);

                    double interestAmt = (principal * rate / 100);

                    string risk = "LOW";
                    if (rate > 10) risk = "HIGH";
                    else if (rate >= 5) risk = "MEDIUM";

                    Console.WriteLine($"{name,-11} | {principal,12:C} | {interestAmt,11:C} | {risk}");
                }
            }
        }
    }
}
}
