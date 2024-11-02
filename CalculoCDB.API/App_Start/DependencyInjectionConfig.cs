using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace CalculoCDB.API.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static IContainer Configure()
        {
            var app = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(app);
            builder.RegisterAssemblyTypes(app)
                .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}