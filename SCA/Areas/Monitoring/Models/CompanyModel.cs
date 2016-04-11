using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class CompanyModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public Guid OwnerId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public SiteModel[] Sites { get; set; }
        public string Status { get; set; }
        public Guid StatusId { get; set; }
        public string Type { get; set; }
        public Guid TypeId { get; set; }
        public string Size { get; set; }
        public Guid SizeId { get; set; }
        public string Sector { get; set; }
        public Guid SectorId { get; set; }
    }
}