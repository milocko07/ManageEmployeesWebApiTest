using ManageEmployees.Business;
using ManageEmployees.Data.Access;
using ManageEmployees.Data.Interfaces;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace ManageEmployees.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            SimpleInjectorRegistration();

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SimpleInjectorRegistration()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IEmployeeAccess, EmployeeAccess>(Lifestyle.Scoped);
            container.Register<IEmployeeBusiness, EmployeeBusiness>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
