using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.CountersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CounterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CounterService.svc or CounterService.svc.cs at the Solution Explorer and start debugging.
    public class CounterService : ICounterService
    {
        public void DoWork(CounterData data)
        {
            IncomingWebRequestContext context = WebOperationContext.Current.IncomingRequest;
            data.Agent = context.UserAgent;
            Domain.Activity activity = new Domain.Activity();
            //Contact contact = new Contact();
            var contactLogic = new ContactBusinessLogic(new ContactRepository());
            var tagLogic = new TagBusinessLogic(new TagRepository());
            var activityLogic = new ActivityBusinessLogic(new ActivityRepository());
            Contact contact = contactLogic.GetAllEntities().Where(x => x.Ip == data.Ip).FirstOrDefault();
            if (contact == null)
            {
                contact = new Contact
                {
                    Ip = data.Ip,
                    Name = data.Ip
                };
            }
            contactLogic.Add(contact);
            activity.Author = contact;
            activity.CreateDate = DateTime.Now;
            activity.Cookie = data.Cookie;
            activity.UserAgent = data.Agent;
           // activity.Tag = 
            foreach (var item in data.Tags.Split(',').ToList())
            {
                var tag = tagLogic.GetByName(item);
                if (tag != null)
                {
                    activity.Tag.Add(tag);
                }
                else
                {
                    //TODO Выпилить и выдавать ошибку в лог на этом этапе
                    tagLogic.Add(new Tag {Name = item});
                }
            }
            activityLogic.Add(activity);

        }
    }
}
