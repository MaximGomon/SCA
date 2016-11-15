using System.Data.Entity.Migrations;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class SystemSettingRepository : CrudRepository<SystemSetting>, ISystemSettingRepository
    {
        public SystemSettingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public SystemSetting GetByKey(string key)
        {
            return GetAllEntities().First(x => x.Key == key);
        }

        public override void Add(SystemSetting entity)
        {
            base.Add(entity);
            SaveChanges();
        }
    }
}