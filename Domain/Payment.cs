using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    /// <summary>
    /// Оплата за услуги
    /// </summary>
    public class Payment : IdentityEntity
    {
        public virtual PaymentType Type { get; set; }
        public virtual DateTime PayDate { get; set; }
        public virtual PaymentStatus Status { get; set; }
        /// <summary>
        /// Валюта, в которой была проведена оплата
        /// </summary>
        public virtual Currency Currency { get; set; }
        /// <summary>
        /// На счет какой компании должна быть защитана отплата
        /// </summary>
        public virtual Company Recepient { get; set; }
        /// <summary>
        /// Назначение платежа
        /// </summary>
        public string Assignment { get; set; }
        /// <summary>
        /// Сумма оплаты
        /// </summary>
        public double Amount { get; set; }
    }
}
