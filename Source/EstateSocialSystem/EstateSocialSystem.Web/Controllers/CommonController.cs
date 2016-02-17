namespace EstateSocialSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}