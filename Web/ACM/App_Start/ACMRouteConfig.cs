using System.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(ACM.App_Start.ACMRouteConfig), "RegisterACMPreStart", Order = 2)]

namespace ACM.App_Start
{
    ///<summary>
    /// Inserts the DVSUGRouteConfig SPA sample view controller to the front of all MVC routes
    /// so that the DVSUGRouteConfig SPA sample becomes the default page.
    ///</summary>
    ///<remarks>
    /// This class is discovered and run during startup
    /// http://blogs.msdn.com/b/davidebb/archive/2010/10/11/light-up-your-nupacks-with-startup-code-and-webactivator.aspx
    ///</remarks>
    public static class ACMRouteConfig
    {

        public static void RegisterACMPreStart()
        {

            // Preempt standard default MVC page routing to go to DVSUG
            System.Web.Routing.RouteTable.Routes.MapRoute(
                name: "ACMMvc",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}