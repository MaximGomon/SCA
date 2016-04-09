using System;

namespace SCA.Areas.Monitoring.Models
{
    public class SiteModel
    {
        public Guid Id { get; set; }
        public string Domain { get; set; }
        public string Name { get; set; } 
        public SitePageModel[] Pages { get; set; }
        public string Comment { get; set; }
        //public DateTime CreateDate { get; set; }
        public string Company { get; set; }
        public int PagesCount { get; set; }
    }
}