using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part1
{
    internal class HomeLoan : Expenses// (Troelsen and Japikse,2021:250,251,253,254)
    {//Homeloan inherits the 2 abstract methods from Expenses and provides them with bodies
        public override void ApprovedMessage()//will be called if the home loan is approved 
        {
            Console.WriteLine("\n-----------------------------------------" +
                              "\nHome loan is approved" +
                              "\n-----------------------------------------");
        }

        public override double Calculate(double totalAfterDeposit, double interestRate, double numMonths)
        {//calculates the  monthly home payment and returns it to the main program
            double totalYears = numMonths / 12;
            return Math.Round((totalAfterDeposit * (1 + interestRate * totalYears)) / numMonths, 2);
            //calculation method is taken from provided link
            //https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
        }

        public override void HeadingMessage()//Will be called to display an appropriate header message when entering home loan info
        {
            Console.WriteLine("\n-----------------------------------------" +
                              "\nHOME LOAN INFORMATION" +
                              "\n-----------------------------------------");
        }

        public override void UnapprovedMessage()//will be called if the home loan is not approved
        {
            Console.WriteLine("\n-----------------------------------------" +
                "\nHome loan is not approved due to insufficient monthly income " +
                "\nMonthly home loan payment is more than a third of your monthly income ");
        }
    }
}
//Reference list
//Troelsen, A and Japikse P. 2021. Pro C# 9 with.NET5 foundational principles and practices in programming. 10th ed. 
//New York. Apress Media
