Problem Statement: The "SafeDrive" Policy Optimizer
Background
You are a software engineer at SafeDrive Insurance. The company manages thousands of auto insurance policies and needs a high-performance system to handle annual renewals and risk assessments. Management has noted that inflation and changes in driver behavior require a bulk update to their records.
The Objective
Develop a PolicyTracker system that uses a Dictionary to store policy data, where the Key is a unique string Policy ID and the Value is a Policy object. Your system must be able to process financial updates and filter data based on specific criteria without losing data integrity.
Requirements
1. Data Structure
Your Policy object must track:
• HolderName (string)
• Premium (decimal)
• RiskScore (int, 1–100)
• RenewalDate (DateTime)
2. Mandatory Operations
• The "Bulk Adjustment": Implement a method that increases the Premium of all policies by $5\%$ if their RiskScore is above 75.
• The "Clean-Up": Implement a method to remove all policies from the dictionary that have a RenewalDate older than 3 years (to comply with data retention laws).
• The "Security Check": Implement a safe lookup method that retrieves a policy's details by ID. If the ID does not exist, it should return a custom "Not Found" message instead of crashing the program.
 
Constraints & Rules
1. Financial Accuracy: All calculations involving premiums must use the decimal type to avoid floating-point errors.
2. Collection Safety: You cannot modify a dictionary (remove items) while iterating through it using a foreach loop. You must find a workaround (e.g., storing keys to delete in a separate list first).
3. Efficiency: For the lookup operation, ensure you are utilizing the $O(1)$ average time complexity of the Dictionary.
 