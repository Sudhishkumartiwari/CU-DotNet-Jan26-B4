using System;

class Program
{
    static void Main()
    {
       
        // Exercise 1: Student Attendance
        int attended = 68;
        int totalClasses = 90;

        // int is converted to double automatically (IMPLICIT)
        double percentage = (attended * 100.0) / totalClasses;

        // Math.Round() is used to round the value
        // double to int needs EXPLICIT conversion
        int finalPercentage = (int)Math.Round(percentage);

        Console.WriteLine("Attendance Percentage = " + finalPercentage);

    
        // Exercise 2: Online Exam Result
  
        int sub1 = 78, sub2 = 82, sub3 = 91;

        // int to double is IMPLICIT
        double average = (sub1 + sub2 + sub3) / 3.0;

        // rounding is done before converting to int
        double roundedAverage = Math.Round(average, 2);
        int scholarshipMarks = (int)Math.Round(average);

        Console.WriteLine("Average Marks = " + roundedAverage);
        Console.WriteLine("Scholarship Marks = " + scholarshipMarks);

       
        // Exercise 3: Library Fine System
        decimal finePerDay = 2.50m;
        int lateDays = 4;

        // int to decimal happens IMPLICITLY
        decimal totalFine = finePerDay * lateDays;

        // decimal to double needs EXPLICIT conversion
        double fineForReport = (double)totalFine;

        Console.WriteLine("Total Fine = " + totalFine);

     
        // Exercise 4: Banking Interest
        decimal balance = 100000m;
        float interestRate = 7.5f;

        // float to decimal must be EXPLICIT
        decimal rate = (decimal)interestRate / 100;

        decimal interest = balance * rate / 12;
        balance = balance + interest;

        Console.WriteLine("Updated Balance = " + balance);

        // Exercise 5: E-Commerce Pricing
        double cartTotal = 1999.99;

        // double to decimal is EXPLICIT (money calculation)
        decimal safeCartTotal = (decimal)cartTotal;

        decimal tax = safeCartTotal * 0.18m;
        decimal finalAmount = safeCartTotal + tax;

        Console.WriteLine("Final Amount = " + finalAmount);

  
        // Exercise 6: Weather Monitoring
        short sensorReading = 320;

        // short to double is IMPLICIT
        double temperature = sensorReading / 10.0;

        // rounding + EXPLICIT conversion
        int displayTemp = (int)Math.Round(temperature);

        Console.WriteLine("Temperature = " + displayTemp + "°C");

        // Exercise 7: University Grading
        double finalScore = 86.4;
        byte grade;

        // grade is decided by logic, no type casting
        if (finalScore >= 90)
            grade = 10;
        else if (finalScore >= 80)
            grade = 9;
        else
            grade = 8;

        Console.WriteLine("Grade = " + grade);

        // Exercise 8: Mobile Data Usage
        long bytesUsed = 5368709120;

        // long to double is IMPLICIT
        double gbUsed = bytesUsed / (1024.0 * 1024 * 1024);

        // rounding + EXPLICIT conversion
        int roundedGB = (int)Math.Round(gbUsed);

        Console.WriteLine("Data Used = " + roundedGB + " GB");

        // Exercise 9: Warehouse Inventory
        int itemCount = 45000;
        ushort maxCapacity = 50000;

        // ushort is converted to int IMPLICITLY during comparison
        if (itemCount <= maxCapacity)
            Console.WriteLine("Stock is within limit");
        else
            Console.WriteLine("Stock exceeded");

     
        // Exercise 10: Payroll Salary
        int basicSalary = 40000;
        double allowance = 12500.75;
        double deduction = 3200.50;

        // int to decimal is IMPLICIT
        // double to decimal is EXPLICIT
        decimal netSalary =
            basicSalary +
            (decimal)allowance -
            (decimal)deduction;

        Console.WriteLine("Net Salary = " + netSalary);
    }
}
