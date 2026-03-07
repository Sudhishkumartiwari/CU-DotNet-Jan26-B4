using NUnit.Framework;
using BonusCalculator;

namespace BonusCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(500000, 5, 6, 1.1, 95, 123200.00)]
        [TestCase(400000, 4, 8, 1.0, 80, 60480.00)]
        [TestCase(1000000, 5, 15, 1.5, 95, 280000.00)]
        [TestCase(0, 5, 6, 1.1, 95, 0.00)]
        [TestCase(300000, 2, 3, 1.0, 90, 13500.00)]
        [TestCase(600000, 3, 0, 1.0, 100, 64800.00)]
        [TestCase(900000, 5, 11, 1.2, 100, 226800.00)]
        [TestCase(555555, 4, 6, 1.13, 92, 118649.88)]

        public void CalculateBonus(decimal baseSalary, int performanceRating, int yearsOfExperience, decimal departmentMultiplier, double attendancePercentage, decimal expectedBonus)
        {
            var calculator = new Calculator(baseSalary, performanceRating, yearsOfExperience, departmentMultiplier, attendancePercentage);

            Assert.That(calculator.NetAnnualBonus, Is.EqualTo(expectedBonus)); 
        }
        
    }
}

