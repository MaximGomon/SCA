using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ContactBusinessLogic : BaseBusinessLogic<IContactRepository, Contact>, IContactBusinessLogic
    {
        private readonly IDictionaryBusinessLogic<ContactType> _typeLogic;
        private readonly IDictionaryBusinessLogic<ContactStatus> _statusLogic;
        private readonly IDictionaryBusinessLogic<AgeDirection> _ageLogic;
        private readonly IDictionaryBusinessLogic<ReadyToSellState> _readyToSellLogic;
        public ContactBusinessLogic(IContactRepository repository, IDictionaryBusinessLogic<ContactType> typeLogic, 
            IDictionaryBusinessLogic<ContactStatus> statusLogic, IDictionaryBusinessLogic<AgeDirection> ageLogic, 
            IDictionaryBusinessLogic<ReadyToSellState> readyToSellLogic) : base(repository)
        {
            _typeLogic = typeLogic;
            _statusLogic = statusLogic;
            _ageLogic = ageLogic;
            _readyToSellLogic = readyToSellLogic;
        }

        public Contact GetByName(string name)
        {
            return Repository.GetByName(name);
        }

        public Contact GetByLogin(string login)
        {
            return Repository.GetByLogin(login);
        }

        public Contact GetByIp(string ip)
        {
            return Repository.GetByIp(ip);
        }

        public IQueryable<ContactType> GetAllTypes()
        {
            return _typeLogic.GetAllEntities();
        }

        public IQueryable<ContactStatus> GetAllStatuses()
        {
            return _statusLogic.GetAllEntities();
        }

        public IQueryable<AgeDirection> GetAllAges()
        {
            return _ageLogic.GetAllEntities();
        }

        public IQueryable<ReadyToSellState> GetAllSellStatuses()
        {
            return _readyToSellLogic.GetAllEntities();
        }
    }
}
