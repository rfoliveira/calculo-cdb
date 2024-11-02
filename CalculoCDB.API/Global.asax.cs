using Autofac.Integration.WebApi;
using CalculoCDB.API.App_Start;
using System.Web.Http;

namespace CalculoCDB.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            var container = DependencyInjectionConfig.Configure();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.Formatters.Configure();
        }
    }
}
