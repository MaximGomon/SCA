using System;
using System.Linq;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface IActivityRepository : ICRUDRepository<Activity>
    {
        IQueryable<Activity> GetActivitiesByContactId(Guid contactId);
    }
}
