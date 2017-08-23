﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KP8GlobalClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Index", url: "",
                            defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
                           );

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}",
                            defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
                           );
        }
    }
}
