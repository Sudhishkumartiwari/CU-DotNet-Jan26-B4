    
namespace Week5_Assessment
{
    public class RestrictedDestinationException : Exception
    {
        public string DeniedLocation {get;}
        public RestrictedDestinationException(string location) : base($"Restriced Destination :{location}")
        {
            DeniedLocation = location;
        }

    }
    public class InsecurePackagingException : Exception
    {
         public InsecurePackagingException(string message) : base(message){}
    }
    public abstract class Shipment{
    
       public string? TrackingId {get;set;}
       public  double Weight {get;set;}
       public string? Destination {get;set;}
       public bool IsFragile {get;set;}
       public bool Reinforced {get;set;}

       public abstract void ProcessShipment();
    }

    public interface ILoggable
    {
       public void SaveLog(string message);
    }

    public class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            if(Weight <= 0)
            {
               throw new ArgumentOutOfRangeException(); 
            } 
            if(IsFragile && !Reinforced)
            {
                throw new InsecurePackagingException("Fragile items must have a 'Reinforced' status.");
            }
            Console.WriteLine($"Processing Express Shipment To : {Destination} Tracking Id: {TrackingId}");
        }
    }

    public class HeavyFreight : Shipment
    {
        public override void ProcessShipment()
        {
            if(Weight <= 0)
            {
               throw new ArgumentOutOfRangeException(); 
            } 
            if(Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }
            if(Weight > 1000)
            {
                Console.WriteLine($"Heavy Lift permit required.");
                Console.WriteLine($"Heavy Freight {TrackingId} processed.");
            }
        }
    }

    public class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            using StreamWriter sw = new StreamWriter("shipment_audit.log", true);
            {
                sw.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            LogManager manage = new LogManager();
            List<Shipment> shipments = new List<Shipment>()
            {
                new HeavyFreight{TrackingId = "ABS21", Weight = 1500, Destination = "Delhi"},
                new HeavyFreight { TrackingId = "HSB82", Weight = 500, Destination = "North Pole" },
                new HeavyFreight { TrackingId = "HJD33", Weight = -10, Destination = "Chandigarh" },
                new ExpressShipment { TrackingId = "EMX93", Weight = 10, Destination = "Pune", IsFragile = true, Reinforced = false }
            };

            foreach(var s in shipments)
            {
                try
                {
                    s.ProcessShipment();
                    manage.SaveLog($"Success: Shipment {s.TrackingId}");
                }
                catch(RestrictedDestinationException ex)
                {
                    manage.SaveLog($"Security Alert: {ex.Message}");
                    Console.WriteLine($"ALERT: {ex.Message}");
                }
                catch(InsecurePackagingException ex)
                {
                    manage.SaveLog($"Packaging Error for {s.TrackingId}: {ex.Message}");
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    manage.SaveLog($"Security Alert: {ex.Message}");
                }
                catch (Exception ex)
                {
                    manage.SaveLog($"General Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {s.TrackingId}");
                }
            }

            
        }
    }
}
