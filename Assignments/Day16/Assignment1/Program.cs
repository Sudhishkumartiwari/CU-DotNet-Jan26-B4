namespace Day16{

public class ApplicationConfig{

    public static string ApplicationName {get; set;}
    public static string Environment {get; set;}
    public static int AccessCount {get; set;}
    public static bool IsInitialized {get;set;}


    static ApplicationConfig(){
           ApplicationName = "MyApp";
           Environment = "Development";
           AccessCount = 0;
           IsInitialized = false;

           Console.WriteLine("Static Constructor Executed.")
    }

    public static void Initialize(string appName, string environment){
         ApplicationName = appName;
         Environment = environment;
         IsInitialized = true;
         AccessCount++;
    }

    public static string GetConfigurationSummary(){
         AccessCount++;
         return $"{ApplicationName} {Environment} {AccessCount} {IsInitialized}"
    }

    public static void ResetConfiguration(){
           ApplicationName = "MyApp";
           Environment = "Development";
           AccessCount++;
           IsInitialized = false;
    }
}

public class Day16{

    public static void Main(string[] args){
        
        ApplicationConfig.Initialize("Ather", "ourEnv" );
        Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
        ApplicationConfig.ResetConfiguration();
        Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
    }
}

}


