using System.Diagnostics.Metrics;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
//            1.A software company wants to develop a Salary Calculation System that
//             calculates the Net Salary of employees based on their basic salary, tax
//             deductions, and bonus.The system should perform various operations
//             using arithmetic, relational, logical operators
//              Take the basic salary as user input.
//              Calculate a tax deduction(10 % of the basic salary). 
//              Add a bonus based on performance ratings:
//              Rating >= 8 → Bonus = 20 % of the basic salary.
//              Rating >= 5 and < 8 → Bonus = 10 % of the basic salary.
//              Rating < 5 → No bonus. 
//              Display the computed salary after all calculations.

            Console.WriteLine("Enter your basic salary::");
            double basicSalary=Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Performance Rating (0-10)::");
            double rating = Convert.ToDouble(Console.ReadLine());

            double bonus;

            double tax = basicSalary * 0.10;

            if (rating >= 8)
            {
                bonus = basicSalary * 0.20;
            }
            else if (rating >= 5)
            {
                bonus = basicSalary * 0.10;
            }
            else
            {
                bonus = 0.0;
            }
            double netSalary = basicSalary - tax + bonus;

            Console.WriteLine($"Salary Details\nBasic Salary:{basicSalary}\nTax:{tax}\nBonus:{bonus}\nNetSalary:{netSalary}");
        }
    }
}
