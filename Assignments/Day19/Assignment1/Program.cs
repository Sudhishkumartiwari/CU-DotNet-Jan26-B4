namespace first
{
   abstract class Vehicle
    {
        public string ModelName {get; set;}

        protected Vehicle()
        {
            ModelName = string.Empty;
        }
        protected Vehicle(string modelName)
        {
            ModelName = modelName;
        }
        public abstract string Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable";
        }
    }
    class ElectricCar : Vehicle
    {
        public ElectricCar(string modelName) : base(modelName){}
        public override string Move()
        {
            return $"{ModelName} is gliding silently on battery power.";
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%.";
        }
    }
    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string modelName) : base(modelName){}
        public override string Move()
        {
            return $"{ModelName} is hauling cargo with high-torque diesel power.";
        }
        public new string GetFuelStatus()
        {
            return $"{ModelName} diesel tank is at 60%.";
        }
    }
    class CargoPlane : Vehicle
    {
        public CargoPlane(string modelName) : base(modelName){}
        public override string Move()
        {
            return $"{ModelName} is ascending to 30,000 feet.";
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + "- Checking jet fuel reserves";
        }
    }
    internal class FleetController
    {
        public static void Main(string[] args)
        {
            Vehicle[] V =
            {
                new ElectricCar("Tesla Model S"),
                new HeavyTruck("Freightliner Cascadia"),
                new CargoPlane("Boeing 747 Freighter")
            };

            foreach(var i in V)
            {
                Console.WriteLine(i.Move());
                Console.WriteLine(i.GetFuelStatus());
            }
        }
    }
}

