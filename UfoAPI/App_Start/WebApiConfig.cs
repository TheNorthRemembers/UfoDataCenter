using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace UfoAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"Random",
                routeTemplate:"random" , 
                defaults: new { controller = "Home", action = "Random" }
            );
            config.Routes.MapHttpRoute(
                name: "TextCollections",
                routeTemplate: "collections/text",
                defaults: new { controller = "Home", action = "TextCollections" }
            );
            config.Routes.MapHttpRoute(
                name: "GetResults",
                routeTemplate: "{id}",
                defaults: new { controller = "Home", action = "GetResults", id = 0 }
            );
            config.Routes.MapHttpRoute(
                name: "GetResultsPage",
                routeTemplate: "{page}/{perpage}",
                defaults: new { controller = "Home", action = "GetResultsP", perpage = 0 }
            );

            //JSON as default
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(x => x.MediaType == "application/xml"));

        }
    }
}
