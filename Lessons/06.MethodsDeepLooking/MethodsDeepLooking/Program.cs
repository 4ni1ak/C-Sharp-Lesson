using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace MethodsDeepLooking
{
    internal class Program
    {
        #region exp2
        private static int x = 1;

        #endregion
        static void Main(string[] args)
        {
            #region exp1

            Random randomNumbers = new Random(); // random-number generator
                                                 // Toop 20 times
            for (int counter = 1; counter <= 20; ++counter)
            {
                // pick random integer from 1 to 6
                int face = randomNumbers.Next(1, 7);
                Console.Write($"{face} "); // display generated value
            }
            Console.WriteLine();
            #endregion
            #region exp2
            int x = 5;
            Console.WriteLine($"Local x in method Main is {x}");
            UseLocalVarable();
            UseStaticVariable();


            #endregion
            #region exp3
            x = 10;
            Console.WriteLine($"x Squared:{Square(x)}");
            #endregion
            #region myexp
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);

                // Byte to integer
                int randomValue = BitConverter.ToInt32(randomNumber, 0);

                Console.WriteLine("Random number " + randomValue);
            }
            #endregion
            Console.ReadLine();

        }



        #region exp2

        private static void UseLocalVarable()
        {
            int x = 25;
            Console.WriteLine(
            $"\nlocal x on entering method UseLocal Variable is {x}");
            ++x;
            Console.WriteLine(
            $"local x before exiting method UseLocal Variable is {x}");
        }
        static void UseStaticVariable()
        {
            Console.WriteLine("\nstatic variable x on entering method " +
                $"UseStaticVariable is {x}");
            x = 10; // modifies class Scope's static variable x
            Console.WriteLine("static variable x before exiting " + $"method UseStaticVariable is {x}");

        }


        #endregion
        #region exp3
        private static int Square(int y)
        {
            return y * y;
        }

        #endregion
       

}
}
