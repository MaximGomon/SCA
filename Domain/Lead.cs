using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    public class Lead : NamedEntity
    {
        public virtual LeadType Type { get; set; }
        public virtual Contact Buyer { get; set; }
    }
}
