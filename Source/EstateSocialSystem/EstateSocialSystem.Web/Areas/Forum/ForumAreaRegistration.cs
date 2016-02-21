using System.Web.Mvc;

namespace EstateSocialSystem.Web.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                   "ForumHome",
                   "Forum/Home",
                   new { controller = "Home", action = "Index" },
                   new[] { "EstateSocialSystem.Web.Controllers" });

            context.MapRoute(
                "ForumLogOff",
                "Forum/Account/LogOff",
                new { controller = "Account", action = "LogOff" },
                new[] { "EstateSocialSystem.Web.Controllers" });

            context.MapRoute(
                "Get questions by tag",
                "questions/tagged/{tag}",
                new { controller = "Questions", action = "GetByTag" },
                new[] { "EstateSocialSystem.Web.Areas.Forum.Controllers" });

            context.MapRoute(
                "Display question",
                "questions/{id}/{url}",
                new { controller = "Questions", action = "Display" },
                new[] { "EstateSocialSystem.Web.Areas.Forum.Controllers" });

            context.MapRoute(
                "Forum_default",
                "Forum/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "EstateSocialSystem.Web.Areas.Forum.Controllers" }
            );
        }
    }
}