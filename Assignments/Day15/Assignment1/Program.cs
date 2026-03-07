using System;

namespace HeightCalculator
{
   public class Height
    {
        public int Feet {get; set;}
        public double Inches {get;set;}
        public Height(){
            Feet = 0;
            Inches = 0.0;
        }
        public Height(int feet, double inches)
        {
             Feet = feet;
             Inches = inches;
             InchesToHeight();
        }
        private void InchesToHeight()
        {
            if(Inches >= 12)
            {
                Feet += (int)(Inches/12);
                Inches %= 12;
            }
            
        }
        public Height AddHeight(Height h2)
        {
            int TotalFeet = this.Feet + h2.Feet;
            double TotalInches = this.Inches + h2.Inches;

            return new Height(TotalFeet, TotalInches);
        }
        public Height(double totalInches)
        {
            Feet = (int)(totalInches / 12);
            Inches = totalInches % 12;
        }

        public override string ToString()
        {
            return $"Height - {Feet}feet {Inches:F1} inches";
        }
       public static void Main(string[] args)
        {
            Height person1 = new Height(5, 6.5);
            Height person2 = new Height(5, 7.5);
            Height person3 = new Height(180.0);
            
            Height totalHeight = person1.AddHeight(person2); 

            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString()); 
            Console.WriteLine(person3.ToString());
            Console.WriteLine(totalHeight.ToString()); 
        } 
    }
}
