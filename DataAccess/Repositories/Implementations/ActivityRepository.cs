using System;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ActivityRepository : CrudRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public IQueryable<Activity> GetActivitiesByContactId(Guid contactId)
        {
            return GetAllEntities().Where(x => x.Author.Id == contactId);
        }
    }
}