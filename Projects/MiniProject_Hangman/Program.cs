
namespace Hangman_Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] words = ["SYSTEM","photo","Hritik","photosynthesis","apple"];
            Random r = new Random();
            string SecretWord = words[r.Next(words.Length)].ToUpper();
            char[] Display = new string('_', SecretWord.Length).ToCharArray();
            int Leave = 6;
            List<int> UsedLetters = new List<int>();

            while(Leave > 0 & new string(Display).Contains('_'))
            {
                Console.WriteLine($"Word : {string.Join(" ",Display)}");
                Console.WriteLine($"Guess : {Leave}");
                Console.WriteLine($"Used Letters : {string.Join(",",UsedLetters)}");
                Console.WriteLine("Guess a letter");

                string input = Console.ReadLine().ToUpper();
                if(string.IsNullOrEmpty(input) || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Invalid Value");
                    continue;
                }

                char guess = input[0];
                UsedLetters.Add(guess);

                if (SecretWord.Contains(guess))
                {
                    for(int i=0; i< SecretWord.Length; i++)
                    {
                        if(SecretWord[i] == guess)
                        {
                            Display[i] = guess;
                        }
                    }
                }
                else
                {
                    Leave--;
                    Console.WriteLine("Wrong Guess");
                }
            }

            if(!new string(Display).Contains('_')){
               Console.WriteLine($"Congrats You Have Won. Word is :{SecretWord}");
            }
            else{   
            Console.WriteLine($"Out of Options . The Word was : {SecretWord}");
            }   
        }
    }
}    