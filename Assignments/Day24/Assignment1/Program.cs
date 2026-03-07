
namespace TwentyFour
{
    class Employee
    {
        public static void Main(string[] args)
        {
            Hashtable h = new Hashtable();
            h.Add(101,"Alice");
            h.Add(102,"Bob");
            h.Add(103,"Charlie");
            h.Add(104,"Diana");

            if (!h.ContainsKey(105))
            {
                h.Add(105,"Edward");
            }
            else
            {
                Console.WriteLine("105 key Already Existed.");
            }

            foreach(DictionaryEntry item in h)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }

            string emp = (string)h[102];
            Console.WriteLine($"102 emplyee name is: {emp}");
            Console.WriteLine(h.Count);

            h.Remove(103);
            Console.WriteLine("After Deletion of 103");

            foreach(DictionaryEntry item in h)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }

        }
    }
} 
