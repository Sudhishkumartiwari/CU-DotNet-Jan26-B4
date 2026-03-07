    
namespace first{

        class Loan
        {
            public string LoanNumber {get;set;}
            public string CustomerName {get;set;}
            public decimal PrincipalAmount {get;set;}
            public int Tenure {get;set;} // in years

            public Loan()
            {
                LoanNumber = string.Empty;
                CustomerName = string.Empty;
                PrincipalAmount = 0;
                Tenure = 0;
            }
            public Loan(string loanNumber , string customerName , decimal principalAmount, int tenure)
            {
                this.LoanNumber=loanNumber;
                this.CustomerName=customerName;
                this.PrincipalAmount=principalAmount;
                this.Tenure=tenure;
            }

            public decimal EmiCalculator()
            {
                 float rateOfInterest = 10/100;
                 decimal Result = (PrincipalAmount + (PrincipalAmount * (decimal)rateOfInterest))/Tenure;
                 return Result;
            }
        }
        
        class HomeLoan : Loan
        {
            public HomeLoan(string loanNumber , string customerName , decimal principalAmount , int tenure): base(loanNumber, customerName, principalAmount, tenure)
            {}
            public new  decimal EmiCalculator()
            {
                 float rateOfInterest = 8/100;
                 decimal Result = ((PrincipalAmount + (PrincipalAmount * (decimal)rateOfInterest))/Tenure) + PrincipalAmount * (decimal)0.01;
                 return Result;
               
            }
        }

        class CarLoan : Loan
        {
            public CarLoan( string loanNumber , string customerName , decimal principalAmount , int tenure): base(loanNumber, customerName, principalAmount, tenure)
            {}
            public new decimal EmiCalculator()
            {
                 float rateOfInterest = 9/100;
                 decimal Result = ((PrincipalAmount + (PrincipalAmount * (decimal)rateOfInterest))/Tenure) + PrincipalAmount * (decimal)0.005;
                 return Result;
               
            }
        }

    //base class array can be Created instead of creating object array of derived class
    internal class LoanNumberPrint
    {
        public static void Main(string[] args)
        {
            Loan[] loans = new Loan[2];
            HomeLoan hl = new HomeLoan("150001", "Alice", 500000, 10);
            CarLoan cl = new CarLoan("250001", "Bob", 500000, 10);
            loans[0] = hl;
            loans[1] = cl;
            for(int i=0; i< loans.Length; i++)
                {
                    Console.WriteLine(loans[i].EmiCalculator());
                }
        }
    }
    
}
 