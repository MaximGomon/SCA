using System;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Models
{
    public class LeadTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; } 
    }
}