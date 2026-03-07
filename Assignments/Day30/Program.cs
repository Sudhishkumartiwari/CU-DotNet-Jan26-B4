
namespace ExpenseSplitter
{
    class Friend
    {
        public string Name { get; set; }
        public decimal Expenditure { get; set; }

        public decimal Diff { get; set; }

        public Friend() { }
        public Friend(string name, decimal expenditure)
        {
            Name = name;
            Expenditure = expenditure;
        }
    }

    class Trip
    {
        public decimal Budget { get; set; }
        public decimal Average { get; set; }

        public List<Friend> friends = new List<Friend>();

        public void EnterFriend()
        {
            Console.WriteLine("Add your Friends Name and Budget like Hritik,10000");
            Console.WriteLine("Enter STOP to stop Entering");

            string check = string.Empty;

            while (true)
            {
                check = Console.ReadLine();
                if (check == "STOP") break;

                string[] input = check.Split(',');

                friends.Add(new Friend(input[0], decimal.Parse(input[1])));
            }
        }

        public void ShowSpend()
        {
            foreach (Friend f in friends)
            {
                string a = string.Empty;
                string print = ($"{f.Name} spent {f.Expenditure}");
                if (f.Diff < 0) a = $" which is {Math.Abs(f.Diff)} LESS than the bugdet ";
                else a = $" which is {Math.Abs(f.Diff)} MORE than the budget ";
                Console.WriteLine(print + a);
            }
        }
        public void ProcessTrip()
        {
            foreach (var friend in friends)
            {
                Budget += friend.Expenditure;
            }

            Average = Budget / friends.Count;
        }

        public void CalculateDifference()
        {
            foreach (var friend in friends)
            {
                decimal diff = friend.Expenditure - Average;
                friend.Diff = diff;
            }
        }
        public void GiveMoney()
        {
            friends.Sort(new TripSorter());

            this.CalculateDifference();
            Console.WriteLine();
            this.ShowSpend();
            Console.WriteLine();

            int i = 0;
            int j = friends.Count - 1;

            while (i < j)
            {

                Console.WriteLine();

                var f1 = friends[i];
                var f2 = friends[j];

                decimal pay = 0;

                if (Math.Abs(f1.Diff) < f2.Diff)
                {
                    pay = f1.Diff;
                    f2.Diff += f1.Diff;
                    f1.Diff = 0;
                }
                else if (Math.Abs(f1.Diff) == f2.Diff)
                {
                    pay = Math.Abs(f1.Diff);
                    f2.Diff = 0;
                    f1.Diff = 0;
                    
                }
                else
                {
                    pay = f2.Diff;
                    f1.Diff += f2.Diff;
                    f2.Diff = 0;
                }

                if (f2.Diff == 0) j--;
                if (f1.Diff == 0) i++;

                Console.WriteLine($"{f1.Name} pays {Math.Abs(pay)} to {f2.Name}");
            }
        }

    }

    class TripSorter : IComparer<Friend>
    {
        public int Compare(Friend? f1, Friend? f2)
        {
            return f1.Expenditure.CompareTo(f2.Expenditure);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Trip trip = new Trip();

            trip.EnterFriend();

            trip.ProcessTrip();

            Console.WriteLine($"Budget = {trip.Budget} | Average = {trip.Average}");

            trip.GiveMoney();
        }
    }
}