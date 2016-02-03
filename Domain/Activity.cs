using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    /// <summary>
    /// Собитие на сайте
    /// </summary>
    public class Activity: IdentityEntity, ICreated
    {
        /// <summary>
        /// Тип события
        /// </summary>
        public virtual ActivityType Type { get; set; }
        
    }
}
