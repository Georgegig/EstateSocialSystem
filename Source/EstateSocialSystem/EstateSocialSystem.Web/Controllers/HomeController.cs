namespace EstateSocialSystem.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;

    public class HomeController : Controller
    {
        private readonly IEstateService estates;
        private readonly IDeletableEntityRepository<Appliance> appliances;

        public HomeController(IEstateService estates, IDeletableEntityRepository<Appliance> appliances)
        {
            this.estates = estates;
            this.appliances = appliances;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var estates = this.estates.GetAll().Where(e => e.AuthorId == userId).To<HomeIndexEstateViewModel>().ToList();
            ViewBag.Estates = estates;
            var appliances = this.appliances.All().To<HomeIndexApplianceViewModel>().ToList();
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