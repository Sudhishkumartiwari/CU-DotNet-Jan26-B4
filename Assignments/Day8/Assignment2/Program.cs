using System;

    class Program
    {
        static viod Main(string[] args)
        {
            string standardNarration = "cash deposit successfull";
            string input = Console.ReadLine();

            string[] Parts = input.Split('#');
            if(Parts.Length > 3) return;

            string transactionId = Parts[0];
            string accountHolder = Parts[1];
            string narration = Parts[2].ToLower().Trim(); 

            while(narration.Contains("  "))
            {
                narration = narration.Replace("  "," ");
            }

            bool hasWithdraw = narration.Contains("withdraw");
            bool hasDeposit = narration.Contains("deposit");
            bool hastransfer = narration.Contains("transfer");
            bool hasKeyword = hasWithdraw || hasDeposit || hastransfer;

            string Category;

            if (!hasKeyword)
            {
                Category = "NON-FINANCIAL TRANSACTION";
            }
            else if (narration.Equals(standardNarration))
            {
                Category = "STANDARD TRANSACTION";
            }
            else
            {
                Category = "CUSTOM TRANSACTION";
            }

            Console.WriteLine($"{"Transaction ID",-15} : {transactionId}"); 
            Console.WriteLine($"{"Account Holder",-15} : {accountHolder}"); 
            Console.WriteLine($"{"Narration",-15} : {narration}");
            Console.WriteLine($"{"Category",-15} : {Category}"); 
        }
     }

