using System.Linq;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface IContactBusinessLogic : IBaseBusinessLogic<Contact>
    {
        Contact GetByName(string name);

        Contact GetByLogin(string login);

        Contact GetByIp(string ip);
        IQueryable<ContactType> GetAllTypes();
        IQueryable<ContactStatus> GetAllStatuses();
        IQueryable<AgeDirection> GetAllAges();
        IQueryable<ReadyToSellState> GetAllSellStatuses();
    }
}