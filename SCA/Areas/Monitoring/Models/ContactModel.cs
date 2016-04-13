using System;
using SCA.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class ContactModel
    {
        private DateTime _createDateTime;
        public Guid Id { get; set; }

        public DateTime CreateDate
        {
            set { _createDateTime = value; }
            get { return _createDateTime; }
        }

        public string CreateDateAsString
        {
            get { return _createDateTime.ToString("yyyy-MM-dd hh-mm-ss"); }
        }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string ReadyToSell { get; set; }
        public Guid ReadyToSellId { get; set; }
        public string CompanyName { get; set; }
        public Guid CompanyId { get; set; }
        public string Status { get; set; }
        public Guid StatusId { get; set; }
        public string AgeDirection { get; set; }
        public Guid AgeDirectionId { get; set; }
        public string ContactType { get; set; }
        public Guid ContactTypeId { get; set; }
        public int ReadyToBuyScore { get; set; }
        public int AgeCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public int GenderCode { get; set; }
        public string Comment { get; set; }
        public string Telephones { get; set; }
    }
}