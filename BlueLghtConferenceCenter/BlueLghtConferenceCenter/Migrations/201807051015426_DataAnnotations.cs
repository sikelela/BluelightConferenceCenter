namespace BlueLghtConferenceCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "Rating", c => c.String(maxLength: 5));
            AlterColumn("dbo.Venues", "VenueName", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Archive", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Venues", "Archive", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Venues", "VenueName", c => c.String());
            DropColumn("dbo.Venues", "Rating");
        }
    }
}
