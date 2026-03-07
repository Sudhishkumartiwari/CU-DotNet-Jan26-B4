
namespace One
{
    public class Policy
    {
        public int PolicyId {get;set;}
        public string? HolderName {get;set;}
        public decimal Premium {get; set;}
        public int RiskScore {get;set;}
        public DateTime RenewalDate {get;set;}

        public override string ToString()
        {
            return $"Policy Id: {PolicyId} | Holder Name:{HolderName} | Premium:{Premium} | RiskScore:{RiskScore} | Date:{RenewalDate}";
        }

    }

    public class PolicyTracker
    {
        public static Dictionary<string, Policy> Policies = new Dictionary<string, Policy>();

        public static void AddPolicy(string Id, Policy P)
        {
            Policies.Add(Id,P);
        }
        public static void BulkAdjustment()
        {

             foreach(var items in Policies)
            {
                if(items.Value.RiskScore > 75)
                {
                    items.Value.Premium *= 1.05m;
                    Console.WriteLine($"Adjustment: Increased premium for {items.Value.HolderName} (Risk: {items.Value.RiskScore})");
                }
            }          
        }
        public static void CleanUp()
        { 
            DateTime D = DateTime.Now.AddYears(-3);

            foreach(string id in Policies.Keys.ToList())
            {
                if(Policies[id].RenewalDate < D)
                {
                    Console.WriteLine($"Cleanup: Removing expired policy for {Policies[id].HolderName}");
                    Policies.Remove(id);
                }
            }
            
        }

        public static void SecurityCheck(string Id)
        {
            if (Policies.TryGetValue(Id, out Policy found))
            {
                Console.WriteLine("Policy Found: " + found);
            }
            else
            {
                Console.WriteLine("Not Found: The ID " + Id + " does not exist.");
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {

            PolicyTracker.AddPolicy("P101", new Policy {PolicyId = 101, HolderName = "Alice", Premium = 1000m, RiskScore = 85, RenewalDate = DateTime.Now});
            PolicyTracker.AddPolicy("P102", new Policy {PolicyId = 102, HolderName = "Bob", Premium = 1200m, RiskScore = 40, RenewalDate = DateTime.Now.AddYears(-5)});
            PolicyTracker.AddPolicy("P103", new Policy {PolicyId = 103, HolderName = "Charlie", Premium = 2000m, RiskScore = 90, RenewalDate = DateTime.Now });

            Console.WriteLine("--- Starting Annual Process ---");

            PolicyTracker.BulkAdjustment();

            PolicyTracker.CleanUp();

            Console.WriteLine("\n--- Final Security Checks ---");

            PolicyTracker.SecurityCheck("P101");
            PolicyTracker.SecurityCheck("P102");
            PolicyTracker.SecurityCheck("P999");

        }
    }         
}