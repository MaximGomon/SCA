using System;

namespace SCA.Areas.Monitoring.Models
{
    public class CompanyModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public Guid OwnerId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public SiteModel[] Sites { get; set; }
        public string Status { get; set; }
        public Guid StatusId { get; set; }
    }
}