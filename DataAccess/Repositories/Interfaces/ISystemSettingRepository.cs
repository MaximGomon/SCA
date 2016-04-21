using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface ISystemSettingRepository : ICRUDRepository<SystemSetting>
    {
        SystemSetting GetByKey(string key);
    }
}