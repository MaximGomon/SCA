using System;
using System.Runtime.Serialization;

namespace SCA.Areas.Monitoring.Models
{
    [DataContract]
    public class SitePageModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string PageName { get; set; }
        [DataMember]
        public string RelatedUrl { get; set; }
        [DataMember]
        public string Tag { get; set; }
        public TagModel[] Tags { get; set; }
        [DataMember]
        public Guid SiteId { get; set; }
    }
}