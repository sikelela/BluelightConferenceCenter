using System.Web.Mvc;

namespace BlueLghtConferenceCenter.Controllers
{
  public class HomeController : System.Web.Mvc.Controller
  {

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Welcome()
    {
      ViewBag.Message = "Welcome to the Blue Light Conference Centre";
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";
      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";
      return View();
    }
  }
}