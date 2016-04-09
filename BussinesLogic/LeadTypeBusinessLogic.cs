using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class LeadTypeBusinessLogic: BaseBusinessLogic<LeadTypeRepository, LeadType>
    {
        private readonly LeadTypeRepository _leadTypeRepository;
        public LeadTypeBusinessLogic(LeadTypeRepository repository) : base(repository)
        {
            _leadTypeRepository = repository;
        }
    }
}