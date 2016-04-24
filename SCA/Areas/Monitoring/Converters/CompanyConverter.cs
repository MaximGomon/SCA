using System;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Converters
{
    public static class CompanyConverter
    {
        public static Company ConvertToDbCompany(this CompanyModel model)
        {
            var typeBusinessLogic = new DictionaryBusinessLogic<CompanyType>(new DictionaryRepository<CompanyType>());
            var statusBusinessLogic = new DictionaryBusinessLogic<CompanyStatus>(new DictionaryRepository<CompanyStatus>());
            var sizeBusinessLogic = new DictionaryBusinessLogic<CompanySize>(new DictionaryRepository<CompanySize>());
            var sectorBusinessLogic = new DictionaryBusinessLogic<CompanySector>(new DictionaryRepository<CompanySector>());
            var contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
            var companyBusinessLogic = new CompanyBusinessLogic(new CompanyRepository());

            var company = companyBusinessLogic.GetById(model.Id);

            company.Comment = model.Comment;
            //company.CreateDate = DateTime.Now;
            company.Name = model.Name;
            //company.IsDeleted = false;
            company.Type = typeBusinessLogic.GetById(model.TypeId);
            company.Size = sizeBusinessLogic.GetById(model.SizeId);
            company.Sector = sectorBusinessLogic.GetById(model.SectorId);
            company.Status = statusBusinessLogic.GetById(model.StatusId);
            company.Owner = contactBusinessLogic.GetById(model.OwnerId);
            return company;
        }

        public static CompanyModel ConvertToCompanyModel(this Company company)
        {
            var result = new CompanyModel();
            result.Id = company.Id;
            result.Name = company.Name;
            result.CreateDate = company.CreateDate;
            result.Comment = company.Comment;
            result.OwnerName = company.Owner != null ? company.Owner.Name : String.Empty;
            result.Sector = company.Sector != null ? company.Sector.Name : String.Empty;
            result.Size = company.Size != null ? company.Size.Name : String.Empty;
            result.Status = company.Status != null ? company.Status.Name : String.Empty;
            result.Type = company.Type != null ? company.Type.Name : String.Empty;
            return result;
        }
    }
}