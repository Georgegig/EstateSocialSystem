namespace EstateSocialSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class RatingController : Controller
    {
        // Post: Add Rating
        [HttpPost]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
    }
}