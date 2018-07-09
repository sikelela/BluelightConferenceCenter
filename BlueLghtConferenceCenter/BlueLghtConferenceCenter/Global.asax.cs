using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BluelightConferenceCenter
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes); // Register your routes here after adding them to RouteConfig in App_Start 
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
