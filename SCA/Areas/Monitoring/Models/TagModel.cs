using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class TagModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        public Guid Id { get; set; }
        [Display(Name = "Сайт")]
        public string SiteName { get; set; }
        public Guid SiteId { get; set; } 
    }
}