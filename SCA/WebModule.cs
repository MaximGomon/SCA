using Autofac;
using SCA.BussinesLogic;
using SCA.Domain;

namespace SCA
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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