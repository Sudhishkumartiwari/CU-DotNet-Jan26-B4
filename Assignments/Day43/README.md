🏦 Exercise: Financial Portfolio Management & Reporting System
🎯 Objective
Design a Console-based Financial Portfolio Management System that manages different financial instruments, processes transactions, and generates portfolio reports.
 
📌 Functional Requirements
1️⃣ Financial Instruments
The system must support multiple instrument types:
• Equity
• Bond
• FixedDeposit
• MutualFund
Each instrument must:
• Have unique InstrumentId
• Name
• Currency
• PurchaseDate
• Quantity / Units
• PurchasePrice
• MarketPrice
 
2️⃣ OOP Design Constraints (Mandatory)
🔹 Abstraction
Create an abstract base class:
abstract class FinancialInstrument
It must include:
• Common properties
• Abstract method:
public abstract decimal CalculateCurrentValue();
• Virtual method:
public virtual string GetInstrumentSummary();
 
🔹 Inheritance
All instruments must inherit from FinancialInstrument.
Each instrument overrides:
• CalculateCurrentValue()
• May override GetInstrumentSummary()
 
🔹 Interfaces
Create at least two interfaces:
interface IRiskAssessable
{
   string GetRiskCategory();
}

interface IReportable
{
   string GenerateReportLine();
}
At least two instruments must implement both.
 
🔹 Encapsulation Rules
• Use private backing fields where validation is required.
• Prevent negative quantity or price.
• Throw custom exception if violated.
 
3️⃣ Custom Exception
Create:
class InvalidFinancialDataException : Exception
Throw when:
• Negative quantity
• Negative price
• Invalid currency format (must be 3-letter code)
 
4️⃣ Portfolio Management
Create a Portfolio class.
Responsibilities:
• Store instruments in:
o List<FinancialInstrument>
o Dictionary<string, FinancialInstrument> (key = InstrumentId)
• Methods:
AddInstrument()
RemoveInstrument()
GetTotalPortfolioValue()
GetInstrumentById()
GetInstrumentsByRisk(string risk)
• Use LINQ for:
o Total value
o Risk filtering
o Grouping by instrument type
 
5️⃣ Transactions Module
Create class:
class Transaction
Properties:
• TransactionId
• InstrumentId
• Type (Buy/Sell)
• Units
• Date
Store transactions in:
• Array initially
• Then convert to List for processing
Implement:
• Transaction validation
• Update portfolio holdings
 
6️⃣ Reporting Engine
Create class:
class ReportGenerator
Capabilities:
1. Console Report
• Portfolio Summary
• Grouped by instrument type
• Total investment
• Total current value
• Profit/Loss
• Risk category distribution
2. File Report
Generate:
PortfolioReport_YYYYMMDD.txt
Include:
• Header
• Instrument details
• Aggregated summary
• Timestamp
Use:
• StreamWriter
• Proper exception handling
• Ensure file closed properly
 
7️⃣ String Handling Requirements
• Format currency using:
value.ToString("C")
• Parse instrument input from CSV line:
EQ001,Equity,INFY,INR,100,1500,1650
• Validate string formats
• Use string.Split
• Use string interpolation
 
8️⃣ Arrays & Collections Usage
Must include:
• Array of transactions
• List of instruments
• Dictionary for lookup
• LINQ for:
o OrderByDescending
o GroupBy
o Sum
o Where
 
9️⃣ Polymorphism Requirement
Portfolio must store:
List<FinancialInstrument>
And call:
instrument.CalculateCurrentValue();
Without knowing concrete type.
 
🔟 Edge Cases to Handle
• Selling more units than owned
• Duplicate instrument ID
• File write permission error
• Invalid CSV format
• Currency mismatch in portfolio
 
📊 Sample Report Output (Console)
===== PORTFOLIO SUMMARY =====

Instrument Type: Equity
Total Investment: ₹500,000
Current Value: ₹575,000
Profit/Loss: ₹75,000

Instrument Type: Bond
Total Investment: ₹200,000
Current Value: ₹210,000

Overall Portfolio Value: ₹785,000
Risk Distribution:
Low: 2
Medium: 1
High: 1
 