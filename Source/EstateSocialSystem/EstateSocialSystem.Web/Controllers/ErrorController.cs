namespace EstateSocialSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        //GET: Default Error
        public ActionResult Unknown(Exception error)
        {
            ViewBag.Description = error;
            return this.View();
        }

        // GET: Not Found
        public ActionResult NotFound(Exception error)
        {
            ViewBag.Description = error;
            return this.View();
        }
    }
}