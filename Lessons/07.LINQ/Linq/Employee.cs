using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private decimal monthlySalary;
        
        public Employee(string firstName, string lastName,decimal monthlySalary)
        {
            FirstName = firstName;
            LastName = lastName;
            MonthlySalary = monthlySalary;
        }
        public decimal MonthlySalary
        {
            get => monthlySalary;
            set
            {
                if (value >= 0M)
                {
                    monthlySalary = value;
                }
            }
        }

        public override string ToString() => $"{FirstName,-10}{LastName.Length,-10}{MonthlySalary,10:C}";
    }
}
