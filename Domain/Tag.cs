using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    /// <summary>
    /// Класс тега для счетчика
    /// </summary>
    public class Tag : NamedEntity
    {
        /// <summary>
        /// Все теги, которые находятся выше по иерархии
        /// </summary>
        public virtual ICollection<Tag> ParentTags { get; set; }
        /// <summary>
        /// Все теги, которые находятся на том же уровне, что и текущий
        /// </summary>
        //public List<Tag> SubsideriesTags { get; set; }  
        public virtual string Description { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
