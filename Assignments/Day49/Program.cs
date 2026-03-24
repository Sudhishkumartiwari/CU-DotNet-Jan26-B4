
namespace CollegeManagement
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();
        
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();
        
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        public void AddStudent(string studentId, string subject, int marks)
        {

            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }
            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!studentRecords[studentId].ContainsKey(subject))
            {
                studentRecords[studentId][subject] = marks;
                subjectsRecords[subject][studentId] = marks;
                
                var entry = new KeyValuePair<string, int>(subject, marks);
                studentSubjectsOrder[studentId].AddLast(entry);
                
                var subEntry = new KeyValuePair<string, int>(studentId, marks);
                subjectsStudentsOrder[subject].AddLast(subEntry);
            }

            else if (marks > studentRecords[studentId][subject])
            {
                studentRecords[studentId][subject] = marks;
                subjectsRecords[subject][studentId] = marks;

                UpdateLinkedList(studentSubjectsOrder[studentId], subject, marks);
                UpdateLinkedList(subjectsStudentsOrder[subject], studentId, marks);
            }
        }

        private void UpdateLinkedList(LinkedList<KeyValuePair<string, int>> list, string key, int newValue)
        {
            var current = list.First;
            while (current != null)
            {
                if (current.Value.Key == key)
                {
                    current.Value = new KeyValuePair<string, int>(key, newValue);
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId)) return;

            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);
                RemoveFromLinkedList(subjectsStudentsOrder[subject], studentId);
            }

            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);
        }

        private void RemoveFromLinkedList(LinkedList<KeyValuePair<string, int>> list, string key)
        {
            var current = list.First;
            while (current != null)
            {
                if (current.Value.Key == key)
                {
                    list.Remove(current);
                    return;
                }
                current = current.Next;
            }
        }

        public string TopStudent(string subject)
        {
            if (!subjectsRecords.ContainsKey(subject) || subjectsRecords[subject].Count == 0)
                return "";

            int maxMarks = subjectsRecords[subject].Values.Max();
            List<string> results = new List<string>();

            foreach (var pair in subjectsStudentsOrder[subject])
            {
                if (pair.Value == maxMarks)
                {
                    results.Add($"{pair.Key} {pair.Value}");
                }
            }
            return string.Join("\n", results);
        }

        public string Result()
        {
            var results = new List<string>();
            var sortedKeys = studentRecords.Keys.OrderBy(k => k);

            foreach (var studentId in sortedKeys)
            {
                double avg = studentRecords[studentId].Values.Average();
                results.Add($"{studentId} {avg:F2}");
            }
            return string.Join("\n", results);
        }
    }

    public class Program
    {
        public static void Main()
        {
            CollageManagement cm = new CollageManagement();
            cm.AddStudent("S1", "Math", 80);
            cm.AddStudent("S2", "Math", 90);
            cm.AddStudent("S3", "Math", 90);
            cm.AddStudent("S1", "Phy", 90);

            Console.WriteLine(cm.TopStudent("Math"));
            Console.WriteLine(cm.Result());
        }
    }
}
