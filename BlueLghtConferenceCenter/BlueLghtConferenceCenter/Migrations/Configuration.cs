namespace BlueLghtConferenceCenter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlueLghtConferenceCenter.Models.BlueLightDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlueLghtConferenceCenter.Models.BlueLightDBContext";
        }

        protected override void Seed(BlueLghtConferenceCenter.Models.BlueLightDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
