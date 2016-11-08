using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface ISystemUserBusinessLogic : IBaseBusinessLogic<SystemUser>
    {
        SystemUser GetSystemUser(string login);
    }
}