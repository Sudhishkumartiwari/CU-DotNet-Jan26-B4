Insurance Premium Summary System
 
Objective
Develop a .NET Console Application that captures basic insurance policy data for a small set of customers, processes the data using value types and strings, and displays a formatted insurance summary report.
 
Business Scenario
An insurance company wants to review annual premium details of its customers for quick verification.
 
Data Design (Must Follow)
Use only these two arrays:
1. string[] policyHolderNames
2. decimal[] annualPremiums
Other values must be stored using individual variables, not arrays.
 
Functional Requirements
1. Input
• Accept details for 5 policyholders
• For each policyholder:
o Name (string)
o Annual premium amount (decimal)
• Validation:
o Name cannot be empty
o Premium must be greater than 0
• the user should be required to re-enter the value until it is correct.
 
2. Processing (Value Types)
Using loops and value-type variables, calculate:
• Total premium amount
• Average premium
• Highest premium
• Lowest premium
 
3. String Operations
• Display all policyholder names in uppercase
• Display premium category:
o "LOW" → Premium < 10,000
o "MEDIUM" → Premium between 10,000 and 25,000
o "HIGH" → Premium > 25,000
(Category must be decided using if/else, not arrays.)
 
4. Formatted Output
Display the report in the following format (ignore colors):
 

Formatting Rules:
• Align columns properly
• Display premium values with two decimal places
• Use clear headings
 