using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

<<<<<<< HEAD
namespace JourneyConfig
=======
namespace WBAC.WBACJourneyService.ConfigurationManager
>>>>>>> e79b0d8... add from TFS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
<<<<<<< HEAD
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Urls", action = "Index", id = UrlParameter.Optional }
=======
                name: "SettingsChanges",
                url: "Settings/{action}/{silo}/{id}",
                defaults: new { controller = "Settings", action = "Index", silo = "Journey", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
>>>>>>> e79b0d8... add from TFS
            );
        }
    }
}
