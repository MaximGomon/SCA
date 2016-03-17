using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface IContactRepository : ICRUDRepository<Contact>, INamedRepository<Contact>
    {
        Contact GetByLogin(string login);
    }
}