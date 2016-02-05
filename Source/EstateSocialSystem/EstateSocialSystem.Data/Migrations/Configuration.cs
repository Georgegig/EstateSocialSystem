namespace EstateSocialSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

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
        }
    }
}
