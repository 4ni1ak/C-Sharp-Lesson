using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
	public class Account2
	{
		public string Name { get; set; }
		private decimal balance;

		public Account2(string name, decimal initialbalance)
		{
			Name = name;
			Balance = initialbalance;
		}
		public decimal Balance { get { return balance; } private set { if (value > 0.0M) balance = value; } }
		public void Deposit(decimal depositAmounth)
		{

			if (depositAmounth>0.0m)
			{
				Balance += depositAmounth;
			}
		}
	}
}
