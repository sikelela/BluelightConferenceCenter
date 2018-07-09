using System.Linq;
using System.Web.Mvc;

namespace BluelightConferenceCenter.Controllers
{
  public class RoomTypeController : Controller
  {
    public BlueLightEntities db = new BlueLightEntities();

    // GET: RoomType
    public ActionResult Index()
    {
      var query = from b in db.RoomTypes
                  orderby b.RoomTypeName
                  select b;
      // Get the rooms from the database in the real application
      return View(query);
    }

    public ActionResult Edit(int id)
    {
      var query = from b in db.RoomTypes
                  orderby b.RoomTypeName
                  select b;
      var roomType = query.Where(s => s.RoomTypeID == id).FirstOrDefault();

      return View(roomType);
    }

    [HttpPost]
    public ActionResult Edit(RoomType roomtype)
    {
      db.Entry(roomtype).State = System.Data.Entity.EntityState.Modified;
      db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(RoomType roomtype)
    {

      if (ModelState.IsValid)
      {
        db.RoomTypes.Add(roomtype);
        db.SaveChanges();

        return RedirectToAction("Index");
      }
      else
      {
        return View(roomtype);
      }
    }


  }
}