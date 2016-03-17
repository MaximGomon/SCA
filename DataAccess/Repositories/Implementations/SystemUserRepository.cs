using System.Linq;
using System.Data.Entity;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class SystemUserRepository: CrudRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUser GetByLogin(string login)
        {
            return DbContext.SystemUsers.Where(x => x.Login == login).Select(x => x).Include(x => x.Type).FirstOrDefault();
        }
    }
}