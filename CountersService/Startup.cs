using System;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SCA.CountersService.Startup))]

namespace SCA.CountersService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
