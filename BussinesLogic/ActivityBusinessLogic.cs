using System;
using System.Linq;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ActivityBusinessLogic : BaseBusinessLogic<ActivityRepository, Activity>
    {
        private readonly ActivityRepository _activityRepository;
        public ActivityBusinessLogic(ActivityRepository repository) : base(repository)
        {
            _activityRepository = repository;
        }

        public IQueryable<Activity> GetActivitiesByContactId(Guid contactId)
        {
            return _activityRepository.GetActivitiesByContactId(contactId);
        } 
    }
}