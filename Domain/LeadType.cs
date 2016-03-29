using System.Collections.Generic;

namespace SCA.Domain
{
    public class LeadType : NamedEntity
    {
         public virtual ICollection<Tag> LeadTags { get; set; } 
    }
}