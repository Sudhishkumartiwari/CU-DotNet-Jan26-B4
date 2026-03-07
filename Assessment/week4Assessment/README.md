Problem Statement: The St. Memorial Billing Engine
Background
You are developing a centralized billing module for a hospital. The hospital treats three types of patients: Inpatients (stay overnight), Outpatients (visit for a procedure), and Emergency patients. Each has a unique way of calculating their final cost.
The Objective
Create a system that processes a List<Patient> and calculates the total revenue for the day. You must use Method Overriding to ensure the correct billing logic is applied to each patient type.
 
1. The Data Model
Define a base class and specialized sub-classes.
• Base Class: Patient
o Properties: Name (string), BaseFee (decimal).
o Method: virtual decimal CalculateFinalBill() (Returns BaseFee).
• Sub-Class: Inpatient
o Properties: DaysStayed (int), DailyRate (decimal).
o Logic: $Total = BaseFee + (DaysStayed \times DailyRate)$.
• Sub-Class: Outpatient
o Properties: ProcedureFee (decimal).
o Logic: $Total = BaseFee + ProcedureFee$.
• Sub-Class: EmergencyPatient
o Properties: SeverityLevel (int 1-5).
o Logic: $Total = BaseFee \times SeverityLevel$.
 
2. Your Tasks
Implement a class HospitalBilling that manages a List<Patient> and includes:
1. AddPatient(Patient p): Adds any patient type to the master list.
2. GenerateDailyReport(): Iterates through the list and prints the Name and the CalculateFinalBill() result for each.
3. CalculateTotalRevenue(): Returns the sum of all bills in the list using a loop.
4. GetInpatientCount(): Uses the is or as keyword to count how many patients in the list are specifically Inpatient objects.
 
3. Expected Logic Flow
 
Mid-Level "Gotchas"
• Property Access: If you are iterating through a List<Patient>, you cannot see DaysStayed unless you cast the object. However, for CalculateFinalBill(), you shouldn't need to cast—that's the power of Polymorphism.
• The override Keyword: Ensure your sub-classes use public override decimal CalculateFinalBill(). If you forget override, the program will use the base class logic instead (Shadowing).
• Readability: Use the C2 format string (e.g., bill.ToString("C2")) to print the results as currency.
 