namespace AuthenticationService.Migrations
{
    using AuthenticationService.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthenticationService.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthenticationService.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Crews.AddOrUpdate(
                new Crew(1,"Morpheus crew"),
                new Crew(2,"The Oracle team"),
                new Crew(3,"The chosen ones"),
                new Crew(4,"The Best ones"),
                new Crew(5,"Limitless"),
                new Crew(6,"The Icebrakers"),
                new Crew() { NazivEkipe = "Ivans crew"}
            );

        }
    }
}
