using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    /// <summary>
    /// Собитие на сайте
    /// </summary>
    public class Activity: IdentityEntity, ICreated
    {
        /// <summary>
        /// Тип события
        /// </summary>
        public virtual ActivityType Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual List<Tag> Tag { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual string Cookie { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Юзер, которого мі определили со счетчика
        /// </summary>
        public virtual Contact Author { get; set; }
    }
}
