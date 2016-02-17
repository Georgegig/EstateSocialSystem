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
            var estatesByRating = new Dictionary<HomeIndexEstateViewModel, int>();
            var userId = User.Identity.GetUserId();
            var estates = this.estates.GetAll()
                .To<HomeIndexEstateViewModel>()
                .ToList()
                .OrderBy(e => e.Ratings.Count() == 0 ? 0 : e.Ratings.Sum(r => r.Value) / e.Ratings.Count());

            //foreach (var estate in estates)
            //{
            //    var ratingsSum = 0;
            //    var count = 0;
            //    var averageRating = 0;
            //
            //    foreach (var rating in estate.Ratings)
            //    {
            //        ratingsSum += rating.Value;
            //        count += 1;
            //    }
            //
            //    if (count != 0 && ratingsSum != 0)
            //    {
            //        averageRating = ratingsSum / count;
            //        estatesByRating.Add(estate, averageRating);
            //    }
            //    else
            //    {
            //        estatesByRating.Add(estate, averageRating);
            //        continue;
            //    }
            //}

            //ViewBag.Estates = estatesByRating.OrderBy(e => e.Value);
            ViewBag.Estates = estates;
            var appliances = this.appliances.GetAll().To<HomeIndexApplianceViewModel>().ToList();
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