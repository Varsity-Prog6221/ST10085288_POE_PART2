using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10085288_POE_Part1
{
    internal class Program
    {
        //global variables to be accessed by all methods
        public static bool bContinue = true;
        public static double monthlyIncome = 0;
        public static double monthlyExpenses = 0;
        //buy/rent variable      
        public static double monthlyHomePayment = 0;
        public static double purchasePrice = 0;
        public static double totalDeposit = 0;
        public static double interestRate = 0;
        public static double numMonths = 0;
        public static double monthlyRemainingMoney = 0;
        public static double totalexpenses = 0;
        //vehicle variables
        public static string vehicleModel;
        public static string vehicleMake;
        public static double vehiclePurchasePrice = 0;
        public static double vehicleTotalDeposit = 0;
        public static double vehicleInterestRate = 0;
        public static double vehicleInsurancePremium = 0;
        public static double vehicleMonthlyRepayment = 0;
        //list for category names and values
        public static List<SortExpenses> sortExpenses = new List<SortExpenses>();//begin met hierdie
        public static List<string> categoryList = new List<string> {"Tax deducted",
                                                         "Groceries expenses",
                                                         "Water and light expenses",
                                                         "Travel cost expenses(includes petrol)",
                                                         "Cellphone/telephone expenses",
                                                         "Other expenses" };

        //delegate
        public delegate void ExceedMessageDelegate(string message);


        static void Main(string[] args)
        {
            while (bContinue == true)// (Troelsen and Japikse,2021:96,97,98,99,100,101)
            {
                Console.WriteLine("=================================="
                            + "\nPERSONAL BUDGET PLANNER"
                            + "\n==================================");
                Entervalues();//calls method allowing the user to enter information
                CalculateMonthlyLivingExpenses();//calls method to calculate the monthly living expenses
                Display();//calls method to display a message for the user with the total monthly income and expenses
                          //and the the available/remaining money per month

                Console.WriteLine("Do you want to continue using this budget planner? " +
                              "\n(Y/y for yes or other key for no)");
                string sContinue = Console.ReadLine().ToUpper(); ;

                if (sContinue.Equals("Y"))// (Troelsen and Japikse,2021:97,98,99,100,101,102)
                {
                    bContinue = true;
                }
                else
                {
                    bContinue = false;
                    Environment.Exit(0);
                }
            }
        }

        public static void Entervalues()//asks the user to enter all information
        {
            Console.Write("Enter gross monthly income(before deductions): R");
            monthlyIncome = double.Parse(Console.ReadLine());

            int i = 0;

            while (i < categoryList.Count)// (Troelsen and Japikse,2021:96,97,98,99,100,101)
            {
                try// (Troelsen and Japikse,2021:279)
                {
                    // (Troelsen and Japikse,2021:111,112,113,114,117,118)
                    Console.Write("Enter monthly {0} : R", categoryList[i]);
                    // part 1: expenses[i] = double.Parse(Console.ReadLine());
                    sortExpenses.Add(new SortExpenses() { CategoryName = categoryList[i], ExpenseAmount = double.Parse(Console.ReadLine()) });
                    i++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("PLEASE ENTER A NUMBER ");
                }
            }

            Console.Write("Are you buying or renting property? \nEnter R/r for renting and any other key for buying: ");

            string sAccomadationOption = Console.ReadLine().ToUpper();
            if (sAccomadationOption.Equals("R"))// (Troelsen and Japikse,2021:97,98,99,100,101,102)
            {
                Renting();
            }
            else
            {
                Buying();
            }

            Console.Write("Would you like to purchase a vehicle? \nEnter Y/y for Yes and any other key for no: ");
            string sVehicleOption = Console.ReadLine().ToUpper();
            if (sVehicleOption.Equals("Y"))// (Troelsen and Japikse,2021:97,98,99,100,101,102)
            {
                Vehicle();
            }

        }

        public static void Renting()//asks user to enter monthly payment for renting
        {

            Renting message = new Renting();//Displays the heading of the Renting section by calling
            message.HeadingMessage();         //the abstract method Heading message from the Renting class

            int i = 0;
            while (i < 1)// (Troelsen and Japikse,2021:96,97,98,99,100,101)
                try// (Troelsen and Japikse,2021:279)
                {
                    Console.Write("Enter monthly rental amount: R");
                    monthlyHomePayment = double.Parse(Console.ReadLine());
                    // (Troelsen and Japikse,2021:111,112,113,114,117,118)
                    // part 1: expenses[6] = monthlyHomePayment;
                    sortExpenses.Add(new SortExpenses() { CategoryName = "Rent", ExpenseAmount = monthlyHomePayment });
                    i++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("PLEASE ENTER A NUMBER ");
                }
        }

        public static void Buying()//asks user to enter payment information for a home loan
        {

            HomeLoan message = new HomeLoan();//Displays the heading of the Home Buying section by calling
            message.HeadingMessage();         //the abstract method Heading message from the HomeLoan class

            bool b = false;
            int i = 0;
            while (i < 1)// (Troelsen and Japikse,2021:96,97,98,99,100,101)
            {
                try// (Troelsen and Japikse,2021:279)
                {
                    Console.Write("Enter purchase price of the property: R");
                    purchasePrice = double.Parse(Console.ReadLine());

                    Console.Write("Enter total deposit: R");
                    totalDeposit = double.Parse(Console.ReadLine());

                    Console.Write("Enter interest rate in percentage: ");
                    interestRate = (double.Parse(Console.ReadLine()) / 100);
                    i++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("PLEASE ENTER A NUMBER ");
                }
            }

            while (b == false)// (Troelsen and Japikse,2021:96,97,98,99,100,101)
            {
                Console.Write("Enter number of months to repay(between 240 and 360 ): ");
                numMonths = double.Parse(Console.ReadLine());

                if (numMonths < 240 || numMonths > 360)// (Troelsen and Japikse,2021:97,98,99,100,101,102)
                {
                    Console.WriteLine("Number of months must be between 240 and 360");
                    b = false;
                }
                else
                {
                    b = true;
                }
            }
            CalculateMonthlyHomeLoanRepayment();//calls the methid to calculate the monthly home loan repayment                     
        }

        public static void Vehicle()//asks user to enter infomration for buying a vehicle
        {

            Vehicle message = new Vehicle();//Displays the heading of the Vehicle section by calling
                                            //the abstract method Heading message from the Vehicle class
            message.HeadingMessage();

            Console.Write("Enter vehicle model:");
            vehicleModel = Console.ReadLine();

            Console.Write("Enter vehicle make: ");
            vehicleMake = Console.ReadLine();

            int i = 0;
            while (i < 1)// (Troelsen and Japikse,2021:96,97,98,99,100,101)
            {
                try// (Troelsen and Japikse,2021:279)
                {
                    Console.Write("Enter purchase price of the vehicle: R");
                    vehiclePurchasePrice = double.Parse(Console.ReadLine());

                    Console.Write("Enter total deposit of the vehicle: R");
                    vehicleTotalDeposit = double.Parse(Console.ReadLine());

                    Console.Write("Enter interest rate in percentage: ");
                    vehicleInterestRate = (double.Parse(Console.ReadLine()) / 100);

                    Console.Write("Enter the estimated insurance premium of the vehicle: R");
                    vehicleInsurancePremium = double.Parse(Console.ReadLine());

                    i++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("PLEASE ENTER A NUMBER ");
                }
                CalculateMonthlyVehicleRepayment();
            }
        }

        public static void CalculateMonthlyVehicleRepayment()//calculates the vehicle payment for a vehicle by calling the
                                                             //abstract method from Vehicle class 
        {
            Vehicle vehicle = new Vehicle();
            double totalAfterDeposit = vehiclePurchasePrice - vehicleTotalDeposit;
            vehicleMonthlyRepayment = vehicle.Calculate(totalAfterDeposit, vehicleInterestRate, 60) + vehicleInsurancePremium;
            sortExpenses.Add(new SortExpenses() { CategoryName = "Vechile Repayment", ExpenseAmount = vehicleMonthlyRepayment });

            Console.Write("\n-----------------------------------------" +
                          "\nVehicle payment per month: R" + vehicleMonthlyRepayment +
                          "\n-----------------------------------------");
        }

        public static void CalculateMonthlyHomeLoanRepayment()//calculates the monthly payment for a home loan by calling the
                                                              //abstract method from Homeloan class and displays a appropriate
                                                              //message if it is approved or not
        {
            HomeLoan homeLoan = new HomeLoan();

            double totalAfterDeposit = purchasePrice - totalDeposit;

            monthlyHomePayment = homeLoan.Calculate(totalAfterDeposit, interestRate, numMonths);
            //(Troelsen and Japikse,2021:111,112,113,114,117,118)
            // part 1: expenses[6] = monthlyHomePayment;
            sortExpenses.Add(new SortExpenses() { CategoryName = "Home Loan Repayment", ExpenseAmount = monthlyHomePayment });
            Console.Write("-----------------------------------------" +
                          "\nMonthly home payment per month: R" + monthlyHomePayment);

            if ((monthlyIncome / 3) < monthlyHomePayment)// (Troelsen and Japikse,2021:97,98,99,100,101,102)
            {
                homeLoan.UnapprovedMessage();
            }
            else
            {
                homeLoan.ApprovedMessage();
            }
        }

        public static void CalculateMonthlyLivingExpenses()//calculates the available/remaining money per month and total expenses
        {

            ExceedMessageDelegate message = ExceedMessage;//(Troelsen and Japikse,2021: 451,452,453,454,455,456,457)
            totalexpenses = 0;
            totalexpenses += sortExpenses.Sum(x => x.ExpenseAmount);
            monthlyRemainingMoney = monthlyIncome - totalexpenses;

            if (totalexpenses > (monthlyIncome * 3 / 4))
            {
                //message = new ExceedMessageDelegate(Message);
                message("\nNOTE: TOTAL MONTHLY EXPENSES EXCEED 75% OF YOUR TOTAL MONTHLY INCOME");
            }
        }

        public static void ExceedMessage(string message)//delegate to present the user with a message
        {
            //(Troelsen and Japikse,2021: 451,452,453,454,455,456,457)
            Console.WriteLine(message);
        }

        public static void Display()//display a message for the user with the total monthly income and expenses
                                    //and the the available/remaining money per month
        {

            Console.WriteLine("\n-----------------------------------------" +
                          "\nBUDGET PLANNING INFROMATION" +
                          "\n-----------------------------------------" +
                          "\nMonthly income: \tR" + Math.Round(monthlyIncome, 2) +
                          "\n" + "Monthly expenses: \tR" + Math.Round(totalexpenses, 2) +
                          "\n" + "Available money: \tR" + Math.Round(monthlyRemainingMoney, 2) +
                          "\n" + "-----------------------------------------" +
                          "\nEXPENSES IN DESCENDING ORDER" +
                          "\n-----------------------------------------");
            //sorts the list, reverses it and then displays it in descending order
            sortExpenses.Sort();
            sortExpenses.Reverse();
            foreach (SortExpenses a in sortExpenses)
            {
                Console.WriteLine("{0} : R{1}", a.CategoryName, a.ExpenseAmount);
            }
            Console.WriteLine("-----------------------------------------");

            sortExpenses.Clear();
        }

    }
}

//Reference list
//Troelsen, A and Japikse P. 2021. Pro C# 9 with.NET5 foundational principles and practices in programming. 10th ed. 
//New York. Apress Media

