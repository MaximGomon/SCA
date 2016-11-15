using System;
using System.Linq;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;

namespace SCA.Areas.Monitoring.Converters
{
    public static class ContactConverter
    {
        public static Contact ConvertToDbContact(this ContactModel model)
        {
            var factory = new DatabaseFactory();
            var contactBusinessLogic = new ContactBusinessLogic(new ContactRepository(factory), new DictionaryBusinessLogic<ContactType>(new DictionaryRepository<ContactType>(factory)),
                new DictionaryBusinessLogic<ContactStatus>(new DictionaryRepository<ContactStatus>(factory)), new DictionaryBusinessLogic<AgeDirection>(new DictionaryRepository<AgeDirection>(factory)),
                new DictionaryBusinessLogic<ReadyToSellState>(new DictionaryRepository<ReadyToSellState>(factory)));

            var dbContact = contactBusinessLogic.GetById(model.Id);
            if (dbContact == null)
            {
                dbContact = new Contact();
            }
            dbContact.Age = contactBusinessLogic.GetAllAges().First(x => x.Id == model.AgeDirectionId);
            dbContact.BirthDate = model.BirthDate;
            dbContact.Comment = model.Comment;
            dbContact.CreateDate = DateTime.Now;
            dbContact.Email = model.Email;
            dbContact.Ip = model.ContactIp;
            dbContact.Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), model.Gender);
            dbContact.Link = model.ContactLink;
            dbContact.IsNameChecked = true;
            dbContact.ReadyToBuyScore = model.ReadyToBuyScore;
            dbContact.ReadyToSell = contactBusinessLogic.GetAllSellStatuses().First(x => x.Id == model.ReadyToSellId);
            //dbContact.Telephones = contact.Telephones.Split(';').ToList();
            dbContact.Status = contactBusinessLogic.GetAllStatuses().First(x => x.Id == model.StatusId);
            dbContact.Type = contactBusinessLogic.GetAllTypes().First(x => x.Id == model.ContactTypeId);
            dbContact.Name = model.Name;
            //dbContact.Id = model.Id;
            return dbContact;
        }

        public static ContactModel ConvertToContactModel(this Contact contact)
        {
            var model =  new ContactModel
            {

                ReadyToBuyScore = contact.Score,
                ReadyToSell = contact.ReadyToSell != null ? contact.ReadyToSell.Name : String.Empty,
                Name = contact.Name,
                CreateDate = contact.CreateDate,
                Email = contact.Email,
                Id = contact.Id, 
                ContactIp = contact.Ip,
                ContactLink = contact.Link,
                Status = contact.Status != null ? contact.Status.Name : String.Empty,
                AgeDirection = contact.Age != null ? contact.Age.Name : String.Empty,
                Comment = contact.Comment,
                ContactType = contact.Type != null ? contact.Type.Name : String.Empty,
                Gender = contact.Gender.ToString(),
            //    //Telephones = contact.Telephones.
            };
            if (contact.BirthDate.HasValue)
            {
                model.BirthDate = contact.BirthDate.Value;
            }
            return model;
        }
    }
}