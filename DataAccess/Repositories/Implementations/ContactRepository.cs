using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ContactRepository : CrudRepository<Contact>, IContactRepository
    {
        public Contact GetByName(string name)
        {
            return DbContext.Contacts.FirstOrDefault(x => x.Name == name);
        }

        public Contact GetByLogin(string login)
        {
            throw new System.NotImplementedException();
        }
    }
}