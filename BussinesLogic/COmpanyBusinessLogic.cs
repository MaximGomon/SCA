using System;
using System.Collections.Generic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class CompanyBusinessLogic : BaseBusinessLogic<CompanyRepository, Company>
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyBusinessLogic(CompanyRepository repository) : base(repository)
        {
            _companyRepository = repository;
        }

        public void AddSiteToCompany(Guid id, Guid siteId)
        {
            var company = _companyRepository.GetById(id);
            var siteLogic = new ClientSiteBusinessLogic(new ClientSiteRepository());
            var site = siteLogic.GetById(siteId);
            if(company.Sites == null)
                company.Sites = new List<ClientSite>();
            company.Sites.Add(site);
            _companyRepository.Update(company);
        }
    }
}