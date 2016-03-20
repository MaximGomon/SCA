using System;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;

namespace SCA.Areas.Monitoring.Converters
{
    public class ContactModelToDb
    {
        public Contact Convert(ContactModel model)
        {
            var ageDirectionLogic = new DictionaryBusinessLogic<AgeDirection>(new DictionaryRepository<AgeDirection>()); 
            var contact = new Contact
            {
                Age = ageDirectionLogic.GetByCode(model.AgeCode),
                BirthDate = model.BirthDate,
                CreateDate = DateTime.Now,
                Email = model.Email,
                Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), model.Gender),
                IsDeleted = false,
                
            };
            return contact;
        }
    }
}