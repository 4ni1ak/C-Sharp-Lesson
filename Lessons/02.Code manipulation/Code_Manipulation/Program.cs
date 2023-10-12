using System;
class Welcome
{

    static void Main()
    {
        Console.Write("Thats a console line");
        Console.WriteLine("Thats a console line");
        string userInput = Console.ReadLine();
        Console.WriteLine($"Thats a console line");
        int nuber1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"{nuber1+num2}");



    }


}
