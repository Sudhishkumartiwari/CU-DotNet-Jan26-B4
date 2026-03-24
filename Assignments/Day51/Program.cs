
namespace StreamBuzz
{
    public class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }

    public class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> topCounts = new Dictionary<string, int>();

            foreach (var creator in records)
            {
                int count = creator.WeeklyLikes.Count(likes => likes >= likeThreshold);

                if (count > 0)
                {
                    topCounts.Add(creator.CreatorName, count);
                }
            }

            return topCounts;
        }

        public double CalculateAverageLikes()
        {
            if (EngagementBoard.Count == 0) return 0;
            return EngagementBoard.SelectMany(c => c.WeeklyLikes).Average();
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 1:
                        
                        Console.WriteLine("Enter Creator Name:");
                        string name = Console.ReadLine();
                        
                        double[] likes = new double[4];
                        Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                        for (int i = 0; i < 4; i++)
                        {
                            likes[i] = double.Parse(Console.ReadLine());
                        }

                        p.RegisterCreator(new CreatorStats { CreatorName = name, WeeklyLikes = likes });
                        Console.WriteLine("Creator registered successfully");
                        break;

                    case 2:
                        
                        Console.WriteLine("Enter like threshold:");
                        double threshold = double.Parse(Console.ReadLine());

                        var topPosts = p.GetTopPostCounts(EngagementBoard, threshold);

                        if (topPosts.Count == 0)
                        {
                            Console.WriteLine("No top-performing posts this week");
                        }
                        else
                        {
                            foreach (var entry in topPosts)
                            {
                                Console.WriteLine($"{entry.Key} - {entry.Value}");
                            }
                        }
                        break;

                    case 3:
                       
                        double avg = p.CalculateAverageLikes();
                        Console.WriteLine($"Overall average weekly likes: {avg}");
                        break;

                    case 4:
                      
                        Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                        running = false;
                        break;
                }
            }
        }
    }
}
