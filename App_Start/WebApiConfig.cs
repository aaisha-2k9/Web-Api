using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebAPI_DependencyInjection.Data;
using Unity.Lifetime;
using WebAPI_DependencyInjection.CustomHandler;

namespace WebAPI_DependencyInjection
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Registering Dependency Resolver
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>(new TransientLifetimeManager());
        
            config.DependencyResolver = new UnityDependencyResolver(container);
            //Custom Message Handlers
            config.MessageHandlers.Add(new RequestvalidateHandler());
            config.MessageHandlers.Add(new MethodOverrideHandler());
            config.MessageHandlers.Add(new CustomHeaderHandler());
            config.MessageHandlers.Add(new SeesionIDHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "StudentV1",
                routeTemplate: "api/v1/students/{id}",
                defaults: new {Controllers= "StudentsV1", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "StudentV2",
                routeTemplate: "api/v2/students/{id}",
                defaults: new { Controllers = "StudentsV2", id = RouteParameter.Optional }
            ); config.Routes.MapHttpRoute(
                 name: "default",
                 routeTemplate: "api/{Controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

        }
    }
}
