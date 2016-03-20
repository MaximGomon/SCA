using System;

namespace SCA.Areas.Monitoring.Models
{
    public class ActivityModel
    {
        public Guid Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Type { get; set; } 
        public string UserName { get; set; }
        
    }
}