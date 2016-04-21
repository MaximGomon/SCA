using System.Collections.Generic;

namespace SCA.Domain
{
    /// <summary>
    /// Страница с счетчиком на сайте клиента
    /// </summary>
    public class ClientSitePage : NamedEntity
    {
        /// <summary>
        /// Тег странички
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
        /// <summary>
        /// Относительный урл странички от домена сайта
        /// </summary>
        public virtual string RelatedUrl { get; set; }
    }
}
