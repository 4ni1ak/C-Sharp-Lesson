using Classes;
using System;
class Program
{

    #region First 
    // static int Main(    )
    //{
    //    //class ile object in farkı nedir

    //    Account account = new() { Name = "Deam" };
    //    account.Name = "DEamm";
    //    Console.WriteLine($"{account.Name}");


    //    Console.ReadLine();
    //    return 0;
    //}

    #endregion


    static void Main()
    {
        Account myAccount = new Account();
        Console.WriteLine($"Initial name is: {myAccount.GetName()}");
        Console.Write("Enter the name: "); 
        string theName = Console.ReadLine(); 

        myAccount.SetName (theName); 
        Console.WriteLine($"myAccount's name is: {myAccount.GetName()}");
    }
}
