using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlueLghtConferenceCenter.Models;

namespace BlueLghtConferenceCenter.Controllers
{

  public class VenuesController : Controller
  {
    private BlueLightDBContext db = new BlueLightDBContext();

    // GET: Venues
    public ActionResult Index(string venueNameSearch)
    {
      var NameLst = new List<string>();

      var NameQry = from d in db.Venues
                    orderby d.VenueName
                    select d.VenueName;

      NameLst.AddRange(NameQry.Distinct());
      ViewBag.movieName = new SelectList(NameLst);

      var venues = from m in db.Venues
                   select m;

      if (!String.IsNullOrEmpty(venueNameSearch))
      {
        venues = venues.Where(s => s.VenueName.Contains(venueNameSearch));
      }
      return View(venues);
    }

    // GET: Venues/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Venue venue = db.Venues.Find(id);
      if (venue == null)
      {
        return HttpNotFound();
      }
      return View(venue);
    }

    // GET: Venues/Create
    public ActionResult Create()
    {
      var RoomTypeList = new List<DropDownKeyPair>();

      //var RoomTypeQry = from d in db.RoomTypes
      //                  orderby d.RoomTypeName
      //                  select d.RoomTypeName;

      //var model = new users();
      //model.DropDownList = new SelectList(list, "Key", "Display");


      return View();
    }

    // POST: Venues/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "VenueID,VenueName,RoomTypeID,CapacityStanding,CapacitySeated,Seats,Archive")] Venue venue)
    {
      if (ModelState.IsValid)
      {
        db.Venues.Add(venue);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(venue);
    }

    // GET: Venues/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Venue venue = db.Venues.Find(id);
      if (venue == null)
      {
        return HttpNotFound();
      }
      return View(venue);
    }

    // POST: Venues/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "VenueID,VenueName,RoomTypeID,CapacityStanding,CapacitySeated,Seats,Archive")] Venue venue)
    {
      if (ModelState.IsValid)
      {
        db.Entry(venue).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(venue);
    }

    // GET: Venues/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Venue venue = db.Venues.Find(id);
      if (venue == null)
      {
        return HttpNotFound();
      }
      return View(venue);
    }

    // POST: Venues/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Venue venue = db.Venues.Find(id);
      db.Venues.Remove(venue);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
