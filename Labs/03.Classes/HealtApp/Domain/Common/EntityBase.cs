using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtApp.Domain.Common
{

    internal class EntityBase<TKey>
    {
        public TKey Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

    }
}

