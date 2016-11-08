using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class LeadTypeBusinessLogic: BaseBusinessLogic<ILeadTypeRepository, LeadType>, ILeadTypeBusinessLogic
    {
        private readonly ILeadTypeRepository _leadTypeRepository;
        public LeadTypeBusinessLogic(ILeadTypeRepository repository) : base(repository)
        {
            _leadTypeRepository = repository;
        }
    }
}