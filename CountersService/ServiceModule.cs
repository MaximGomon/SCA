using Autofac;
using SCA.BussinesLogic;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.DataAccess.Repositories.Interfaces;

namespace SCA.CountersService
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CounterService>().As<ICounterService>();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            builder.RegisterGeneric(typeof(CrudRepository<>)).As(typeof(ICRUDRepository<>)).SingleInstance();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().SingleInstance();
            builder.RegisterType<ClientSitePageRepository>().As<IClientSitePageRepository>().SingleInstance();
            builder.RegisterType<ClientSiteRepository>().As<IClientSiteRepository>().SingleInstance();
            builder.RegisterGeneric(typeof(DictionaryRepository<>)).As(typeof(IDictionaryRepository<>)).SingleInstance();
            builder.RegisterType<ActivityBusinessLogic>().As<IActivityBusinessLogic>().SingleInstance();
            builder.RegisterType<ClientSiteBusinessLogic>().As<IClientSiteBusinessLogic>().SingleInstance();
            builder.RegisterType<ClientSitePagesBusinessLogic>().As<IClientSitePagesBusinessLogic>().SingleInstance();
            builder.RegisterType<CompanyBusinessLogic>().As<ICompanyBusinessLogic>().SingleInstance();
            builder.RegisterType<ContactBusinessLogic>().As<IContactBusinessLogic>().SingleInstance();
            builder.RegisterGeneric(typeof(DictionaryBusinessLogic<>)).As(typeof(IDictionaryBusinessLogic<>)).SingleInstance();
            builder.RegisterType<LeadBusinessLogic>().As<ILeadBusinessLogic>().SingleInstance();
            builder.RegisterType<LeadTypeBusinessLogic>().As<ILeadTypeBusinessLogic>().SingleInstance();
            builder.RegisterType<SettingBusinessLogic>().As<ISettingBusinessLogic>().SingleInstance();
            builder.RegisterType<SystemUserBusinessLogic>().As<ISystemUserBusinessLogic>().SingleInstance();
            builder.RegisterType<TagBusinessLogic>().As<ITagBusinessLogic>().SingleInstance();
            //base.Load(builder);
        }
    }
}