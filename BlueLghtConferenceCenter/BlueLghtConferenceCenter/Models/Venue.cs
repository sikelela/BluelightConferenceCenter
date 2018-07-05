using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BlueLghtConferenceCenter.Models
{
  public class Venue
  {
    public int VenueID { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string VenueName { get; set; }

    [Display(Name = "Room Type")]
    public int RoomTypeID { get; set; }

    [Display(Name = "Capacity Standing")]
    public int CapacityStanding { get; set; }

    [Display(Name = "Capacity Seated")]
    public int CapacitySeated { get; set; }
    public int Seats { get; set; }

    [Display(Name = "Archive Room")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Archive { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
    [StringLength(5)]
    public string Rating { get; set; }

    public List<DropDownKeyPair> DropDownList { get; set; }
  }

  public class RoomType
  {
    public int RoomTypeID { get; set; }
    public string RoomTypeName { get; set; }

  }

  public class DropDownKeyPair
  {
    public string Key { get; set; }
    public string Display { get; set; }
  }

  public class BlueLightDBContext : DbContext
  {
    public DbSet<Venue> Venues { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
  }
}