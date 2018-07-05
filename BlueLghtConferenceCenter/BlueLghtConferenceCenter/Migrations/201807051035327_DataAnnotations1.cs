namespace BlueLghtConferenceCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeID = c.Int(nullable: false, identity: true),
                        RoomTypeName = c.String(),
                    })
                .PrimaryKey(t => t.RoomTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoomTypes");
        }
    }
}
