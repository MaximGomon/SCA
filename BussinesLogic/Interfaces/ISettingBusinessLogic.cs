using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface ISettingBusinessLogic : IBaseBusinessLogic<SystemSetting>
    {
        SystemSetting GetByKey(string key);
    }
}