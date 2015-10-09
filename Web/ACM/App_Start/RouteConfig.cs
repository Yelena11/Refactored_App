using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ACM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Campaign", action = "CampaignRequest", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
             "Default",
             "",
             new { controller = "CampaignView", action = "campaigndashboard", id = UrlParameter.Optional }
           );

            routes.MapRoute(
            "CampaignView", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "campaigndashboard", action = "campaigndashboard", Id = UrlParameter.Optional } // Parameter defaults
);
       routes.MapRoute("DeploymentPeriodDashboard", // Route name5.
           "{controller}/{action}", // URL 6. 
           new { controller = "DeploymentPeriod", action = "DeploymentPeriodDashboard" } // Parameter defaults7. 
           );

        }
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}