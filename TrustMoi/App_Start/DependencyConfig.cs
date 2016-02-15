using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using TrustMoi.Data;
using TrustMoi.Data.Base;
using TrustMoi.Services.Base;

namespace TrustMoi
{
    public class DependencyConfig
    {
        static readonly Assembly ServiceAssembly = typeof(ServiceBase).Assembly;
        static readonly Assembly MapperAssembly = typeof(MapperBase).Assembly;

        public static void Configure(ContainerBuilder builder)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            builder.RegisterType<Entities>().As<IDbContext>().InstancePerRequest();
            
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly).AsClosedTypesOf(typeof(IRepository<>)).InstancePerRequest();
            
            builder.RegisterAssemblyTypes(ServiceAssembly).Where(type => typeof(ServiceBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(MapperAssembly).Where(type => typeof(MapperBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterControllers(assemblies);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}