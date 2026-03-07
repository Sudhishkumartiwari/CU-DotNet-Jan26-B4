using System;

namespace first
{
  class Program
  {
    static void Main(string[] args)
    {
      Exercise1.Student_attendance();
      Exercise2.ExamResult();
      Exercise3.LibraryFine();
      Exercise4.BankInterest();
      Exercise5.ItemPricing();
      Exercise6.Weather_monitoring();
      Exercise7.University_grades();  
      Exercise8.Data_usage();
      Exercise9.Warehouse_capacity();
      Exercise10.Payroll_salary();
    }
  }
  class  Exercise1 {
    public static void Student_attendance()
    {
      int total_classes = 16;
      int class_attended = 9;
      double attendance_percent = (double)class_attended/total_classes * 100;
      int display_percent = (int)attendance_percent;
      Console.WriteLine($"Attendence (Without Truncate): {attendance_percent}%");
      Console.WriteLine($"Attendence percentage: {display_percent}%");
      // Truncation removes the decimal part.
      // Math.Round would round to nearest whole number.
    }
  }
  class Exercise2
  {
    public static void ExamResult()
    {
      int Physics = 52 , Chemistry = 53 , Mathematics = 60 ;
      double average_marks = (double)(Physics + Chemistry + Mathematics) / 3;
      int ScholarshipScore = (int)average_marks;
      Console.WriteLine($"Average Marks (Without Truncate): {average_marks}");
      Console.WriteLine($"Scholarship Score: {ScholarshipScore}");
      // In this exercise double to int conversion truncates the decimal part.
      // Converting decimal to double may introduce minor precision loss
    }
  }
  class Exercise3
  {
    public static void LibraryFine()
    {
      decimal fine_per_day = 7.5m;
      int Day_overdue = 10;
      decimal total_fine = fine_per_day * Day_overdue;
      double logged_due = (double)total_fine;
      Console.WriteLine($"Total Fine (In decimal): {total_fine}");
      Console.WriteLine($"Logged Fine (double): {logged_due}");
      // Decimal is used for precise calculations
      // Double is used for logging where extreme precision is not critical
      // Converting decimal to double may introduce minor precision loss
    }
  }
  class Exercise4
  {
    public static void BankInterest()
    {
      decimal balance = 1500.75m;
      float interest_rate = 4.3f;
      decimal Monthly_interest = balance * (decimal)interest_rate ;
      balance += Monthly_interest;
      Console.WriteLine($"Monthly Interest: {Monthly_interest}");
      Console.WriteLine($"New Balance: {balance}");
      // Converting float to decimal may introduce minor precision loss
      // Implicit conversion from float to decimal is not allowed due to potential precision loss
      // hence explicit conversion is used
    }
  }
  class Exercise5
  {
    public static void ItemPricing()
    {
      double cart_Total = 99.99;
      decimal tax_Rate = 0.08m;
      decimal final_Payable = (decimal)cart_Total + ((decimal)cart_Total * tax_Rate);
      Console.WriteLine($"Final Payable: {final_Payable}");
      //explain conversion strategy and presision risk
      // Converting double to decimal may introduce minor precision loss
      // Decimal is used for precise financial calculations
      // Double is used for general calculations where extreme precision is not critical
      // Therefore, careful conversion is necessary to balance precision and performance
    }
  }
  class  Exercise6 {
    public static void Weather_monitoring()
    {
      short rawReading = 1040; 
      double celsius = (rawReading - 320) / 1.8 / 10; 
      int displayTemp = (int)celsius;
      Console.WriteLine($"Precise Temp: {celsius}°C");
      Console.WriteLine($"Dashboard Display: {displayTemp}°C");
      // Converting double to int truncates the decimal part
      // Ensure that the rawReading value is within a reasonable range to prevent overflow
      // when performing calculations that could exceed the limits of the data types used
      // In this case, the calculations are safe within the expected range of temperature readings thus no overflow occurs.
    }
  }
  class Exercise7
  {
    public static void University_grades()
    {
      double finalScore = 92.58;
      byte gradeValue;
      if (finalScore >= 0 && finalScore <= 255) {
        gradeValue = (byte)finalScore;
        Console.WriteLine($"Grade stored as byte: {gradeValue}");
      }
      // Converting double to byte truncates the decimal part
      // Validation ensures the finalScore is within the byte range (0-255) 
      // to prevent overflow during conversion
      // If finalScore exceeds this range, an exception would occur during casting
      // So, validation is nessessary before performing the conversion
    }
  }
  class Exercise8
  {
    public static void Data_usage()
    {
      long bytesUsed = 2147483648L;
      double gigabytes = bytesUsed / 1024.0 / 1024.0 / 1024.0;
      int roundedSummary = (int)Math.Round(gigabytes);
      Console.WriteLine($"Usage: {gigabytes:F2} GB");
      Console.WriteLine($"Monthly Summary: {roundedSummary} GB");
      // Implicit conversion from long to double is safe as double can represent large integers accurately
      // Rounding is done using Math.Round to get the nearest whole number for summary display
      // Converting double to int truncates the decimal part, so rounding is applied first to get a more accurate summary
    }
  }
  class Exercise9
  {
    public static void Warehouse_capacity()
    {
      int currentItems = 5000;
      ushort maxCapacity = 10000;
      if (currentItems > (int)maxCapacity)
      {
         Console.WriteLine("Capacity Exceeded!");
      }
      else {
         Console.WriteLine($"Space remaining: {maxCapacity - currentItems}");
      }
      // Converting ushort to int is safe as int can represent all values of ushort
      // However, converting int to ushort can lead to overflow if the int value is negative .
    }
  }
  class Exercise10
  {
    public static void Payroll_salary()
    {
      int basicSalary = 50000;
      double allowance = 1500.50;
      double deductions = 200.25;
      decimal netSalary = (decimal)(basicSalary + allowance - deductions);
      Console.WriteLine($"Net Salary: {netSalary}");
      // Type casting is a logical path data takes while moving from one data type to another
      // logical path decides based on 2 factors . 
      // a. size of the data (implicit/explicit)
      // b. precision of the data . 
    }
  }
}

 