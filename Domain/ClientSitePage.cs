using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual string Tag { get; set; }
        public virtual string Url { get; set; }
        /// <summary>
        /// Количество посищений странички пользователями
        /// </summary>
        public virtual int VisitCount { get; set; }
        /// <summary>
        /// Дата последнего посещения странички
        /// </summary>
        public virtual DateTime LastVisitDate { get; set; }
    }
}
