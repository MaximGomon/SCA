using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class SettingBusinessLogic : BaseBusinessLogic<SystemSettingRepository, SystemSetting>
    {
        public readonly SystemSettingRepository _settingRepository;
        public SettingBusinessLogic(SystemSettingRepository repository) : base(repository)
        {
            _settingRepository = repository;
        }

        public SystemSetting GetByKey(string key)
        {
            return Repository.GetByKey(key);
        }
    }
}