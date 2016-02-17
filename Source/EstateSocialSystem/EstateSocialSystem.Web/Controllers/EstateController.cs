namespace EstateSocialSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using System.Linq;

    public class EstateController : Controller
    {
        const int ItemsPerPage = 10;
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
        
        // GET: Estate View All
        [AllowAnonymous]
        public ActionResult ViewAll(int id = 1)
        {
            var page = id;
            var allItemsCount = this.estates.GetAll().Count();
            var totalPages = Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var estates = this.estates.GetAll().OrderBy(x => x.CreatedOn).ThenBy(x => x.Id).Skip(itemsToSkip).Take(ItemsPerPage).To<EstateViewModel>().ToList();

            var viewModel = new EstateListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)totalPages,
                Estates = estates
            };

            return View(viewModel);
        }

        // GET: Estate View Personal Estates
        [AllowAnonymous]
        public ActionResult Personal(int id = 1)
        {
            var page = id;
            var currentUserId = User.Identity.GetUserId();
            var allItemsCount = this.estates.GetAll().Where(x => x.AuthorId == currentUserId).Count();
            var totalPages = Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var estates = this.estates
                .GetAll()
                .Where(x => x.AuthorId == currentUserId)
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<EstatePersonalViewModel>()
                .ToList();

            var viewModel = new EstatePersonalListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)totalPages,
                Estates = estates
            };

            return View(viewModel);
        }

        // GET: Estate Delete
        [Authorize]
        public ActionResult Delete(int id)
        {
            var estateToBeDeleted = this.estates.GetById(id);
            var currentUserId = User.Identity.GetUserId();

            if (estateToBeDeleted.AuthorId == currentUserId)
            {
                this.estates.DeleteById(id);

                return this.RedirectToAction("Personal", "Estate");

            }

            return this.RedirectToAction("Unauthorized", "Common");
        }

        // GET: Estate Update
        [Authorize]
        public ActionResult Update(int id)
        {
            var estateToBeUpdated = this.estates
                .GetAll()
                .Where(e => e.Id == id)
                .To<UpdateEstateViewModel>()
                .First();

            return View(estateToBeUpdated);
        }

        // Post: Estate update
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateEstateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estateToUpdate = this.estates.GetById(model.Id);

                estateToUpdate.Name = model.Name;
                estateToUpdate.Address = model.Address;
                estateToUpdate.Size = model.Size;

                this.estates.Update(estateToUpdate);

                return this.RedirectToAction("Personal", "Estate");
            }

            return this.View(model);
        }
    }
}