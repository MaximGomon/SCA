using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class SystemUserBusinessLogic : BaseBusinessLogic<SystemUserRepository, SystemUser>
    {
        private readonly SystemUserRepository _systemUserRepository;

        public SystemUserBusinessLogic(SystemUserRepository systemUserRepositoryrepository)
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