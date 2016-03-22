using System;

namespace SCA.Areas.Monitoring.Models
{
    public class ActivityModel
    {
        private DateTime _activityDate;
        public Guid Id { get; set; }

        public DateTime ActivityDate
        {
            set { _activityDate = value; }
        }

        public string ActivityDateAsString
        {
            get { return _activityDate.ToString("yyyy-MM-dd hh-mm-ss"); }
        }

        public string Type { get; set; } 
        public string UserName { get; set; }
        public string UserAgent { get; set; }
        public string Tags { get; set; }
    }
}