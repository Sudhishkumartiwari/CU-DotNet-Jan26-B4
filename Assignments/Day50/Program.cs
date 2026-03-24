
namespace StudentDictionary
{
    public class Student
    {
        public string StudId { get; set; }
        public string SName { get; set; }

        public Student(string id, string name)
        {
            StudId = id;
            SName = name;
        }
        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return this.StudId == other.StudId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return StudId != null ? StudId.GetHashCode() : 0;
        }
    }

    public class CollageManagement
    {

        private Dictionary<Student, int> record = new Dictionary<Student, int>();

        public void AddOrUpdateStudent(string id, string name, int marks)
        {
            Student newStudent = new Student(id, name);

            if (!record.ContainsKey(newStudent))
            {

                record.Add(newStudent, marks);
                Console.WriteLine($"[ADDED] {name} (ID: {id}) with {marks} marks.");
            }
            else
            {
                int existingMarks = record[newStudent];
                if (marks > existingMarks)
                {
                    record[newStudent] = marks;
                    Console.WriteLine($"[UPDATED] {name} (ID: {id}) improved from {existingMarks} to {marks}.");
                }
                else
                {
                    Console.WriteLine($"[IGNORED] {name} (ID: {id}) already has a higher or equal score of {existingMarks}.");
                }
            }
        }

        public void DisplayLatestData()
        {
            Console.WriteLine("\n--- Latest Student Records ---");
            if (record.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach (var entry in record)
            {
                Console.WriteLine($"Student ID: {entry.Key.StudId} | Name: {entry.Key.SName} | Marks: {entry.Value}");
            }
            Console.WriteLine("------------------------------\n");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CollageManagement college = new CollageManagement();

            college.AddOrUpdateStudent("S101", "Alice", 85);
            college.AddOrUpdateStudent("S102", "Bob", 70);

            college.AddOrUpdateStudent("S101", "Alice", 80);

            college.AddOrUpdateStudent("S102", "Bob", 92);

            college.AddOrUpdateStudent("S103", "Charlie", 88);

            college.DisplayLatestData();
        }
    }
}
