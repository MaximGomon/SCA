using System;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using SCA.Helpers;

namespace SCA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ScheduleTaskTrigger();
        }

        static void ScheduleTaskTrigger()
        {
            int timeout = int.Parse(ConfigurationManager.AppSettings["FbPingTimeout"] ?? "5");
            HttpRuntime.Cache.Add("ScheduledTaskTrigger",
                                  string.Empty,
                                  null,
                                  Cache.NoAbsoluteExpiration,
                                  TimeSpan.FromMinutes(timeout),
                                  CacheItemPriority.NotRemovable,
                                  new CacheItemRemovedCallback(PerformScheduledTasks));
        }

        static void PerformScheduledTasks(string key, Object value, CacheItemRemovedReason reason)
        {
            FbHelper.Authorize();
            FbHelper.GetSocialInfo();
            ScheduleTaskTrigger();
        }
    }
}
