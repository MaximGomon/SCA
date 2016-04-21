using System;
using System.Collections.Generic;
using SCA.Domain.Enums;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    /// <summary>
    /// Контакт, человек в системе
    /// </summary>
    public class Contact : NamedEntity, ICreatedBy, IChangedBy, ICommented
    {
        /// <summary>
        /// Перечен его телефонніх номеров
        /// </summary>
        public virtual ICollection<string> Telephones { get; set; }
        public virtual string Email { get; set; }
        /// <summary>
        /// Родительский контакт
        /// </summary>
        public virtual Contact Parent { get; set; }
        /// <summary>
        /// Ответственный исполнитель, человек, который закреплен за контактом
        /// </summary>
        //public virtual Employee Executor { get; set; }
        /// <summary>
        /// Текущее количество балов
        /// </summary>
        public virtual int Score { get; set; }
        /// <summary>
        /// Количество балов, когда контакт "готов к покупке"
        /// </summary>
        public virtual int ReadyToBuyScore { get; set; }
        /// <summary>
        /// Преверено ли имя контакта
        /// </summary>
        public virtual bool IsNameChecked { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }
        /// <summary>
        /// Коментарии
        /// </summary>
        public virtual string Comment { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public virtual GenderEnum Gender { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public virtual AgeDirection Age { get; set; }
        /// <summary>
        /// IP адресс контакта
        /// </summary>
        public virtual string Ip { get; set; }
        /// <summary>
        /// Связанные контакты
        /// </summary>
        public virtual ICollection<Contact> LinkedContacts { get; set; }
        /// <summary>
        /// Дата последней активности контакта
        /// </summary>
        public virtual DateTime? LastActivityDate { get; set; }
        /// <summary>
        /// Состояние готовности к покупке
        /// </summary>
        public virtual ReadyToSellState ReadyToSell { get; set; }
        /// <summary>
        /// Список всех подтвержденных профилей соцсетей для контакта
        /// </summary>
        public virtual ContactStatus Status { get; set; }
        public virtual ContactType Type { get; set; }
        /// <summary>
        /// Адрес пользователя в соцсетях
        /// </summary>
        public virtual string Link { get; set; }
        public virtual ICollection<SocialNetworkEvent> SocialProfiles {get; set; }
        public virtual ICollection<ClientSitePage> ViewedPages { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual SystemUser CreatedBy { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
        public virtual SystemUser ChangedBy { get; set; }
    }
}
