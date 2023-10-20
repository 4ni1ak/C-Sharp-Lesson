using HealtApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtApp.Domain.Common
{

    internal class Person<TKey> : EntityBase<TKey>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        protected int? Age { get; set; }



    }

}
