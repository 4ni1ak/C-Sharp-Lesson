using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Presentation.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Int16 Age { get; set; }
        public string Department { get; set; }

    }
}
