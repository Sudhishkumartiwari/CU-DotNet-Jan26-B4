Case Study: Employee Compensation Management System
An organization is developing a compensation calculation module for different categories of employees. All employees share common details, but salary computation rules differ based on employee type. Due to architectural constraints, the design must not use abstract classes or virtual methods.
 
Functional Requirements
1. Base Class: Employee
Create a base class named Employee.
Properties
• EmployeeId (int)
• EmployeeName (string)
• BasicSalary (decimal)
• ExperienceInYears (int)
Constructor
• Initialize all properties using a parameterized constructor.
Methods
• CalculateAnnualSalary()
o Calculates annual salary using:
o Annual Salary = BasicSalary × 12
• DisplayEmployeeDetails()
o Displays employee details and annual salary
Important: These methods must not be marked virtual.
 
2. Derived Class: PermanentEmployee
Create a class PermanentEmployee that inherits from Employee.
Business Rules
• House Rent Allowance (HRA): 20% of BasicSalary
• Special Allowance: 10% of BasicSalary
• Loyalty Bonus:
o ₹50,000 if experience ≥ 5 years
Method Implementation
• Implement method hiding:
• public new decimal CalculateAnnualSalary()
• Include allowances and bonus in the annual salary
 
3. Derived Class: ContractEmployee
Create a class ContractEmployee that inherits from Employee.
Additional Property
• ContractDurationInMonths (int)
Business Rules
• No allowances
• Contract completion bonus:
o ₹30,000 if duration ≥ 12 months
Method Implementation
• Implement:
• public new decimal CalculateAnnualSalary()
 
4. Derived Class: InternEmployee
Create a class InternEmployee that inherits from Employee.
Business Rules
• Fixed stipend
• No bonus or allowance
• Annual salary = BasicSalary × 12
Method Implementation
• Implement:
• public new decimal CalculateAnnualSalary()
 
Usage Instructions
1. Create objects of:
o Employee
o PermanentEmployee
o ContractEmployee
o InternEmployee
2. Call CalculateAnnualSalary() using:
o Base class references
o Derived class references
Example:
Employee emp1 = new PermanentEmployee(...);
PermanentEmployee emp2 = new PermanentEmployee(...);
 
Console.WriteLine(emp1.CalculateAnnualSalary()); // Base method
Console.WriteLine(emp2.CalculateAnnualSalary()); // Derived method
 