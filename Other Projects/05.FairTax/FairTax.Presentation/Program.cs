using System;
namespace FairTax.Presentation
{

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the FairTax Calculator");

        Console.Write("Enter your total income: $");
        if (decimal.TryParse(Console.ReadLine(), out decimal totalIncome))
        {
            decimal totalFairTax = 0;

            while (true)
            {
                Console.Write("Enter an expense category (or 'done' to finish): ");
                string category = Console.ReadLine();

                if (category.ToLower() == "done")
                    break;

                Console.Write($"Enter your FairTax rate for {category} (in decimal form, e.g., 0.23 for 23%): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal fairTaxRate))
                {
                    Console.Write($"Enter your expenses for {category}: $");
                    if (decimal.TryParse(Console.ReadLine(), out decimal expenses))
                    {
                        decimal fairTaxForCategory = expenses * fairTaxRate;
                        totalFairTax += fairTaxForCategory;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid expense amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal FairTax rate.");
                }
            }

            decimal estimatedFairTax = totalIncome * totalFairTax;
            Console.WriteLine($"Estimated FairTax: ${estimatedFairTax:F2}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid total income amount.");
        }
    }
}
}
