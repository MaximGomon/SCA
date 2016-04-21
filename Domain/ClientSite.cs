using System.Collections.Generic;

namespace SCA.Domain
{
    /// <summary>
    /// Сайт клиента, на котором будут размещаться счетчики
    /// </summary>
    public class ClientSite : NamedEntity
    {
        public ClientSite()
        {
            Pages = new List<ClientSitePage>();
        }
        /// <summary>
        /// Перечень страниц сайта
        /// </summary>
        public virtual ICollection<ClientSitePage> Pages { get; set; }
        /// <summary>
        /// Список доменов для сайта
        /// </summary>
        public virtual ICollection<string> Domains { get; set; }
        public virtual Company Owner { get; set; }
        public virtual string Url { get; set; }
    }
}
