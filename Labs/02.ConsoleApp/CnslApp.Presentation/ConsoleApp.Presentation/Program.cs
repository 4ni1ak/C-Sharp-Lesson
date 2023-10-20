using System;
class Presentation
{
    static void Main()
    {
        bool check = true;
        while (check)
        {

            Console.WriteLine("Enter a five-digit number:");
            string userInput = Console.ReadLine();

            if (userInput.Length == 5)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (i == userInput.Length)
                        Console.Write($"{userInput[i].ToString()}");
                    Console.Write($"{userInput[i]}   ");

                }
                check = !true;
                break;
            }
            Console.WriteLine("Error!! u must be enter 5 diget number");
        }
    }
}
