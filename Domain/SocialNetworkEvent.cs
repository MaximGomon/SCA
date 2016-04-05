using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    /// <summary>
    /// Социальные сети в которых есть контакт
    /// </summary>
    public class SocialNetworkEvent : IdentityEntity
    {
        //Придумать набор полей, в зависимости от того, что можно прочитать с сетей
        public virtual string Link { get; set; }
        public virtual string Message { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Contact Avtor { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
