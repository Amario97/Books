using Books_V5_ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Books_V5_ajax
{
    public static class WebApiConfig
    {
        // Put this here as it only runs once
        public static List<Book> myList;
        public static void Register(HttpConfiguration config)
        {

            myList = new List<Book>();
            myList.Add(new Book { Id = "1", Title = "Ender's Game", Genre = "SiFi", Year = 1985 });
            myList.Add(new Book { Id = "2", Title = "The Wind-Up Bird Chronicle", Genre = "Fantasy", Year = 1997 });
            myList.Add(new Book { Id = "3", Title = "The Dark Tower", Genre = "Fantasy.", Year = 1982 });

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
