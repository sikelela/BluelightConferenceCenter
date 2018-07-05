using System;

namespace BlueLghtConferenceCenter.Models
{
  public class Venue
  {
    public int VenueID { get; set; }
    public string VenueName { get; set; }
    public int RoomTypeID { get; set; }
    public int CapacityStanding { get; set; }
    public int CapacitySeated { get; set; }
    public int Seats { get; set; }
    public DateTime Archive { get; set; }
  }

  //public class MovieDBContext : DbContext
  //{
  //  public DbSet<Venue> Venues { get; set; }
  //}
}