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
    }
}