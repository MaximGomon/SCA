using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ContactBusinessLogic : BaseBusinessLogic<IContactRepository, Contact>, IContactBusinessLogic
    {
        private readonly IContactRepository _contactRepository;

        public ContactBusinessLogic(IContactRepository repository) : base(repository)
        {
            _contactRepository = repository;
        }

        public Contact GetByName(string name)
        {
            return _contactRepository.GetByName(name);
        }

        public Contact GetByLogin(string login)
        {
            return _contactRepository.GetByLogin(login);
        }

        public Contact GetByIp(string ip)
        {
            return _contactRepository.GetByIp(ip);
        }

        public IQueryable<ContactType> GetAllTypes()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ContactStatus> GetAllStatuses()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<AgeDirection> GetAllAges()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ReadyToSellState> GetAllSellStatuses()
        {
            throw new System.NotImplementedException();
        }
    }
}
