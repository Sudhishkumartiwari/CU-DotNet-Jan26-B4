Assignment: The "ClearDebt" Loan Calculator

Objective: Create a form where a user enters a loan amount, interest rate, and tenure. The script must then generate a full table showing the breakdown of every EMI.
1. The HTML Structure
You will need inputs for the three main variables Amount, Rate, Months in a Form
and a <tbody> where your JavaScript will "inject" the rows.

<table border="1">
    <thead>
        <tr>
            <th>SNO</th>
            <th>Loan Left</th>
            <th>EMI</th>
            <th>Principal</th>
            <th>Interest</th>
            <th>Remaining Balance</th>
        </tr>
    </thead>
    <tbody id="scheduleBody">
        </tbody>
</table>

2. The Math (Logic)
To calculate the fixed Monthly Installment (EMI), use the standard formula:
EMI = P \times r \times \frac{(1 + r)^n}{((1 + r)^n - 1)}
P = Principal (Loan Amount)
r = Monthly Interest Rate (Annual Rate / 12 / 100)
n = Number of months

3. The JavaScript Tasks
Task A: Data Retrieval & Conversion
Use parseFloat() to grab the values. Convert the Annual % into a Monthly Decimal.
Example: 8.5% annual becomes 0.085 / 12 = 0.007083 monthly.

Task B: The EMI Calculation
Use Math.pow() to handle the exponents in the formula above.
Task C: The Amortization Loop
Create a for loop that runs from 1 to months. Inside the loop:
Calculate Interest: CurrentBalance \times MonthlyRate.
Calculate Principal: EMI - Interest.
Update Balance: CurrentBalance - PrincipalPaid.
Format: Use .toFixed(2) for all currency displays.
