using System;
using System.Linq;
using Kendo.Mvc.Extensions;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Converters
{
    public static class CompanyConverter
    {
        public static Company ConvertToDbCompany(this CompanyModel model, ICompanyBusinessLogic companyBusinessLogic
            , IContactBusinessLogic contactBusinessLogic)
        {
            var company = companyBusinessLogic.GetById(model.Id);

            company.Comment = model.Comment;
            //company.CreateDate = DateTime.Now;
            company.Name = model.Name;
            company.Sites.AddRange(companyBusinessLogic.GetAllSites(company.Id));
            //company.IsDeleted = false;
            company.Type = companyBusinessLogic.GetAllTypes().First(x => x.Id == model.TypeId);
            company.Size = companyBusinessLogic.GetAllSizes().First(x => x.Id == model.SizeId);
            company.Sector = companyBusinessLogic.GetAllSectors().First(x => x.Id == model.SectorId);
            company.Status = companyBusinessLogic.GetAllStatuses().First(x => x.Id == model.StatusId);
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