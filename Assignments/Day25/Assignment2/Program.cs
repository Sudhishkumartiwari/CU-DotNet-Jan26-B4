
namespace TwentyFive_2{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public decimal StrikeRate { get; set; }
        public decimal Average { get; set; }

        public Player(string name, int runsScored, int ballsFaced, bool isOut)
        {
            try
            {
                Name = name;
                RunsScored = runsScored;
                BallsFaced = ballsFaced;
                IsOut = isOut;
                StrikeRate = ((decimal)RunsScored / (decimal)BallsFaced) * 100;
                Average = RunsScored;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divide by zero");
            }
        }

        public override string ToString()
        {
            return $"{Name,-10} {RunsScored} {StrikeRate:F2} {Average}";
        }
    }

    class StrikeRateSorter : IComparer<Player>
    {
        public int Compare(Player? p1,Player? p2)
        {
            return p1.StrikeRate.CompareTo(p2.StrikeRate);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filepath = @"..\..\..\player.csv";

                using StreamReader sr = new StreamReader(new FileStream(filepath, FileMode.Open));

                //string[] arr1 = sr.ReadLine().Split(',');

                //string[] arr2 = sr.ReadLine().Split(',');

                //string[] arr3 = sr.ReadLine().Split(',');

                List<string[]> arr = new List<string[]>();

                string? check = sr.ReadLine();

                while (check != null)
                {
                    arr.Add(check.Split(','));
                    check = sr.ReadLine();
                }

                List<Player> list = new List<Player>();

                foreach(var c in  arr)
                {
                    list.Add(new Player(c[0], int.Parse(c[1]), int.Parse(c[2]), bool.Parse(c[3])));
                }
                
                list.Sort(new StrikeRateSorter());
                list.Reverse();

                Console.WriteLine($"{"Name",-10} Runs SR Avg");
                Console.WriteLine();
                foreach(Player p  in list)
                {
                    if(p.BallsFaced>10) Console.WriteLine(p);
                }
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File does not exist");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Wrong Format");
            }
        }
    }
}
