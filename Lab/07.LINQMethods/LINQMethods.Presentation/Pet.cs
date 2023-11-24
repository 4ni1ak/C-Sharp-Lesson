using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQMethods.Presentation
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Age { get; set; }
        
        public Pet()
        {
            
        }
        public Pet(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;

        }

        public Pet(string firstName, string lastName, DateTimeOffset age) : this(firstName, lastName)
        {
            Age = age;
        }

    }
}
