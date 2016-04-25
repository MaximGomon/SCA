using System;
using System.ComponentModel.DataAnnotations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Models
{
    public class LeadTypeModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Теги")]
        public Guid[] TagsId { get; set; }
        [Display(Name = "Теги")]
        public string Tags { get; set; }
    }
}