
namespace VowelManupulation
{
    class RulesForManupulation
    {
        public static void Main(string[] args)
        {

             string s = "hello";
             string vowels = "aeiou";
             StringBuilder result = new StringBuilder();

             foreach(char c in s)
            {
                if (vowels.Contains(c))
                {
                    int index = vowels.IndexOf(c);
                    char nextVowel = vowels[(index + 1) % vowels.Length];
                    result.Append(nextVowel);
                }
                else
                {
                    char nextChar = (char)((c - 'a' + 1) % 26 + 'a');
                    if (vowels.Contains(nextChar))
                    {
                        nextChar = (char)((nextChar - 'a' + 1) % 26 + 'a');
                    }
                    result.Append(nextChar);
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
