namespace EstateSocialSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EstateSocialSystemDbContext>
    {
        private readonly List<string> roles = new List<string>() { "Manufacturer", "Regular", "Administrator" };

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            //// TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "EstateSocialSystem.Data.ApplicationDbContext";
        }

        protected override void Seed(EstateSocialSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                for (int i = 0; i < roles.Count; i++)
                {
                    if (RoleManager.RoleExists(roles[i]) == false)
                    {
                        RoleManager.Create(new IdentityRole(roles[i]));
                    }
                }
            }
        }
    }
}
