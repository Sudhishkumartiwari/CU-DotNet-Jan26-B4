🚩 Challenge: "The Legacy Employee Directory"
You are tasked with maintaining a legacy system for a company. Because this is an older system, you are required to use System.Collections.Hashtable instead of the modern Dictionary<TKey, TValue>.
Assignment Tasks
1. Data Entry
Create a Hashtable named employeeTable. Add the following data where the Employee ID (int) is the Key and the Employee Name (string) is the Value:
• 101: "Alice"
• 102: "Bob"
• 103: "Charlie"
• 104: "Diana"
2. Unique Key Check
Write code to check if ID 105 exists in the table. If it doesn't, add "Edward". If it does, print "ID already exists."
3. Data Retrieval & Boxing
Retrieve the name of employee 102 and store it in a string variable.
Note: Since Hashtable returns an object, you must demonstrate Unboxing/Casting.
4. Iteration
Use a foreach loop to print all records in the format: ID: [Key], Name: [Value].
Hint: You must use the DictionaryEntry type to iterate through a Hashtable.
5. Deletion
Remove employee 103 from the table and print the total count of remaining employees.
 