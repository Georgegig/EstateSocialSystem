namespace EstateSocialSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;

    public class EstateController : Controller
    {
        private readonly IEstateService estates;

        public EstateController(IEstateService estates)
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

                this.estates.AddEstate(estate);

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }

        // GET: Estate Display by ID
        public ActionResult Display(int id)
        {            
            var estateById = this.estates.GetById(id);
            var estateViewModel = AutoMapperConfig.Configuration.CreateMapper().Map<EstateDisplayViewModel>(estateById);

            return View(estateViewModel);
        }
    }
}