namespace EstateSocialSystem.Web.Controllers
{
    using Data.Models;
    using Services.Data;
    using Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;

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
    }
}