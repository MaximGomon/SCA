using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    /// <summary>
    /// Класс для компаний, компания может иметь в себе сотруднико
    /// </summary>
    public class Company : NamedEntity, IChangedBy, ICreatedBy, ICommented
    {
        //Хозяим компании
        public virtual Contact Owner { get; set; }
        /// <summary>
        /// РОдительская компания
        /// </summary>
        public virtual Company Parent { get; set; }
        /// <summary>
        /// Сотрудники
        /// </summary>
        public virtual List<Contact> Employees { get; set; }
        /// <summary>
        /// Ответственный исполнитель, человек, который закреплен за компанией
        /// </summary>
        //public virtual Employee Executor { get; set; }
        /// <summary>
        /// Перечень всех сайтов клиента, на которых установленны счетчики
        /// </summary>
        public virtual List<ClientSite> Sites { get; set; }

        public virtual DateTime ModifyDate { get; set; }
        public virtual SystemUser ChangedBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual SystemUser CreatedBy { get; set; }
        public virtual string Comment { get; set; }
    }
}
