using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjectsADeeperLook.Presentation
{
    public class Employee
    {
        public static int Count { get; private set; } 
        public string FirstName { get; }
        public string LastName { get; }
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            ++Count; 
            Console.WriteLine("Employee constructor: " + $" {FirstName} {LastName}: Count {Count}");
        }
    }
}
