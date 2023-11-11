using System;

class Program
{
    static void Main(string[] args)
    {
        Calculation.TaxWrite();
        Console.ReadLine(); // I added this for control purposes
    }
}

class Taxes
{
    public static decimal grossIncome;
    const byte taxPercentage = 40;
    public static decimal CalculateIncomeTax(decimal grossIncome)
    {
        decimal gross;
        while (true) // Will keep looping until a correct input is provided
        {
            Console.WriteLine("Enter the gross income:");
            if (decimal.TryParse(Console.ReadLine(), out gross)) // Checks if the input is a valid decimal and assigns it to 'gross'
                break; // Breaks the loop after valid input
            Console.WriteLine("Invalid input");
        }
        return gross * taxPercentage / 100;
   
    }
}

class Calculation
{
    static decimal tax;
    public static void TaxWrite()
    {
        tax = Taxes.CalculateIncomeTax(Taxes.grossIncome); // Using the tax object
        Console.WriteLine($"{tax}"); // Displaying the calculated tax on the screen
    }
}
