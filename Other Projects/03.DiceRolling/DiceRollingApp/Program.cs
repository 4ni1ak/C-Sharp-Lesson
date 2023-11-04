using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollingApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberOfThrows = 100000; 
            Dictionary<int, int> results = new Dictionary<int, int>();
            List<int> throwResults = new List<int>();

            for (int i = 0; i < numberOfThrows; i++)
            {
                int diceResult = random.Next(1, 7); 
                throwResults.Add(diceResult); 

                if (results.ContainsKey(diceResult))
                {
                    results[diceResult]++;
                }
                else
                {
                    results[diceResult] = 1;
                }
            }

            double totalAverage = throwResults.Average();

            Console.WriteLine("Dice Rolling Statistics:");
            Console.WriteLine($"Total Throws: {numberOfThrows}");
            Console.WriteLine($"Average Dice Value: {totalAverage:F2}");
            Console.WriteLine("\nDice Results:");

            foreach (var result in results)
            {
                double percentage = (double)result.Value / numberOfThrows * 100;
                Console.WriteLine($"Dice {result.Key}: Rolled {result.Value} times ({percentage:F2}%).");
            }
        }
    }



}
