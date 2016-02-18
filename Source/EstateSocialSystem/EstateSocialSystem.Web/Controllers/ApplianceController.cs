namespace EstateSocialSystem.Web.Controllers
{
    using Data.Models;
    using Services.Data;
    using Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Web.Models;

    public class ApplianceController : Controller
    {
        private readonly IApplianceService appliances;

        public ApplianceController(IApplianceService appliances)
        {
            this.appliances = appliances;
        }

        // POST: Appliance AddToEstate
        [HttpPost]
        [Authorize]
        public ActionResult AddToEstate(int applianceId, int id)
        {
            this.appliances.AddApplianceToEstate(applianceId, id);

            return this.RedirectToAction("Display", "Estate", new { id = id });
        }

        // GET: Appliance Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Appliance Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplianceCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appliance = new Appliance
                {
                    Name = model.Name,
                    Type = model.Type,
                    Power = model.Power,
                    Input = model.Input,
                    Output = model.Output,
                    CreatedOn = DateTime.Now
                };

                if (User.IsInRole("Manufacturer"))
                {
                    appliance.ManufacturerId = User.Identity.GetUserId();
                }

                this.appliances.AddAppliance(appliance);

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }

        // GET: Appliance Display by ID
        public ActionResult Display(int id = 1)
        {
            var applianceById = this.appliances.GetById(id);
            var applianceViewModel = AutoMapperConfig.Configuration.CreateMapper().Map<ApplianceDisplayViewModel>(applianceById);
            var applianceRatingSum = 0;
            var count = 0;
            int applianceAverageRating = 0;

            foreach (var rating in applianceViewModel.Ratings)
            {
                applianceRatingSum += rating.Value;
                count++;
            }

            if (count != 0 && applianceRatingSum != 0)
            {
                applianceAverageRating = applianceRatingSum / count;
            }

            ViewBag.ApplianceAverageRating = applianceAverageRating;
            ViewBag.ApplianceViewModel = applianceViewModel;

            return View(ViewBag);
        }
    }
}