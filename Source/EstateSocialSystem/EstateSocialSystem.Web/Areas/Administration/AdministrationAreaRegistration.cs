using System.Web.Mvc;

namespace EstateSocialSystem.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                   "AdministrationHome",
                   "Administration/Home",
                   new { controller = "Home", action = "Index" },
                   new[] { "EstateSocialSystem.Web.Controllers" });

            context.MapRoute(
                "AdministrationLogOff",
                "Administration/Account/LogOff",
                new { controller = "Account", action = "LogOff" },
                new[] { "EstateSocialSystem.Web.Controllers" });

            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}