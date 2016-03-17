using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ContactRepository : CrudRepository<Contact>, IContactRepository
    {
        public Contact GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Contact GetByLogin(string login)
        {
            throw new System.NotImplementedException();
        }
    }
}