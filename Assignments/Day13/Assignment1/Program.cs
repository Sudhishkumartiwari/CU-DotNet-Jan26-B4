using System;

public class GymMembership
{
    public enum GymServices
    {
        None = 0,
        Treadmill = 1,
        WeightLifting = 2,
        Zumba = 4
    }

    public static double CalculateMonthlyFee(GymServices selectedServices)
    {
        double total = 1000;
        bool hasService = false;

        if (selectedServices.HasFlag(GymServices.Treadmill))
        {
            total += 300;
            hasService = true;
        }

        if (selectedServices.HasFlag(GymServices.WeightLifting))
        {
            total += 500;
            hasService = true;
        }

        if (selectedServices.HasFlag(GymServices.Zumba))
        {
            total += 250;
            hasService = true;
        }

        if (!hasService)
        {
            total += 200;
        }

        double gstAmount = total * 0.05;
        
        return total + gstAmount;
    }

    public static void Main()
    {
        var myServices = GymServices.Treadmill | GymServices.Zumba;
        double finalBill = CalculateMonthlyFee(myServices);

        Console.WriteLine($"Total Membership Amount (incl. GST): Rs. {finalBill}");
    }
}