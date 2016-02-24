namespace EstateSocialSystem.Web.Controllers
{
    using Models;
    using Infrastructure.Mapping;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private readonly IEstateService estates;
        private readonly IApplianceService appliances;

        public HomeController(IEstateService estates, IApplianceService appliances)
        {
            this.estates = estates;
            this.appliances = appliances;
        }

        public ActionResult Index()
        {
            var estates = new List<HomeIndexEstateViewModel>();
            var appliances = new List<HomeIndexApplianceViewModel>();

            if (this.HttpContext.Cache["Home estates"] != null && this.HttpContext.Cache["Home appliances"] != null)
            {
                ViewBag.Estates = this.HttpContext.Cache["Home estates"];
                ViewBag.Appliances = this.HttpContext.Cache["Home appliances"];
            }
            else
            {
                estates = this.estates
                    .GetAll()
                    .OrderByDescending(e => e.Ratings.Count() == 0 ? 0 : e.Ratings.Sum(r => r.Value) / e.Ratings.Count())
                    .Take(15)
                    .To<HomeIndexEstateViewModel>()
                    .ToList();

                appliances = this.appliances
                    .GetAll()
                    .OrderByDescending(a => a.Ratings.Count() == 0 ? 0 : a.Ratings.Sum(r => r.Value) / a.Ratings.Count())
                    .Take(15)
                    .To<HomeIndexApplianceViewModel>()
                    .ToList();

                ViewBag.Estates = estates;
                ViewBag.Appliances = appliances;

                this.HttpContext.Cache["Home estates"] = estates;
                this.HttpContext.Cache["Home appliances"] = appliances;
            }
                        
            return this.View(ViewBag);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}