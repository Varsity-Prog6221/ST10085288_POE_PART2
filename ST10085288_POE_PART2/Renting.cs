using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part1
{
    internal class Renting : Expenses// (Troelsen and Japikse,2021:250,251,253,254)
    {//class has a method which overrides the abstract method in the expenses class to display an appropriate header
        public override void HeadingMessage()//Will be called to display an appropriate header message when entering renting info
        {
            Console.WriteLine("\n-----------------------------------------" +
                              "\nRENTING INFORMATION" +
                              "\n-----------------------------------------");
        }
        //below methods are not needed in the program but could be used for future development
        public override void ApprovedMessage()
        {
        }

        public override void UnapprovedMessage()
        {
        }

        public override double Calculate(double totalAfterDeposit, double interestRate, double numMonths)
        {
            throw new NotImplementedException();
        }
    }
}
//Reference list
//Troelsen, A and Japikse P. 2021. Pro C# 9 with.NET5 foundational principles and practices in programming. 10th ed. 
//New York. Apress Media
