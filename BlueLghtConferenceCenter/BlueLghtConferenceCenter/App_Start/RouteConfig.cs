using System.Web.Mvc;
using System.Web.Routing;

namespace BluelightConferenceCenter
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );

      routes.MapRoute(
       name: "RoomType",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "ConferenceRoom", action = "Index", id = UrlParameter.Optional }
     );

      routes.MapRoute(
        name: "ConferenceRoom",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "RoomType", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
