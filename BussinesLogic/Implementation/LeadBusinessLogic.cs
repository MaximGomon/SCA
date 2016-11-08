using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class LeadBusinessLogic : BaseBusinessLogic<ILeadRepository, Lead>, ILeadBusinessLogic
    {
        private readonly ILeadRepository _leadRepository;
        public LeadBusinessLogic(ILeadRepository repository) : base(repository)
        {
            _leadRepository = repository;
        }
    }
}