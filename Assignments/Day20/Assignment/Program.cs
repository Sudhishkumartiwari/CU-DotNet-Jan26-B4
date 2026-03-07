
namespace first
{
    class Flight : IComparable<Flight>
    {
        public string? FlightNumber {get;set;}
        public decimal Price {get;set;}
        public TimeSpan Duration {get;set;}
        public DateTime DepartureTime {get;set;}

        public int CompareTo(Flight? flight)
        {
            return this.Price.CompareTo(flight.Price);
        }

        public override string ToString()
        {
            return $"Flight Number:{FlightNumber}, Price:{Price}, Duration:{Duration}, Departure Time:{DepartureTime}";
        }


    }

    class DurationComparer : IComparer<Flight>
    {
         public int Compare(Flight? f1, Flight? f2)
        {
            return f1.Duration.CompareTo(f2.Duration);
        }

    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? f1, Flight? f2)
        {
            return f1.DepartureTime.CompareTo(f2.DepartureTime);
        }
    }
    
    internal class Demi
    {
        public static void PrintList(List<Flight> fli){
            
            foreach(var v in fli)
            {
                Console.WriteLine(v);
            }
        }
        public static void Main(string[] args)
        {
            List<Flight> fli = new List<Flight>()
            {
               new Flight(){FlightNumber = "BN103", Price =  5000, Duration = new TimeSpan(3,25,45) , DepartureTime = new DateTime(2026,01,28,2,23,5) } ,
               new Flight(){FlightNumber = "ZA103", Price =  2000, Duration = new TimeSpan(1,45,30) , DepartureTime = new DateTime(2026,01,28,14,35,0) } ,
               new Flight(){FlightNumber = "TS103", Price =  3500, Duration = new TimeSpan(3,50,30) , DepartureTime = new DateTime(2026,01,29,1,45,23) } 
            };

            Console.WriteLine("Sorting According to Price");
            fli.Sort();
            PrintList(fli);

            Console.WriteLine("Sorting According to Duration");
            fli.Sort(new DurationComparer());
            PrintList(fli);

            Console.WriteLine("Sorting According to Departure Time");
            DepartureComparer Dep = new DepartureComparer();    
            fli.Sort(Dep);
            PrintList(fli);  

        }
    }
}

