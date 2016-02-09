using EstateSocialSystem.Data.Common.Repository;
using EstateSocialSystem.Data.Models;
using EstateSocialSystem.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateSocialSystem.Web.Controllers
{
    public class ApplianceController : Controller
    {
        private readonly IDeletableEntityRepository<Appliance> appliances;

        public ApplianceController(IDeletableEntityRepository<Appliance> appliances)
        {
            this.appliances = appliances;
        }

        // GET: Appliance
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
                var appliance = new Appliance {
                    Name = model.Name,
                    Type = model.Type,
                    Power = model.Power,
                    Input = model.Input,
                    Output = model.Output,
                    ManufacturerId = User.Identity.GetUserId(),
                    CreatedOn = DateTime.Now
                };

                this.appliances.Add(appliance);
                this.appliances.SaveChanges();

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }
    }
}