
namespace TwentyThree
{
    class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) :base(message) { }
    }
    class InvalidStudentNameException :Exception
    {
        public InvalidStudentNameException(string message) :base(message) { }
    }
    internal class ExceptionExample
    {
        static void Main(string[] args)
        {
           RunBuiltInDemos();
           ValidateStudent();
           Console.ReadLine(); 
        }
        static void RunBuiltInDemos()
        {
            try
            {
                Console.Write("Enter number to divide: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Enter divisor: ");
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result: {num1 / num2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Please enter numbers only. " + ex.Message);
            }
            finally { Console.WriteLine("Operation Completed."); }

            try
            {
                int[] marks = { 90, 80, 70 };
                Console.Write("\nEnter array index to access (0-2): ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine($"Mark: {marks[index]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index is out of bounds! " + ex.Message);
            }
            finally { Console.WriteLine("Operation Completed."); }
            
        }
        static void ValidateStudent()
        {
            try
            {
                Console.Write("Enter Student name");
                string name = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(name) || int.TryParse(name, out _))
                {
                    throw new InvalidStudentNameException("Student name is Invalid");
                }

                int age;
                while (true)
                {
                    try
                    {
                        Console.Write("Enter Students Age:");
                        age = int.Parse(Console.ReadLine());

                        if(age < 18 || age > 60)
                        {
                            throw new InvalidStudentAgeException("Age must be between 18 and 60.");
                        }
                        break;
                    }
                    catch(InvalidStudentAgeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("Student enrolled Successfully");
            }
            catch (Exception ex)
            {
              Exception wrappedException = new Exception("Student enrollment failed.",ex);

              Console.WriteLine("------Exception Details-------");
              Console.WriteLine("Message: "+ wrappedException.Message);
              Console.WriteLine("Inner Exception: " + wrappedException.InnerException.Message);

            }
            finally
            {
                Console.WriteLine("Operation Completed.");
            }
        }

    }
} 