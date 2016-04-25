using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SCA.Areas.Monitoring.Models
{
    [DataContract]
    public class SitePageModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        [Display(Name = "Название")]
        public string PageName { get; set; }
        [DataMember]
        [Display(Name = "Относительный адрес")]
        public string RelatedUrl { get; set; }
        [DataMember]
        [Display(Name = "Теги")]
        public string Tag { get; set; }
        public TagModel[] Tags { get; set; }
        [DataMember]
        public Guid SiteId { get; set; }
    }
}