using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface ISystemUserTypeRepository : ICRUDRepository<SystemUserType>
    {
        SystemUser GetByLogin(string login);
    }
}