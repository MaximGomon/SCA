using System;
using System.Linq;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface IActivityBusinessLogic : IBaseBusinessLogic<Activity>
    {
        IQueryable<Activity> GetActivitiesByContactId(Guid contactId);
        Tag GetTagByName(String name);
        ActivityType GetActivityType(int code);
        void InsertNew(Activity item);
    }
}