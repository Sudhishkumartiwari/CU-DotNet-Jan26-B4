namespace ElectricAppliance
{
    public abstract class ElectricAppliance
    {
        public int Electric_Voltage { get; set; } = 220;
        public string? Model_Name { get; set; }
        public int PowerConsumption { get; set; }
        public int CurrentTemp { get; protected set; }
        public bool IsOn { get; set; }

        public abstract void Cooking();
        public abstract void Set_Temprature(int temp);

        public virtual void Preheat()
        {
            Console.WriteLine($"{Model_Name}: Standard ignition sequence started.");
        }

        public virtual void PowerOn()
        {
            IsOn = true;
            Console.WriteLine($"{Model_Name} is active at {Electric_Voltage}V.");
        }
    }

    public interface ITimer
    {
        void SetTimer(TimeSpan duration);
    }

    public interface IWiFi
    {
        void ConnectToCloud();
    }

    class Microwave : ElectricAppliance, ITimer
    {
        public override void Set_Temprature(int temp)
        {
            CurrentTemp = (temp > 100) ? 100 : temp; 
            Console.WriteLine($"{Model_Name} magnetron intensity set to {CurrentTemp}% capacity.");
        }

        public override void Cooking()
        {
            if (IsOn && CurrentTemp > 0)
                Console.WriteLine($"{Model_Name} is vibrating water molecules to heat food.");
            else
                Console.WriteLine($"{Model_Name} error: Power or Intensity not set.");
        }

        public void SetTimer(TimeSpan duration)
        {
            TimeOnly Stop = TimeOnly.FromDateTime(DateTime.Now).Add(duration);
            if (Stop == TimeOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Stop");
            }
            else
            {
                Console.WriteLine($"{Model_Name} scheduled to finish at {Stop}.");
            }
        }
    }

    class Oven : ElectricAppliance, ITimer, IWiFi
    {
        private bool _isPreheated = false;

        public override void Set_Temprature(int temp)
        {
            CurrentTemp = (temp < 50) ? 50 : (temp > 250) ? 250 : temp;
            Console.WriteLine($"{Model_Name} thermostat calibrated to {CurrentTemp}°C.");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{Model_Name} is warming up... current internal temp: 25°C.");
            _isPreheated = true;
            Console.WriteLine($"{Model_Name} has reached {CurrentTemp}°C. Ready to bake.");
        }

        public override void Cooking()
        {
            if (_isPreheated)
                Console.WriteLine($"{Model_Name} is baking using convection fans at {CurrentTemp}°C.");
            else
                Console.WriteLine($"{Model_Name} Warning: Cooking started before preheating finished.");
        }

        public void SetTimer(TimeSpan duration)
        {
            TimeOnly Stop = TimeOnly.FromDateTime(DateTime.Now).Add(duration);
            if (Stop == TimeOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Stop");
            }
            else
            {
                Console.WriteLine($"{Model_Name} baking cycle will end at {Stop}.");
            }
        }

        public void ConnectToCloud()
        {
            Console.WriteLine($"{Model_Name} reporting status to AeroCook Mobile App via WiFi.");
        }
    }

    class AirFryer : ElectricAppliance
    {
        public override void Set_Temprature(int temp)
        {
            CurrentTemp = temp;
            Console.WriteLine($"{Model_Name} mechanical dial rotated to {CurrentTemp}.");
        }

        public override void Cooking()
        {
            Console.WriteLine($"{Model_Name} is circulating air at high velocity for crisping.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<ElectricAppliance> factoryLine = new List<ElectricAppliance>
            {
                new Microwave { Model_Name = "Wave-X", PowerConsumption = 1200 },
                new Oven { Model_Name = "ChefPro 5000", PowerConsumption = 3000 },
                new AirFryer { Model_Name = "Mech-Crisp", PowerConsumption = 1500 }
            };

            foreach (var device in factoryLine)
            {
                Console.WriteLine($"\n--- Booting {device.Model_Name} ---");
                device.PowerOn();
                device.Set_Temprature(200);

                device.Preheat();
                device.Cooking();

                if (device is IWiFi smartDevice)
                {
                    smartDevice.ConnectToCloud();
                }

                if (device is ITimer timedDevice)
                {
                    timedDevice.SetTimer(TimeSpan.FromMinutes(10));
                }
            }
        }
    }
}
