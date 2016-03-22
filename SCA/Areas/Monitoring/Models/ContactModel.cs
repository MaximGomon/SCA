using System;
using SCA.Domain.Enums;

namespace SCA.Areas.Monitoring.Models
{
    public class ContactModel
    {
        private DateTime _createDateTime;
        public Guid Id { get; set; }

        public DateTime CreateDate
        {
            set { _createDateTime = value; }
        }

        public string CreateDateAsString
        {
            get { return _createDateTime.ToString("yyyy-MM-dd hh-mm-ss"); }
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string ReadyToSell { get; set; }
        public int ReadyToSellCode { get; set; }
        public string CompanyName { get; set; }
        public int Score { get; set; }
        public int AgeCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}