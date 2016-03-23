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
    }
}