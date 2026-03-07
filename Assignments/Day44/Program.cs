
namespace SAASArch
{
    abstract class Subscriber : IComparable<Subscriber>
    {
        public int GuidID { get; set; }
        public string Name { get; set; }
        public DateOnly JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        public override int GetHashCode() => GuidID;

        public override bool Equals(object? obj)
        {
            var a = obj as Subscriber;
            return this.GuidID == a.GuidID;
        }

        public int CompareTo(Subscriber other)
        {
            int a = this.JoinDate.CompareTo(other.JoinDate);
            if (a == 0) a = this.Name.CompareTo(other.Name);
            return a;
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill() => FixedRate * (1 + TaxRate);
    }
    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill() => DataUsageGB * PricePerGB;
    }

    class ReportGenerator
    {
        internal static string PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var subscriber in subscribers)
            {
                sb.Append($"Name = {subscriber.Name}\nJoinDate = {subscriber.JoinDate}\nType = {subscriber.GetType().ToString().Substring(9)}\nMonthlyBill = {subscriber.CalculateMonthlyBill()}\n");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscriber = new Dictionary<string, Subscriber>();

            subscriber.Add("aaroh@gmail.com"
                , new ConsumerSubscriber
                {
                    GuidID = 2,
                    Name = "Aaroh",
                    JoinDate = new DateOnly(2026, 01, 01),
                    DataUsageGB = 100,
                    PricePerGB = 10
                });

            subscriber.Add("Mayank@gmail.com"
                , new ConsumerSubscriber
                {
                    GuidID = 1,
                    Name = "Mayank",
                    JoinDate = new DateOnly(2025, 12, 5),
                    DataUsageGB = 50,
                    PricePerGB = 10
                });

            subscriber.Add("Sahil@gmail.com"
                , new BusinessSubscriber
                {
                    GuidID = 3,
                    Name = "Sahil Ltd.",
                    JoinDate = new DateOnly(2025, 6, 18),
                    FixedRate = 1000,
                    TaxRate = 10
                });

            subscriber.Add("Tushar@gmail.com"
                , new BusinessSubscriber
                {
                    GuidID = 5,
                    Name = "Tushar Ltd.",
                    JoinDate = new DateOnly(2025,8,19),
                    FixedRate = 10000,
                    TaxRate = 15
                });
            subscriber.Add("Hritik@gmail.com"
                , new BusinessSubscriber
                {
                    GuidID = 3,
                    Name = "Hritk Ltd.",
                    JoinDate = new DateOnly(2025,12,5),
                    FixedRate = 10000,
                    TaxRate = 15
                });

            var list  = subscriber.Values.OrderByDescending(x=>x.CalculateMonthlyBill()).ToList();

            Console.WriteLine(ReportGenerator.PrintRevenueReport(list));

        }
    }
}