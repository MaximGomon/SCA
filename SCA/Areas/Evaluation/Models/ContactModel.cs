using System;

namespace SCA.Areas.Evaluation.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ReadyToSell { get; set; }
        public string CompanyName { get; set; }
        public int Score { get; set; }  
    }
}