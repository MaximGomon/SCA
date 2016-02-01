using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    /// <summary>
    /// Контакт, человек в системе
    /// </summary>
    public class Contact : NamedEntity, ICreatedBy, IChangedBy, ICommented
    {
        /// <summary>
        /// Перечен его телефонніх номеров
        /// </summary>
        public virtual List<string> Telephones { get; set; }
        public virtual string Email { get; set; }
        /// <summary>
        /// Родительский контакт
        /// </summary>
        public virtual Contact Parent { get; set; }
        /// <summary>
        /// Ответственный исполнитель, человек, который закреплен за контактом
        /// </summary>
        public virtual Employee Executor { get; set; }
    }
}
