using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : IdentityEntity
    {
        /// <summary>
        /// Контакт, непосредственно человек
        /// </summary>
        public virtual Contact People { get; set; }
        /// <summary>
        /// Перечент его должностей/обязаностей
        /// </summary>
        public virtual List<EmployeePosition> Positions { get; set; } 
    }
}
