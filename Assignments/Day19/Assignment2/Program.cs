
namespace ninth
{
    abstract class UtilityBill
    {
        public int ConsumerId {get;set;}
        public string ConsumerName {get;set; }
        public decimal UnitsConsumed {get;set;}
        public decimal RatePerUnit {get;set;}

        public UtilityBill()
        {
            ConsumerId = 0;
            ConsumerName = string.Empty;
            UnitsConsumed = 0;
            RatePerUnit = 0;
        }

        public UtilityBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
        {
            ConsumerId = consumerId;
            ConsumerName = consumerName;
            UnitsConsumed = unitsConsumed;
            RatePerUnit = ratePerUnit;
        }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount * 0.05M;
        }

        public void PrintBill()
        {
            int amount  = (int)CalculateBillAmount();
            int tax = (int) CalculateTax();
            int total = amount + tax;

            Console.WriteLine($"Consumer ID: {ConsumerId}");
            Console.WriteLine($"Consumer Name: {ConsumerName}");
            Console.WriteLine($"Total Units Consumed: {UnitsConsumed}");
            Console.WriteLine($"Total Amount (After Tax): {total}");
        }

    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int consumerId , string consumerName , decimal unitsConsumed, decimal ratePerUnit) :base(consumerId, consumerName , unitsConsumed ,ratePerUnit){}

        public override decimal CalculateBillAmount()
        {
            if(UnitsConsumed > 300)
            {
                decimal billAmount = UnitsConsumed * RatePerUnit;
                decimal surcharge = billAmount * 0.1M;
                return billAmount + surcharge;
            }
            else
            {
                decimal billAmount = UnitsConsumed * RatePerUnit;
                return billAmount;
            }
        }
        public override decimal CalculateTax()
        {
            return base.CalculateTax();
        }
    }

    class WaterBill : UtilityBill
    {
        public WaterBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit) : base(consumerId, consumerName, unitsConsumed, ratePerUnit){}

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount;
        }

        public override decimal CalculateTax()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount * 0.02M;
        }

    }

    class GasBill : UtilityBill
    {
        public GasBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit) : base(consumerId, consumerName, unitsConsumed, ratePerUnit){}
        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            decimal fixedCharge = 150M;
            return billAmount + fixedCharge;
        }
        public override decimal CalculateTax()
        {
            return 0;
        }
    }

    internal class UtilityBillProgram
    {
        public static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>();
            bills.Add(new ElectricityBill(101,"Hritik", 350 , 8));
            bills.Add(new WaterBill(102, "utkarsh" , 200, 5));
            bills.Add(new GasBill(103, "kriti" , 150, 10));

            foreach(var bill in bills)
            {
                bill.PrintBill(); 
                Console.WriteLine("------------------------------");
            }
        }
    }
}
