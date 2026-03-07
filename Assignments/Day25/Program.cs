namespace TwentyFive{
    class Program{
        public static void Main(string[] args){
            int i = 4;
            string Pin = string.Empty;
            string e = string.Empty;
            while(i > 0){
                ConsoleKeyInfo c = Console.Readkey(true);

                if(c.Key != ConsoleKey.Backspace){
                    pin += c.KeyChar;
                    e += '*';
                }
                else{
                    pin = pin.Remove(pin.Length -1);
                    e = e.Remove(e.Length -1);
                    i = i+2;
                }
                Console.Clear();
                Console.Write(e);
                i--;
            }
            Console.WriteLine();
            Console.WriteLine(pin);
        }
    }
}