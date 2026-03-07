
namespace One
{
    class Patient
    {
        public string? Name {get;set;}
        public decimal BaseFee {get;set;}

        public Patient(string name, decimal baseFee)
        {
            Name = name;
            BaseFee = baseFee;
        }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class Inpatient : Patient
    {
        public int DaysStayed {get;set;}
        public decimal DailyRate {get;set;}

        public Inpatient(string name, decimal baseFee, int daysStayed,decimal dailyRate) : base(name, baseFee)
        {
            DaysStayed = daysStayed;
            DailyRate = dailyRate;
        }

        public override decimal CalculateFinalBill()
        {
            decimal Total = BaseFee + (DaysStayed * DailyRate);
            return Total;
        }
    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee {get;set;}

        public Outpatient(string name, decimal baseFee, decimal procedureFee) : base(name, baseFee)
        {
            ProcedureFee = procedureFee;
        }

        public override decimal CalculateFinalBill()
        {
            decimal Total = BaseFee + ProcedureFee;
            return Total;
        }

    }
    class EmergencyPatient : Patient
    {
            
        public int SeverityLevel {get;set;}

        public EmergencyPatient(string name, decimal baseFee, int severityLevel) : base(name, baseFee)
        {
            SeverityLevel = severityLevel;
        }

        public override decimal CalculateFinalBill()
        {
            decimal Total = BaseFee * SeverityLevel;
            return Total;
        }
    }
    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public void GenerateDailyReport()
        {
            Console.WriteLine("\n--- Daily Billing Report ---");
            foreach (var p in patients)
            {
                Console.WriteLine($"Patient: {p.Name,-15} | Bill: {p.CalculateFinalBill():C}");
            }
        }

        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (var p in patients)
            {
                total += p.CalculateFinalBill();
            }
            return total;
        }

        public int GetInpatientCount()
        {
            int count = 0;
            foreach (var p in patients)
            {
                if (p is Inpatient)
                {
                    count++;
                }
            }
            return count;
        }

    }
    internal class Demi
    {
        public static void Main(string[] args)
        {
            HospitalBilling hospital = new HospitalBilling();

            hospital.AddPatient(new Inpatient("Hritik Singh", 800, 3, 200));
            hospital.AddPatient(new Outpatient("Kriti", 800, 150));
            hospital.AddPatient(new EmergencyPatient("Hitesh", 800, 4));

            hospital.AddPatient(new Inpatient("Sourabh Singh", 800, 2, 200));
            hospital.AddPatient(new Inpatient("Ashmit Singh", 800, 5, 200));


            hospital.GenerateDailyReport();

            Console.WriteLine($"\nTotal Revenue: {hospital.CalculateTotalRevenue():C}");
            Console.WriteLine($"Total Inpatients: {hospital.GetInpatientCount()}");
        }
    }
}

