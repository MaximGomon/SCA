using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class SettingBusinessLogic : BaseBusinessLogic<ISystemSettingRepository, SystemSetting>, ISettingBusinessLogic
    {
        private readonly ISystemSettingRepository _settingRepository;
        public SettingBusinessLogic(ISystemSettingRepository repository) : base(repository)
        {
            _settingRepository = repository;
        }

        public SystemSetting GetByKey(string key)
        {
            return Repository.GetByKey(key);
        }
    }
}