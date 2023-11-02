using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1
            
            // prompt for and input three floating-point values
            Console.Write("Enter first floating-point value: ");
            double number1 = double.Parse(Console.ReadLine());
            Console.Write("Enter second floating-point value: ");
            double number2 = double.Parse(Console.ReadLine());
            Console.Write("Enter third floating-point value: ");
            double number3 = double.Parse(Console.ReadLine());
            // determine the maximum of three values
            double result = Maximum(number1, number2, number3);
            // display maximum value
            Console.WriteLine("Maximum is: " + result);

            #endregion
            string name= "ali";
            Console.WriteLine($"{name + 5}");
            Console.WriteLine($"{name + 5+9}");

        }
        #region 1
        
        static double Maximum(double x, double y, double z)
        {
            double maximumValue = x; // assume x is the largest to start
                                     // determine whether y is greater than maximumValue
            if (y > maximumValue)
            {
                maximumValue = y;
            }
            // determine whether z is greater than maximumValue
            if (z > maximumValue)
            {
                maximumValue = z;
            }
            return maximumValue;
        }
        #endregion
    }
}

