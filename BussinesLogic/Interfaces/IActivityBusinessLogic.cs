using System;
using System.Linq;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface IActivityBusinessLogic
    {
        IQueryable<Activity> GetActivitiesByContactId(Guid contactId);
    }
}