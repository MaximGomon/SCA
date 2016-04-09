using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class LeadBusinessLogic : BaseBusinessLogic<LeadRepository, Lead>
    {
        private readonly LeadRepository _leadRepository;
        public LeadBusinessLogic(LeadRepository repository) : base(repository)
        {
            _leadRepository = repository;
        }
    }
}