namespace EstateSocialSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using EstateSocialSystem.Web.Models;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Data.Common.Repository;

    public class EstateController : Controller
    {
        private readonly IDeletableEntityRepository<Estate> estates;

        public EstateController(IDeletableEntityRepository<Estate> estates)
        {
            this.estates = estates;
        }

        // GET: Estate Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // Post: Estate Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstateCreateViewModel model)
        {            
            if (ModelState.IsValid)
            {
                var estate = new Estate {
                    Name = model.Name,
                    Address = model.Address,
                    Size = model.Size,
                    AuthorId = User.Identity.GetUserId(),
                    CreatedOn = DateTime.Now
                };

                this.estates.Add(estate);
                this.estates.SaveChanges();

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }
    }
}