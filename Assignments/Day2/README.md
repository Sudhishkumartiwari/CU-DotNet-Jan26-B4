.NET 8 / C# 12 – Detailed Case Study Exercises
Value Types & Type Conversions
These case-study exercises are intentionally detailed to encourage analytical thinking. Students are
expected to identify appropriate value data types, apply implicit and explicit conversions, handle
precision, overflow, rounding, and justify their design decisions using C# 12 and .NET 8 standards.
Exercise 1: Student Attendance & Eligibility System
A college tracks attendance for each subject. Attendance is captured daily as integers.
At the end of the semester, attendance percentage is calculated as a double.
University rules state that eligibility must be displayed as an integer percentage.
Design logic to:
• Store raw attendance data
• Calculate percentage
• Convert the value safely for display
• Explain rounding vs truncation impact
Exercise 2: Online Examination Result Processing
An online exam system stores marks per subject as int.
The final average must be shown with two decimal places.
Later, scholarship eligibility requires converting the average into an int.
Design the conversion flow and explain precision loss scenarios.
Exercise 3: Library Fine Calculation System
Fine per day is configured as decimal.
Days overdue are stored as int.
Total fine must be displayed as decimal but logged as double for analytics.
Explain why different types are used and how conversions occur.
Exercise 4: Banking Interest Calculation Module
Account balance is decimal.
Interest rate is float from an external API.
Monthly interest is calculated and added to balance.
Demonstrate safe conversions and explain why implicit conversion may fail.
Exercise 5: E-Commerce Order Pricing Engine
Cart total is accumulated using double.
Tax and discount rules require decimal.
Final payable amount is stored as decimal.
Explain conversion strategy and precision risks.
Exercise 6: Weather Monitoring & Reporting
Temperature sensors send readings as short.
Values must be converted to Celsius and stored as double.
Daily average is converted to int for dashboard display.
Discuss overflow and casting concerns.
Exercise 7: University Grading Engine
Final score is calculated as double.
Grades are stored as byte values.
Design logic to convert score to grade safely.
Explain validation and casting choices.
Exercise 8: Mobile Data Usage Tracker
Usage is tracked in bytes as long.
Displayed in MB and GB as double.
Monthly summary rounds values to nearest integer.
Explain implicit conversions and rounding methods.
Exercise 9: Warehouse Inventory Capacity Control
Item count stored as int.
Maximum capacity stored as ushort.
Conversion required during comparison and reporting.
Explain signed vs unsigned conversion risks.
Exercise 10: Payroll Salary Computation
Basic salary is int.
Allowances and deductions are double.
Net salary stored as decimal.
Design type conversion flow and justify choices.