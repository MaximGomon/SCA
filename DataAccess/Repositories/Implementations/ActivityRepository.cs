using System;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ActivityRepository : CrudRepository<Activity>, IActivityRepository
    {
        //public IQueryable<Activity> GetActivitiesByContactId(Guid contactId)
        //{
        //    return DbContext.Activities.Where(x => x.)
        //}
    }
}