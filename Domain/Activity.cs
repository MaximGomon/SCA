using System;
using System.Collections.Generic;
using System.Linq;
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
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual string Cookie { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Юзер, которого мі определили со счетчика
        /// </summary>
        public virtual Contact Author { get; set; }
        public string GetAllTags()
        {
            if (Tag.Count > 0)
            {
                return Tag.Select(x => x.Name).Aggregate((a, b) => a + ", " + b);
            }
            return String.Empty;
        }
    }
}
