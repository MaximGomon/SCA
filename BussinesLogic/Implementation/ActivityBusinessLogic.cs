using System;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ActivityBusinessLogic : BaseBusinessLogic<IActivityRepository, Activity>, IActivityBusinessLogic
    {
        private readonly ITagBusinessLogic _tagBusinessLogic;
        private readonly IDictionaryBusinessLogic<ActivityType> _activityTypeLogic;
        public ActivityBusinessLogic(IActivityRepository repository, ITagBusinessLogic tagBusinessLogic, 
            IDictionaryBusinessLogic<ActivityType> activityTypeLogic) : base(repository)
        {
            _tagBusinessLogic = tagBusinessLogic;
            _activityTypeLogic = activityTypeLogic;
        }

        public void InsertNew(Activity item)
        {
            
            //Repository.Attach(item.Type);
            Repository.Add(item);
        }

        public IQueryable<Activity> GetActivitiesByContactId(Guid contactId)
        {
            return Repository.GetActivitiesByContactId(contactId);
        }

        public Tag GetTagByName(String name)
        {
            var result = _tagBusinessLogic.GetByName(name);
            if (result == null)
            {
                result = new Tag
                {
                    Name = name,
                    IsDeleted = false
                };
                _tagBusinessLogic.Add(result);
            }
            return result;
        }

        public ActivityType GetActivityType(int code)
        {
            var result = _activityTypeLogic.GetByCode(code);
            return result;
        }
    }
}