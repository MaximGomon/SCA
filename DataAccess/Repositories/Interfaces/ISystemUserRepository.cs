using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface ISystemUserRepository : ICRUDRepository<SystemUser>
    {
        SystemUser GetByLogin(string login);
    }
}