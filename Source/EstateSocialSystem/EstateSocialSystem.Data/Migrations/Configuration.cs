namespace EstateSocialSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EstateSocialSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            //// TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "EstateSocialSystem.Data.ApplicationDbContext";
        }

        protected override void Seed(EstateSocialSystemDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Manufacturer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manufacturer" };

                manager.Create(role);
            }
        }
    }
}
