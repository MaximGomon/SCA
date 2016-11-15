using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SCA.BussinesLogic;
using SCA.Helpers;

namespace SCA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container { get; private set; }

        internal static Assembly Assembly { get; private set; }

        protected void Start(Assembly executingAssembly)
        {
            MvcApplication.Assembly = executingAssembly;
            var builder = new ContainerBuilder();
            var assembly = typeof(MvcApplication).Assembly;
            builder.RegisterControllers(assembly);
            builder.RegisterFilterProvider();
            builder.RegisterModule(new WebModule());
           // builder.RegisterModule(new BusinessLogicModule());
            MvcApplication.Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            
        }

        protected virtual void Application_End()
        {
            ((IDisposable)MvcApplication.Container).Dispose();
        }
        protected void Application_Start()
        {
            Start(typeof(MvcApplication).Assembly);
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
