Assignment: Loan Management Web API
Objective: Create a RESTful API that allows users to apply for loans, view their status, and allows admins to manage loan records.
1. The Data Model (Entities)
You need to create a Loan entity. In EF Core, this will be your "Noun."
Id: (int/Guid) Primary Key.
BorrowerName: (string) Name of the applicant.
Amount: (decimal) The loan amount requested.
LoanTermMonths: (int) Duration of the loan.
IsApproved: (bool) Status of the loan.
2. Technical Requirements
Framework: ASP.NET Core 8.0/10.0.
ORM: Entity Framework Core (use SqlServer or Sqlite).
Dependency Injection: Register your DbContext in Program.cs.
Endpoints: Implement GET (all), GET (by ID), POST (create), PUT (update), and DELETE.


![alt text](<images/Screenshot 2026-03-20 at 12.47.41 PM.png>)
![alt text](<images/Screenshot 2026-03-20 at 12.47.58 PM.png>)
![alt text](<images/Screenshot 2026-03-20 at 12.48.50 PM.png>)
![alt text](<images/Screenshot 2026-03-20 at 12.49.12 PM.png>)