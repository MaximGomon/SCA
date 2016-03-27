using System;

namespace SCA.Areas.Monitoring.Models
{
    public class SitePageModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string RelatedUrl { get; set; }
        public string Tag { get; set; }
        public TagModel[] Tags { get; set; }
        public Guid SiteId { get; set; }
    }
}