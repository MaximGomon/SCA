using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    /// <summary>
    /// Социальные сети в которых есть контакт
    /// </summary>
    public class SocialNetworkEvent : IdentityEntity, ICreated
    {
        //Придумать набор полей, в зависимости от того, что можно прочитать с сетей
        public virtual string Link { get; set; }
        public virtual string Message { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Contact Avtor { get; set; }
        /// <summary>
        /// Что именно было запощено (видео, фото, текст)
        /// </summary>
        public virtual string Type { get; set; }
        public virtual string EventId { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        [Column(TypeName = "datetime2")]
        public virtual DateTime CreateDate { get; set; }

    }
}
