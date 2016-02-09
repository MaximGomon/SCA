using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    /// <summary>
    /// Сайт клиента, на котором будут размещаться счетчики
    /// </summary>
    public class ClientSite : NamedEntity
    {
        /// <summary>
        /// Перечень страниц сайта
        /// </summary>
        public virtual List<ClientSitePage> Pages { get; set; }
        /// <summary>
        /// Список доменов для сайта
        /// </summary>
        public virtual List<string> Domains { get; set; } 
    }
}
