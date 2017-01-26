using System.Web.Mvc;
using System.Web.Routing;

namespace Matterspace
{
    public class RouteConfig
    {
        public static string PRODUCT_HOME = "Product home";
        public static string PRODUCT_ACTIONS = "Product's actions";
        public static string PRODUCT = "Product";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: PRODUCT_HOME,
                url: "p/{productName}",
                defaults: new { controller = "Products", action = "Index" }
            );

            routes.MapRoute(
                name: PRODUCT_ACTIONS,
                url: "p/{productName}/{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: PRODUCT,
                url: "p/{productName}/{action}",
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
