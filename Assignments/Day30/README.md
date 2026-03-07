📋 Problem Statement: Automated Trip Expense Equalizer
Context
When groups of friends or colleagues travel together, expenses are often paid by different individuals at different times. At the end of the trip, the total expenditure must be shared equally among all participants. Manually calculating "who owes whom" becomes complex, especially when multiple people have paid different amounts and others have paid nothing at all.
Objective
Develop a settlement engine that accepts a list of individuals and their total spending, calculates the fair share for each person, and generates a minimal number of transactions to settle all debts.
Functional Requirements
1. Calculate Fair Share: Determine the average expenditure by dividing the total group spend by the number of participants.
2. Identify Balances: * Debtors: Those who spent less than the fair share.
o Creditors: Those who spent more than the fair share.
3. Algorithmic Settlement: Systematically match debtors with creditors. A debtor should pay their remaining balance to a creditor until either the debt is cleared or the creditor is fully reimbursed.
4. Data Export: Output the results in a standardized CSV format (Payer, Receiver, Amount) with currency values rounded to two decimal places for financial accuracy.
 
Example Scenario
Input Data:
• Aman: Paid 900
• Soman: Paid 0
• Kartik: Paid 1290
Calculations:
1. Total Spent: 2190
2. Fair Share (Per Person): $2190 / 3 = 730$
3. Net Balances:
o Aman: +170 (Creditor)
o Soman: -730 (Debtor)
o Kartik: +560 (Creditor)
Expected Output (CSV):
Code snippet
Payer,Receiver,Amount
Soman,Aman,170.00
Soman,Kartik,560.00
  