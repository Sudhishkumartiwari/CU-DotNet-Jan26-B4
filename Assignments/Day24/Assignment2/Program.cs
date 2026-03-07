
namespace TwentyFour
{
    class Employee
    {
        public static void Main(string[] args)
        {
            SortedDictionary<double,string> LeaderBoard = new SortedDictionary<double, string>();

            LeaderBoard.Add(55.42,"SwiftRacer");
            LeaderBoard.Add(52.10,"SpeedDemon");
            LeaderBoard.Add(58.91,"SteadyEddie");
            LeaderBoard.Add(51.05,"TurboTom");

            Console.WriteLine(LeaderBoard.Keys.First());
            LeaderBoard.Remove(58.91);

            LeaderBoard.Add(54.00,"SteadyEddie");

            foreach(var item in LeaderBoard)
            {
                Console.WriteLine($"Key: {item.Key,-6} and Value: {item.Value}");
            }

        }
    }
} 
