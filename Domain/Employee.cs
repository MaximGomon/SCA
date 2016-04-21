using System.Collections.Generic;

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
