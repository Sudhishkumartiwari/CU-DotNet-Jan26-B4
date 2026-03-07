namespace TwentySeven_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string directory = @"..\..\..\";

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("directory not found");
                return;
            }

            string file1 = "journal.txt";
            string path = directory + file1;

            Console.WriteLine("Please enter your daily reflection:");
            string reflection = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                string? input = Console.ReadLine();
                sw.WriteLine($"{DateTime.Now}: {reflection}");
            }

            Console.WriteLine("Your reflection has been saved to journal.txt");
        }
    }
}