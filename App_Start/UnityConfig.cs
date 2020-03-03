using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebAPI_DependencyInjection.Data;

namespace WebAPI_DependencyInjection
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>();
     
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}