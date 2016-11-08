using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class LeadModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Контакт")]
        public string ContactName { get; set; }
        public Guid ContactId { get; set; }
        [Display(Name = "Тип лида")]
        public string LeadType { get; set; }
        public Guid LeadTypeId { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}