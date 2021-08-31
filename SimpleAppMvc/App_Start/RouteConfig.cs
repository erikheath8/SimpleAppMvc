using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleAppMvc.Infrastructure;

namespace SimpleAppMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route alternatively defined in the Web.config file
            //routes.Add(new Route("handler/{*path}", new CustomRouteHandler {HandlerType = typeof(DayOfWeekHandler)}));

            // Ignores all routes specified in the parameter
            routes.IgnoreRoute("handler/{*path}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    class CustomRouteHandler : IRouteHandler
    {
        public Type HandlerType { get; set; }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return (IHttpHandler) Activator.CreateInstance(HandlerType);
        }
    }


}
