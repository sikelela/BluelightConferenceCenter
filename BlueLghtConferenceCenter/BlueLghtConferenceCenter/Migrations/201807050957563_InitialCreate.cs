namespace BlueLghtConferenceCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        RoomTypeID = c.Int(nullable: false),
                        CapacityStanding = c.Int(nullable: false),
                        CapacitySeated = c.Int(nullable: false),
                        Seats = c.Int(nullable: false),
                        Archive = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VenueID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Venues");
        }
    }
}
