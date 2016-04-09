using System.Collections.Generic;

namespace SCA.Domain
{
    public class LeadType : IdentityEntity
    {
         public virtual ICollection<Tag> LeadTags { get; set; } 
    }
}