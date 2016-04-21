using System.Data.Entity.Migrations;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class SystemSettingRepository : CrudRepository<SystemSetting>, ISystemSettingRepository
    {
        public SystemSetting GetByKey(string key)
        {
            return DbContext.SystemSettings.First(x => x.Key == key);
        }

        public override void Add(SystemSetting entity)
        {
            DbContext.Set<SystemSetting>().AddOrUpdate(entity);
            SaveChanges();
        }
    }
}