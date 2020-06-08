using System.Reflection;
using System.Web.Mvc;
using AspMVCAdminLTE.Infrastructure;
using AspMVCAdminLTE.Repository;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace AspMVCAdminLTE.App_Start
{
    public class AutofacConfig
    {
        public static Autofac.IContainer RegisterComponents()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
              .Where(x => x.Namespace.Contains("Repository"))
              .AsImplementedInterfaces();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(Controllers.DefaultController).Assembly);
            builder.RegisterType<LogManager>().As<ILogManager>().InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }
    }
}
