//using Books_V5_ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Books_V5_ajax
{
    public static class WebApiConfig
    {
        // Put this here as it only runs once
      
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
