using CurrencyConversionApp;
using System;
using System.Collections.Generic;

class User
{
    public List<CurrencyConversion> Conversions { get; set; }

    public User()
    {
        Conversions = new List<CurrencyConversion>();
    }

    public void Start()
    {
        string exchangeRateDataUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";
        CurrencyConverter converter = new CurrencyConverter(exchangeRateDataUrl);

        Console.WriteLine("Currency Conversion App");

        converter.ShowAvailableCurrencies();

        while (true)
        {
            Console.Write("Enter the amount to convert (or press 'q' to quit): ");
            string input = Console.ReadLine();

            if (input == "q")
                break;

            if (double.TryParse(input, out double amount))
            {
                Console.Write("Enter the source currency code: ");
                string sourceCurrency = Console.ReadLine();

                Console.Write("Enter the target currency code: ");
                string targetCurrency = Console.ReadLine();

                try
                {
                    double result = converter.ConvertCurrency(amount, sourceCurrency, targetCurrency);
                    Console.WriteLine($"{amount} {sourceCurrency} = {result} {targetCurrency}");

                    Conversions.Add(new CurrencyConversion
                    {
                        Amount = amount,
                        SourceCurrency = sourceCurrency,
                        TargetCurrency = targetCurrency,
                        Result = result
                    });
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }

        Console.WriteLine("Conversions Made:");
        foreach (var conversion in Conversions)
        {
            Console.WriteLine($"{conversion.Amount} {conversion.SourceCurrency} = {conversion.Result} {conversion.TargetCurrency}");
        }
    }
}

class CurrencyConversion
{
    public double Amount { get; set; }
    public string SourceCurrency { get; set; }
    public string TargetCurrency { get; set; }
    public double Result { get; set; }
}

class Program
{
    static void Main()
    {
        User user = new User();
        user.Start();
    }
}
