using System;

namespace SCA.Areas.Monitoring.Models
{
    public class TagModel
    {
        public string TagName { get; set; }
        public Guid Id { get; set; }
        public string SiteName { get; set; }
        public Guid SiteId { get; set; } 
    }
}