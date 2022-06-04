using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part1
{

    internal class Vehicle : Expenses
    {
        public override void ApprovedMessage()
        {

        }

        public override double Calculate(double totalAfterDeposit, double vehicleInterestRate, double numMonths)
        {
            //calculates the  monthly home payment and returns it to the main program
            double totalYears = numMonths / 12;
            return Math.Round((totalAfterDeposit * (1 + vehicleInterestRate * totalYears)) / numMonths, 2);
            //calculation method is taken from provided link
            //https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
        }

        public override void HeadingMessage()//Will be called to display an appropriate header message when entering vehicle info
        {
            Console.WriteLine("\n-----------------------------------------" +
                              "\nVEHICLE INFORMATION" +
                              "\n-----------------------------------------");
        }

        public override void UnapprovedMessage()
        {
            
        }
    }
}
//Reference list
//Troelsen, A and Japikse P. 2021. Pro C# 9 with.NET5 foundational principles and practices in programming. 10th ed. 
//New York. Apress Media
