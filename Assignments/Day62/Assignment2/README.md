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


 --> DTOs implemented.

<img width="1062" height="806" alt="Screenshot 2026-03-20 at 12 47 41 PM" src="https://github.com/user-attachments/assets/8075fcdf-53d5-41c7-9a63-8df7a9ed5a76" />
<img width="1057" height="762" alt="Screenshot 2026-03-20 at 12 47 58 PM" src="https://github.com/user-attachments/assets/41d38420-f527-4809-9fcd-79e1af45c7f9" />
<img width="1057" height="800" alt="Screenshot 2026-03-20 at 12 48 50 PM" src="https://github.com/user-attachments/assets/6d6f106b-bdfa-4871-83c9-ca9af7134964" />
<img width="1054" height="759" alt="Screenshot 2026-03-20 at 12 49 12 PM" src="https://github.com/user-attachments/assets/180afc10-1886-429c-9586-1b7a4585d6a8" />

