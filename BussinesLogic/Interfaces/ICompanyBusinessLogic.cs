using System;
using System.Linq;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface ICompanyBusinessLogic : IBaseBusinessLogic<Company>
    {
        void AddSiteToCompany(Guid id, Guid siteId);
        IQueryable<CompanyType> GetAllTypes();
        IQueryable<ClientSite> GetAllSites(Guid companyId);
        IQueryable<CompanySector> GetAllSectors();
        IQueryable<CompanyStatus> GetAllStatuses();
        IQueryable<CompanySize> GetAllSizes();
    }
}