namespace first{

    class Employee{
       
       public int EmployeeId {get; set;}
       public string EmployeeName {get; set;}
       public decimal BasicSalary {get;set;}
       public int ExperienceInYears {get;set;}

       public Employee(int employee, string employeeName, decimal basicSalary ,int experienceInYears){

             EmployeeId = employee;
             EmployeeName = employeeName;
             BasicSalary = basicSalary;
             ExperienceInYears = experienceInYears;
       }

       public decimal CalculateAnnualSalary(){
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
       }

       public string DisplayEmployeeDetails(){
           return $"Id:{EmployeeId}, Employee Name:{EmployeeName}, Experience:{ExperienceInYears}, Annual Salary:{CalculateAnnualSalary()}";
       }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int employee, string employeeName, decimal basicSalary ,int experienceInYears)
        : base(employee, employeeName, basicSalary, experienceInYears)
        {}
        public new decimal CalculateAnnualSalary(){
            decimal HRA = BasicSalary * 20/100;
            decimal SpecialAllowance = BasicSalary * 10/100;
            decimal Bonus = 0;
            if(ExperienceInYears >= 5){Bonus = 50000;}
            decimal AnnualSalary = (BasicSalary * 12) +  HRA + SpecialAllowance + Bonus;

            return AnnualSalary;
        }

    }

    class ContractEmployee : Employee
    {
        
        public int ContractDurationInMonths {get;set;}
        public ContractEmployee(int employee, string employeeName, decimal basicSalary ,int experienceInYears, int contractDurationInMonths)
        : base(employee, employeeName, basicSalary, experienceInYears)
        {
            ContractDurationInMonths = contractDurationInMonths;
        }

        public new decimal CalculateAnnualSalary(){
            decimal Bonus = 0;
            if(ContractDurationInMonths >= 12) {Bonus = 30000;}
            decimal AnnualSalary = (BasicSalary * 12) + Bonus;
            return AnnualSalary;
        }
    }

    class InternEmployee : Employee 
    {
        public InternEmployee(int employee, string employeeName, decimal basicSalary ,int experienceInYears)
        : base(employee, employeeName, basicSalary, experienceInYears)
        {}
        public new decimal CalculateAnnualSalary(){
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }
    }

    internal class AnnualSalary{

        public static void Main(string[] args){
            
            Employee e1 = new Employee(14479, "Hritik" , 50000 , 3);
            PermanentEmployee p1 = new PermanentEmployee(13325 , "Utkarsh" , 7000 , 6);
            ContractEmployee c1 = new ContractEmployee(14603, "kriti", 40000 , 7, 15);
            InternEmployee i1 = new InternEmployee(14448, "Ankit", 20000, 1);
            Console.WriteLine(e1.CalculateAnnualSalary());
            Console.WriteLine(p1.CalculateAnnualSalary());
            Console.WriteLine(c1.CalculateAnnualSalary());  
            Console.WriteLine(i1.CalculateAnnualSalary());
        }
    }
}
