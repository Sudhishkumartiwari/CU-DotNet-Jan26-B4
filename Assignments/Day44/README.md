The Challenge: "The SaaS Architect"
1. The Foundation (Abstraction & Inheritance)
Create an abstract class Subscriber with:
• Properties: Guid ID, string Name, and DateTime JoinDate.
• Abstract Method: decimal CalculateMonthlyBill().
• Inheritance: Create two subclasses:
o BusinessSubscriber: Has a FixedRate and a TaxRate.
o ConsumerSubscriber: Has a DataUsageGB and PricePerGB.
2. Identity & Comparison (Equals & Comparable)
To manage your list effectively, you must define how Subscriber objects are identified and ordered:
• Override Equals and GetHashCode: Two subscribers are equal if they have the same ID.
• Implement IComparable<Subscriber>: The default sort order should be by JoinDate (ascending). If dates are identical, sort alphabetically by Name.
3. The Data Structure (Dictionary & Sorting)
In your main program, initialize a Dictionary<string, Subscriber> where the key is the subscriber's Email and the value is the Subscriber object.
The Task:
1. Add at least 5 mixed subscribers to the Dictionary.
2. The Hard Part: Sort the Dictionary by the Subscriber's monthly bill (descending) and store the result in a way that preserves order for the report.
Note: Remember that a standard Dictionary is unordered. You will need to use LINQ or a SortedDictionary with a custom comparer to achieve this.
4. Polymorphic Reporting
Create a ReportGenerator class with a static method PrintRevenueReport(IEnumerable<Subscriber> subscribers).
• It should iterate through the collection and call CalculateMonthlyBill() polymorphically.
• Bonus: Use a StringBuilder to format a table-style output that includes the specific type of subscriber (Business vs. Consumer).
 
Key Requirements Checklist
Feature
Implementation Detail
Abstraction
Cannot instantiate Subscriber directly.
Polymorphism
CalculateMonthlyBill behaves differently for Business vs. Consumer.
Equality
myDict.ContainsKey(newID) works based on GUID, not reference.
Sorting
Use List<KeyValuePair<string, Subscriber>> or LINQ to order the dictionary.
Reporting
Output must be sorted by the calculated bill amount.
Suggested Math for Billing
To keep it interesting, use these formulas in your overrides:
• Business:
{Total} = {FixedRate} \times (1 + \text{TaxRate})
• Consumer:
{Total} = {DataUsageGB} \times \text{PricePerGB}
 
 