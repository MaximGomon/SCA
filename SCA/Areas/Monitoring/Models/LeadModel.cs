using System;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Models
{
    public class LeadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public Tag[] Tags { get; set; } 
    }
}