using System;
using SCA.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
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