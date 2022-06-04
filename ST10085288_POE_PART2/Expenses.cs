using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part1
{
    internal abstract class Expenses// (Troelsen and Japikse,2021:250,251,253,254)
    {     //abstract class that hold 4 abstract methods with no bodies

        public abstract void ApprovedMessage();

        public abstract void UnapprovedMessage();

        public abstract void HeadingMessage();

        public abstract double Calculate(double totalAfterDeposit, double interestRate, double numMonths);

    }
}
//Reference list
//Troelsen, A and Japikse P. 2021. Pro C# 9 with.NET5 foundational principles and practices in programming. 10th ed. 
//New York. Apress Media
