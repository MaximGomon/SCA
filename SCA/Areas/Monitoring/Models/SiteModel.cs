using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class SiteModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Домены")]
        public string Domains { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; } 
        public SitePageModel[] Pages { get; set; }
        //public string Comment { get; set; }
        //public DateTime CreateDate { get; set; }
        [Display(Name = "Владелец")]
        public string Company { get; set; }
        [Display(Name = "Адресс")]
        public string Url { get; set; }
        public Guid CompanyId { get; set; }
        [Display(Name = "К-во страниц")]
        public int PagesCount { get; set; }
    }
}