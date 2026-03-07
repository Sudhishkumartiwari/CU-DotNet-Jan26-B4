using System;

public class Employee
{
    private int _id;
    
    public void SetId(int id)
    {
        _id = id;
    }
    
    public int GetId()
    {
        return _id;
    }
    public string Name { get; set; }
    private string _department;
    public string Department
    {
        get { return _department; }
        set
        {
            string[] validDepts = { "Accounts", "Sales", "IT" };
            if (validDepts.Contains(value))
            {
                _department = value;
            }
            else
            {
                Console.WriteLine($"Error: {value} is not a valid department.");
            }
        }
    }
    private int _salary;
    public int Salary
    {
        get { return _salary; }
        set
        {
            if (value >= 50000 && value <= 90000)
            {
                _salary = value;
            }
            else
            {
                Console.WriteLine("Error: Salary must be between 50,000 and 90,000.");
            }
        }
    }
    public void Display()
    {
        Console.WriteLine("\n--- Employee Details ---");
        Console.WriteLine($"ID         : {GetId()}");
        Console.WriteLine($"Name       : {Name}");
        Console.WriteLine($"Department : {_department ?? "Not Assigned"}");
        Console.WriteLine($"Salary     : Rs. {_salary}");
        Console.WriteLine("------------------------\n");
    }
}