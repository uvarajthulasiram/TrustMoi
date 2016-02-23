using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using TrustMoi.Data;
using TrustMoi.Data.Base;
using TrustMoi.Extensions;
using TrustMoi.Models;
using TrustMoi.Services.Base;

[assembly: OwinStartupAttribute(typeof(TrustMoi.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace TrustMoi
{
    public partial class Startup
    {
        private static readonly Assembly ServiceAssembly = typeof(ServiceBase).Assembly;
        private static readonly Assembly MapperAssembly = typeof(MapperBase).Assembly;

        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            builder.RegisterType<Entities>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly).AsClosedTypesOf(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterAssemblyTypes(ServiceAssembly).Where(type => typeof(ServiceBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(MapperAssembly).Where(type => typeof(MapperBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            builder.RegisterModule(new LoggingModule());

            builder.RegisterControllers(assemblies);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}
