using System;

namespace CodacLogisticsFuelAuditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(" Codac Logistics Delivery & Fuel Auditor ");
            Console.WriteLine("==============================================\n");
            string driverName;

            decimal weeklyFuelBudget;

            double totalDistance;

            Console.Write("Enter Driver's Full Name: ");
            driverName = Console.ReadLine();

            Console.Write("Enter Weekly Fuel Budget: ");
            weeklyFuelBudget = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Total Distance Traveled This Week (km): ");
            totalDistance = double.Parse(Console.ReadLine());

            while (totalDistance < 1.0 || totalDistance > 5000.0)
            {
                Console.WriteLine("Error: Distance must be between 1.0 and 5000.0 km.");
                Console.Write("Please re-enter the total distance: ");
                totalDistance = double.Parse(Console.ReadLine());
            }

            decimal[] fuelExpenses = new decimal[5];

            decimal totalFuelSpent = 0m;

            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                Console.Write($"Enter fuel expense for Day {i + 1}: ");
                fuelExpenses[i] = decimal.Parse(Console.ReadLine());

                totalFuelSpent += fuelExpenses[i];
            }

            decimal averageDailyExpense = totalFuelSpent / fuelExpenses.Length;
            double fuelEfficiency = totalDistance / (double)totalFuelSpent;
            string efficiencyRating;
            if (fuelEfficiency > 15)
            {
                efficiencyRating = "High Efficiency";
            }
            else if (fuelEfficiency >= 10)
            {
                efficiencyRating = "Standard Efficiency";
            }
            else
            {
                efficiencyRating = "Low Efficiency / Maintenance Required";
            }
            bool isUnderBudget = totalFuelSpent <= weeklyFuelBudget;

            Console.WriteLine("\n========== WEEKLY AUDIT REPORT ==========\n");

            Console.WriteLine($"Driver Name: {driverName}");
            Console.WriteLine($"Total Distance Traveled: {totalDistance} km\n");

            Console.WriteLine("Fuel Expense Breakdown:");
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]:C}");
            }

            Console.WriteLine("\nSummary:");
            Console.WriteLine($"Total Fuel Spent: {totalFuelSpent:C}");
            Console.WriteLine($"Average Daily Expense: {averageDailyExpense:C}");
            Console.WriteLine($"Fuel Efficiency Rating: {efficiencyRating}");
            Console.WriteLine($"Stayed Within Budget: {isUnderBudget}");

            Console.WriteLine("\n========================================");
            Console.WriteLine(" End of Report ");
            Console.WriteLine("========================================");

            Console.ReadKey();
        }
    }
}
