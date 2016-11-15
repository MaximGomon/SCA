using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using SCA.BussinesLogic;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;

namespace SCA.CountersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CounterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CounterService.svc or CounterService.svc.cs at the Solution Explorer and start debugging.
    public class CounterService : ICounterService
    {
        private readonly IActivityBusinessLogic _activityBusinessLogic;
        private readonly IContactBusinessLogic _contactBusinessLogic;
        public CounterService()
        {
            var factory = new DatabaseFactory();
            _activityBusinessLogic = new ActivityBusinessLogic(new ActivityRepository(factory), new TagBusinessLogic(new TagRepository(factory))
                , new DictionaryBusinessLogic<ActivityType>(new DictionaryRepository<ActivityType>(factory)) );
            _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository(factory));
        }

        public string DoWork(CounterData data)
        {
            IncomingWebRequestContext context = WebOperationContext.Current?.IncomingRequest;
            data.Agent = context?
                .UserAgent;
            var coockie = data.Cookie.Replace('\"', ' ').Trim();
            Contact contact = _activityBusinessLogic.GetAllEntities()
                    .FirstOrDefault(x => (x.Cookie == coockie && x.UserAgent == data.Agent) || x.Ip == data.Ip)?
                    .Author;
            if (contact == null)
            {
                contact = new Contact
                {
                    Ip = data.Ip,
                    Name = data.Ip
                };
                contact.CreateDate = DateTime.Now;
                _contactBusinessLogic.Add(contact);
            }
            string returns = Guid.NewGuid().ToString();


            Activity activity = new Activity();
            activity.Author = contact;
            activity.CreateDate = DateTime.Now;
            if (data.Cookie != null)
            {
                activity.Cookie = data.Cookie;
            }
            else
            {
                activity.Cookie = returns;
            }
            activity.UserAgent = data.Agent;
            activity.Type = _activityBusinessLogic.GetActivityType(int.Parse(ActivityEnum.Visit.ToString("D")));
            //activity.TypeCode = int.Parse(ActivityEnum.Visit.ToString("D"));
            foreach (var item in data.Tags.Split(',').ToList())
            {
                var tag = _activityBusinessLogic.GetTagByName(item);
                if (tag != null)
                {
                    if (activity.Tag == null)
                    {
                        activity.Tag = new List<Tag>();
                    }
                    activity.Tag.Add(tag);
                }
                else
                {
                    //TODO Выпилить и выдавать ошибку в лог на этом этапе
                    var tg = new Tag { Name = item };
                    //activityLogic.Add(tg);
                    activity.Tag.Add(tg);
                }
            }
            _activityBusinessLogic.InsertNew(activity);
            return activity.Cookie;
        }
    }
}
