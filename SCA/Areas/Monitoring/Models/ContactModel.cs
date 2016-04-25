using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Areas.Monitoring.Models
{
    public class ContactModel
    {
        private DateTime _createDateTime;
        public Guid Id { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime CreateDate
        {
            set { _createDateTime = value; }
            get { return _createDateTime; }
        }
        [Display(Name = "Дата создания")]
        public string CreateDateAsString
        {
            get { return _createDateTime.ToString("yyyy-MM-dd hh-mm-ss"); }
        }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "IP")]
        public string ContactIp { get; set; }
        [Display(Name = "Ссылка")]
        public string ContactLink { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Готовность к продаже")]
        public string ReadyToSell { get; set; }
        public Guid ReadyToSellId { get; set; }
        [Display(Name = "Заказчик")]
        public string CompanyName { get; set; }
        public Guid CompanyId { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        public Guid StatusId { get; set; }
        [Display(Name = "Возраст")]
        public string AgeDirection { get; set; }
        public Guid AgeDirectionId { get; set; }
        [Display(Name = "Тип")]
        public string ContactType { get; set; }
        public Guid ContactTypeId { get; set; }
        [Display(Name = "Очков для покупки")]
        public int ReadyToBuyScore { get; set; }
        [Display(Name = "Возраст (код)")]
        public int AgeCode { get; set; }
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        public int GenderCode { get; set; }
        [Display(Name = "Комментарии")]
        public string Comment { get; set; }
        [Display(Name = "Телефон")]
        public string Telephones { get; set; }
    }
}