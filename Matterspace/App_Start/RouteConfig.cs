using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Matterspace
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product home",
                url: "p/{name}",
                defaults: new { controller = "Products", action = "Index" }
            );

            routes.MapRoute(
                name: "Product's actions",
                url: "p/{name}/{controller}/{action}",
                defaults: new { controller = "Products", action = "Index" }
            );

            routes.MapRoute(
                name: "Product",
                url: "p/{name}/{action}",
                defaults: new { controller = "Products" }
            );            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
