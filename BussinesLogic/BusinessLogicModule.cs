using Autofac;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().SingleInstance();
            
            builder.RegisterType<ContactRepository>().As<IContactRepository>().SingleInstance();
            builder.RegisterType<ClientSitePageRepository>().As<IClientSitePageRepository>().SingleInstance();
            builder.RegisterType<ClientSiteRepository>().As<IClientSiteRepository>().SingleInstance();
            builder.RegisterGeneric(typeof(DictionaryRepository<>)).As(typeof(IDictionaryRepository<>)).SingleInstance();
            //builder.RegisterType<LeadBusinessLogic>().As<ILeadBusinessLogic>().SingleInstance();
            //builder.RegisterType<LeadTypeBusinessLogic>().As<ILeadTypeBusinessLogic>().SingleInstance();
            //builder.RegisterType<SettingBusinessLogic>().As<ISettingBusinessLogic>().SingleInstance();
            //builder.RegisterType<SystemUserBusinessLogic>().As<ISettingBusinessLogic>().SingleInstance();
            //builder.RegisterType<TagBusinessLogic>().As<ITagBusinessLogic>().SingleInstance();
            //base.Load(builder);
        }
    }
}