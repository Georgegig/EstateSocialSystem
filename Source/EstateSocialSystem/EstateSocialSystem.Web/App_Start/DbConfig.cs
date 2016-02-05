namespace EstateSocialSystem.Web.App_Start
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EstateSocialSystemDbContext, Configuration>());
            EstateSocialSystemDbContext.Create().Database.Initialize(true);
        }
    }
}