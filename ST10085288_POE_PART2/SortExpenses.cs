using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part1
{// class the get the category name and its amount from the user to sort it according to its value
    //(Troelsen and Japikse,2021:334,335,336,337,338)
    internal class SortExpenses : IComparable
    {
        public string CategoryName { get; set; }
        public double ExpenseAmount { get; set; }


        public SortExpenses(string name, double amount)
        {
            CategoryName = name;
            ExpenseAmount = amount;
        }

        public SortExpenses()
        {
        }

        //sorts the list
        public int CompareTo(object obj)
        {
            if (obj is SortExpenses temp)
            {
                return this.ExpenseAmount.CompareTo(temp.ExpenseAmount);
            }
            throw new ArgumentException();
        }
    }
}
//Reference list
//Troelsen, A and Japikse P. 2021. Pro C# 9 with.NET5 foundational principles and practices in programming. 10th ed. 
//New York. Apress Media
