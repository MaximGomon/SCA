using System;
using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ActivityBusinessLogic : BaseBusinessLogic<IActivityRepository, Activity>, IActivityBusinessLogic
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityBusinessLogic(IActivityRepository repository) : base(repository)
        {
            _activityRepository = repository;
        }

        public IQueryable<Activity> GetActivitiesByContactId(Guid contactId)
        {
            return _activityRepository.GetActivitiesByContactId(contactId);
        } 
    }
}