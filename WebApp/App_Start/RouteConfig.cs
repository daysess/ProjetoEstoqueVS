using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RouteUsuario",
                url: "{controller}/{action}",
                defaults: new { controller = "Usuario", action = "Usuario" });

            routes.MapRoute(
                name: "RouteProduto",
                url: "{controller}/{action}",
                defaults: new { controller = "Produto", action = "Produto" });

            routes.MapRoute(
                name: "RouteEmbalagem",
                url: "{controller}/{action}",
                defaults: new { controller = "Embalagem", action = "Embalagem" });

            routes.MapRoute(
                name: "RouteCompras",
                url: "{controller}/{action}",
                defaults: new { controller = "Compra", action = "Compra" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
