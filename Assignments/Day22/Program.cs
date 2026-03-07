
namespace Two
{
    class Driver
    {
        private static int count = 100;
        public int  Id {get;set;}
        public string? Name {get;set;}
        public string? VehicleNo {get;set;}

        public List<Ride> Rides {get; set;}

        public Driver(string name, string vechicleNo , List<Ride> rides)
        {
            Id = ++count;
            Name = name;
            VehicleNo = vechicleNo;
            Rides = rides;
        }

        public void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }

        public override string ToString()
        {
           string a = $"Driver ID: {Id} | Name: {Name} | Vehicle: {VehicleNo}\n";
            a += "Rides Taken:\n";
            
            decimal totalfare = 0;
            foreach (var i in Rides)
            {
                a += "  - " + i.ToString() + "\n";
                totalfare += i.Fare;
            }
            return $"{a}Total Fare Collected: {totalfare:C}";
        }
        

    }

    class Ride
    {
        public int RideID {get;set;}
        public string? From {get;set;}
        public string? To {get;set;}
        public decimal Fare {get;set;}

        public Ride(int rideID, string from, string to, decimal fare){

             RideID = rideID;
             From = from;
             To = to;
             Fare = fare;
        }

        public override string ToString()
        {
            return $"RideId:{RideID} From:{From} To:{To} Fare:{Fare:C}";
        }
    }

    internal class Demi
    {
        public static void Main(string[] args)
        {
           List<Driver> D = new List<Driver>();
           for(int i=1; i < 5; i++)
            {
                string[] cities = {"IXR","CHD","BSB","HZB","NLSD"};
                string[] letters = {"ABC","NBC","UDM","CNB","UTL"};
                string[] names = {"Jack","Hud","Gray","Ma","Wil","Car"};
        
                Random r = new Random();

                string RandomVechicleNo = $"{letters[r.Next(letters.Length)]}-{r.Next(100,999)}";
                string DriverName = names[r.Next(names.Length)];

                List<Ride> R = new List<Ride>();
                for(int j = 1 ; j<4 ; j++)
                {
                    string RandomFrom = cities[r.Next(cities.Length)];
                    string RandomTo = cities[r.Next(cities.Length)];

                    if(RandomFrom == RandomTo) {
                        RandomTo = cities[r.Next(cities.Length)];
                    }

                    decimal RandomFare = (decimal)r.Next(100,1000);

                    R.Add(
                        new Ride(
                            j,
                            RandomFrom,
                            RandomTo,
                            RandomFare
                        )
                    );
                }

                D.Add(
                    new Driver(
                        $"{DriverName}son",
                        RandomVechicleNo,
                        R
                    )
                );

            }

            Console.WriteLine("--Driver Report--\n");
            foreach(Driver index in D)
            {
                Console.WriteLine(index.ToString()); 
                Console.WriteLine(new string('-', 50)); 
            }


        }
    }
}
