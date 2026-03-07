Exception Handling in .NET (Built-in & Custom)
🎯 Objective
Students must demonstrate understanding of:
• Common built-in exceptions in .NET
• Creating and using custom exceptions
• Try–catch–finally
• InnerException and exception propagation
🧩 Problem Statement
You are developing a Student Enrollment System.
The system must validate student data and handle runtime errors using built-in and custom exceptions.
 
📌 Part 1 – Built-in Exception Handling
🔹 Task 1
Create a console application that performs the following operations and handles exceptions:
1. Divide two numbers entered by the user
o Handle DivideByZeroException
2. Convert user input to integer
o Handle FormatException
3. Access an array index entered by the user
o Handle IndexOutOfRangeException
 
🧪 Sample Requirements
• Use separate try-catch blocks for each scenario
• Display meaningful error messages
• Use finally block to print: "Operation Completed"
 
📌 Part 2 – Custom Exception
🔹 Task 2: Create a Custom Exception
Create a custom exception class InvalidStudentAgeException.
Student Age must be between 18 and 60
Get age from user until correct input is given.
 
Also create InvalidStudentNameException
 
📌 Part 3 – InnerException Demonstration
🔹 Task 4
Wrap the custom exception inside another exception:
Print:
• Exception Message
• InnerException Message
📌 Part 4 – Logging Exception Details
🔹 Task 5
Print the following Exception properties:
• Message
• StackTrace
• InnerException