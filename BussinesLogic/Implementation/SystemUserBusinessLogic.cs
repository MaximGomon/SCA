using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class SystemUserBusinessLogic : BaseBusinessLogic<ISystemUserRepository, SystemUser>, ISystemUserBusinessLogic
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserBusinessLogic(ISystemUserRepository systemUserRepositoryrepository)
            : base(systemUserRepositoryrepository)
        {
            _systemUserRepository = systemUserRepositoryrepository;
        }
        public SystemUser GetSystemUser(string login)
        {
            return _systemUserRepository.GetByLogin(login);
        }
    }
}