using System;
using System.Collections.Generic;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class CompanyBusinessLogic : BaseBusinessLogic<ICompanyRepository, Company>, ICompanyBusinessLogic
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IClientSiteBusinessLogic _siteBusinessLogic;
        private readonly IDictionaryBusinessLogic<CompanyType> _companyTypesLogic;
        private readonly IDictionaryBusinessLogic<CompanySector> _companySectorsLogic;
        private readonly IDictionaryBusinessLogic<CompanyStatus> _companyStatusesLogic;
        private readonly IDictionaryBusinessLogic<CompanySize> _companySizesLogic;

        public CompanyBusinessLogic(ICompanyRepository repository, IClientSiteBusinessLogic siteBusinessLogic,
            IDictionaryBusinessLogic<CompanyType> companyTypesLogic, IDictionaryBusinessLogic<CompanySector> companySectorsLogic,
            IDictionaryBusinessLogic<CompanyStatus> companyStatusesLogic, IDictionaryBusinessLogic<CompanySize> companySizesLogic) 
            : base(repository)
        {
            _companyRepository = repository;
            _siteBusinessLogic = siteBusinessLogic;
            _companyTypesLogic = companyTypesLogic;
            _companySectorsLogic = companySectorsLogic;
            _companyStatusesLogic = companyStatusesLogic;
            _companySizesLogic = companySizesLogic;
        }

        public void AddSiteToCompany(Guid id, Guid siteId)
        {
            var company = _companyRepository.GetById(id);
            var site = _siteBusinessLogic.GetById(siteId);
            if(company.Sites == null)
                company.Sites = new List<ClientSite>();
            company.Sites.Add(site);
            _companyRepository.Update(company);
        }

        public CompanyType GetTypeById(Guid id)
        {
            return _companyTypesLogic.GetById(id);
        }

        public ClientSite GetClientSiteById(Guid id)
        {
            return _siteBusinessLogic.GetById(id);
        }

        public IQueryable<CompanyType> GetAllTypes()
        {
            return _companyTypesLogic.GetAllEntities();
        }

        public IQueryable<CompanySize> GetAllSizes()
        {
            return _companySizesLogic.GetAllEntities();
        }

        public IQueryable<ClientSite> GetAllSites(Guid companyId)
        {
            return _siteBusinessLogic.GetAllEntities().Where(x => x.Owner.Id == companyId);
        }

        public IQueryable<CompanySector> GetAllSectors()
        {
            return _companySectorsLogic.GetAllEntities();
        }

        public IQueryable<CompanyStatus> GetAllStatuses()
        {
            return _companyStatusesLogic.GetAllEntities();
        }
    }
}