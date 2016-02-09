using EstateSocialSystem.Data.Common.Repository;
using EstateSocialSystem.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateSocialSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Estate> estates;
        private readonly IDeletableEntityRepository<Appliance> appliances;

        public HomeController(IDeletableEntityRepository<Estate> estates, IDeletableEntityRepository<Appliance> appliances)
        {
            this.estates = estates;
            this.appliances = appliances;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var estates = this.estates.All().Where(e => e.AuthorId == userId);
            ViewBag.Estates = estates;
            var appliances = this.appliances.All().Where(a => a.ManufacturerId == userId);
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