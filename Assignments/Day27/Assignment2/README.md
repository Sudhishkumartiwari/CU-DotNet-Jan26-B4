Assignment: The Loan Portfolio Manager
Objective: Create a Loan class, save a list of loan objects to a CSV file, and then read them back to identify which loans are "High Risk" based on their interest rate.
Step 1: Define the Data Structure
First, we need a simple class to represent our Loan.
C#
public class Loan
{
   public string ClientName { get; set; }
   public double Principal { get; set; }
   public double InterestRate { get; set; } // e.g., 5.5 for 5.5%
}
Step 2: The Implementation
This code should demonstrate writing multiple objects and then parsing them back into a collection.
Critical Concepts to Note
• The CSV Format: We use line.Split(',') to turn a single string into an array. This is the foundation of data parsing in C#.
• The Header: Notice we write a header row so humans can read the file in Excel, but we must use reader.ReadLine() once before the loop to "skip" it so it doesn't crash our math logic.
• The "C" Formatter: Using :C inside a string interpolation (e.g., {principal:C}) automatically formats the number as local currency.
Your Challenge Tasks
1. Append Mode: Modify the "Write" section so that instead of overwriting the file, it asks the user for a new loan's details and appends it to the existing CSV.
2. Calculated Field: In the "Read" section, calculate the total interest amount (Principal * Rate / 100) and display it alongside the name.
3. Data Safety: Wrap the double.Parse in a try-catch block or use double.TryParse to prevent the program from crashing if the CSV has a typo.
 
Interest calculation logic:
• High Risk: Interest Rate > 10%
• Medium Risk: Interest Rate between 5% and 10%
• Low Risk: Interest Rate < 5%
 
Display Format

 