using System.Linq;
using System.Web.Mvc;
using KnockoutSamples.Models;

namespace BluelightConferenceCenter.Controllers
{
  public class ConferenceRoomController : Controller
  {
    private BlueLightEntities db = new BlueLightEntities();
    private KnockoutSamplesContext db = new KnockoutSamplesContext();

    // GET: Room
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public JsonResult GetIndex()
    {
      var conferenceRoomList = from b in db.ConferenceRooms
                               orderby b.ConferenceRoomCode
                               select b;
      return Json(conferenceRoomList.ToList(), JsonRequestBehavior.AllowGet);
    }

    // GET: /ConferenceRoom/Details/5
    public ActionResult Details(int id)
    {
      var conferenceRoom = from b in db.ConferenceRooms
                           where b.ConferenceRoomID == id
                           orderby b.ConferenceRoomCode
                           select b;
      if (conferenceRoom == null)
      {
        return HttpNotFound();
      }
      return View(conferenceRoom);
    }

    // POST: /ConferenceRoom/Create
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult Create(ConferenceRoom conferenceRoom)
    {
      if (ModelState.IsValid)
      {
        db.ConferenceRooms.Add(conferenceRoom);
        return Json(lookup.Id);
      }

      return View(lookup);
    }

    public ActionResult Edit(int id)
    {
      var db = new BlueLightEntities();
      var query = from b in db.RoomTypes
                  orderby b.RoomTypeName
                  select b;
      var conferenceRoom = query.Where(s => s.RoomTypeID == id).FirstOrDefault();
      return View(conferenceRoom);
    }

    [HttpPut]
    public ActionResult Edit(ConferenceRoom conferenceRoom)
    {
      db.Entry(conferenceRoom).State = System.Data.Entity.EntityState.Modified;
      db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(ConferenceRoom conferenceRoom)
    {

      if (ModelState.IsValid)
      {
        db.ConferenceRooms.Add(conferenceRoom);
        db.SaveChanges();

        return RedirectToAction("Index");
      }
      else
      {
        return View(conferenceRoom);
      }
    }
  }
}