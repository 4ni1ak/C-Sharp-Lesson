using Method;
using System;

	static void Main()
	{
		Account account1 = new Account("Jane Green");
		Account2 account2 = new Account2("John Blue", -7.53m);
		// display initial balance of each object
		Console.WriteLine($" {account2.Name}'s balance: {account2.Balance:C}");

		Console.Write("\nEnter deposit amount for account):");
		decimal depositAmount = decimal.Parse(Console.ReadLine());
		Console.WriteLine($"adding {depositAmount:C} to account balance\n");
		account2.Deposit(depositAmount);
		Console.WriteLine($" {account2.Name}'s balance: (account1.Balance:C)");

	}





