Problem Statement: The "QuickLoan" In-Memory Tracker

Background
QuickLoan Financial Services is a small startup that needs a prototype for a loan management system. Before they invest in a complex database infrastructure, they want a "proof of concept" web application to manage their current lending portfolio.
As the lead developer, your goal is to build a functional CRUD (Create, Read, Update, Delete) application. Since the database is not yet ready, you will manage all data using a Static List in memory.

The Challenge
You are required to build an ASP.NET Core MVC application that manages a Loan entity. The system must allow users to perform all basic data operations through a web interface.

1. The Model (The Blueprint)
Create a Loan class in the Models folder with the following requirements:
Properties: Id (int), BorrowerName (string), LenderName (string), Amount (double), and IsSettled (bool).
Validation: * BorrowerName is required.
Amount must be between 1 and 500,000.
Use Data Annotations to display "Borrower Name" instead of "BorrowerName" on the UI.

2. The Controller (The Logic)
Create a LoanController that simulates a database using a private static List<Loan>. You must implement the following Action Methods:
Index: Display all loans in a table.
Add: A GET action to show the form and a POST action to save the loan to the list.
Edit: A GET action to fetch a loan by ID and a POST action to update its details.
Delete: An action to remove a loan from the list using its ID.

3. The Views (The Interface)
Develop Razor Views using Bootstrap for a professional look:
Index View: Use a HTML table with "Edit" and "Delete" buttons for each row.
Add/Edit Views: Use Tag Helpers (asp-for, asp-validation-for) to create a user-friendly form.
Validation Summary: Ensure that if a user enters an invalid amount, the error message appears without the page crashing.

Requirements & Constraints
No Entity Framework: Do not use DbContext or migrations. Use a static list so data persists as long as the application is running.
Strongly Typed Views: Every view must use the @model directive.
Tag Helpers: Use asp-action and asp-route-id for all links and form submissions.
Post-Redirect-Get: After adding or editing a loan, the user must be redirected back to the Index action.

Success Criteria
Read: Can I see a list of loans when I navigate to /Loan?
Create: Can I add a new loan and see it appear in the table?
Update: Can I change the "Lender Name" of an existing loan?
Delete: Can I remove a loan from the list?
Validation: Does the system stop me if I try to save a loan with a negative amount?