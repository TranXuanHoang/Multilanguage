using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Multilanguage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{language}/{controller}/{action}/{id}",

                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, language = "en-US" }
            );*/

            routes.MapRoute(
                "LocalizedDefault",
                "{language}/{controller}/{action}/{id}",
                new { language = "en-US", controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { language = "en-US|ja-JP|ko-KR|vi-VN" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { language = "en-US", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
