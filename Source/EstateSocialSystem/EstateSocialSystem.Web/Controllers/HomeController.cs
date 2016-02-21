namespace EstateSocialSystem.Web.Controllers
{
    using Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
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
            var estates = this.estates
                .GetAll()
                .OrderByDescending(e => e.Ratings.Count() == 0 ? 0 : e.Ratings.Sum(r => r.Value) / e.Ratings.Count())
                .Take(15)
                .To<HomeIndexEstateViewModel>()
                .ToList();

            ViewBag.Estates = estates;

            var appliances = this.appliances
                .GetAll()
                .OrderByDescending(a => a.Ratings.Count() == 0 ? 0 : a.Ratings.Sum(r => r.Value) / a.Ratings.Count())
                .Take(15)
                .To<HomeIndexApplianceViewModel>()
                .ToList();
            ViewBag.Appliances = appliances;
            
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