using System.Linq;
using System.Data.Entity;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class SystemUserRepository: CrudRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public SystemUser GetByLogin(string login)
        {
            return GetAllEntities().Where(x => x.Login == login).Select(x => x).Include(x => x.Type).FirstOrDefault();
        }
    }
}