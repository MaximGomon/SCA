using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ContactRepository : CrudRepository<Contact>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public Contact GetByName(string name)
        {
            return GetAllEntities().FirstOrDefault(x => x.Name == name);
        }
        public Contact GetByIp(string ip)
        {
            return GetAllEntities().FirstOrDefault(x => x.Ip == ip);
        }

        public Contact GetByLogin(string login)
        {
            throw new System.NotImplementedException();
        }
    }
}