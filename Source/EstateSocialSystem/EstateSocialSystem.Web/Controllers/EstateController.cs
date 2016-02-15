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
        private readonly IApplianceService appliances;

        public EstateController(IEstateService estates, IApplianceService appliances)
        {
            this.estates = estates;
            this.appliances = appliances;
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
        public ActionResult Display(int id = 1)
        {            
            var estateById = this.estates.GetById(id);
            var estateViewModel = AutoMapperConfig.Configuration.CreateMapper().Map<EstateDisplayViewModel>(estateById);
            var allAppliances = this.appliances.GetAll();
            var estateRatingSum = 0;
            var count = 0;
            int estateAverageRating = 0;

            foreach (var rating in estateViewModel.Ratings)
            {
                estateRatingSum += rating.Value;
                count++;
            }

            if (count != 0 && estateRatingSum != 0)
            {
                estateAverageRating = estateRatingSum / count;
            }

            ViewBag.EstateAverageRating = estateAverageRating;
            ViewBag.EstateViewModel = estateViewModel;
            ViewBag.AllAppliances = allAppliances;

            return View(ViewBag);
        }
    }
}