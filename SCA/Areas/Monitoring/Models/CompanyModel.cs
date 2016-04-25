using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class CompanyModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        public Guid Id { get; set; }
        [Display(Name = "Владелец")]
        public string OwnerName { get; set; }
        public Guid OwnerId { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime CreateDate { get; set; }
        public SiteModel[] Sites { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        public Guid StatusId { get; set; }
        [Display(Name = "Тип")]
        public string Type { get; set; }
        public Guid TypeId { get; set; }
        [Display(Name = "Количество сотрудников")]
        public string Size { get; set; }
        public Guid SizeId { get; set; }
        [Display(Name = "Отрасль")]
        public string Sector { get; set; }
        public Guid SectorId { get; set; }
    }
}