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
    using Services.Web;
    using System.Collections.Generic;

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
        public ActionResult ViewAll(string sortBy = "date", int id = 1)
        {
            var page = id;
            var allItemsCount = this.estates.GetAll().Count();
            var totalPages = Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var estates = this.estates
                .GetAll()
                .To<EstateViewModel>()
                .ToList()
                .OrderByDescending(x => x, new EstateSorterService(sortBy))
                .Skip(itemsToSkip)
                .Take(ItemsPerPage);
            
            var viewModel = new EstateListViewModel
            {
                SortBy = sortBy,
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
            var currentUserId = User.Identity.GetUserId();

            if (estateToBeUpdated.AuthorId == currentUserId)
            {
                return View(estateToBeUpdated);
            }

            return this.RedirectToAction("Unauthorized", "Common");
            
        }

        // Post: Estate update
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateEstateViewModel model)
        {
            var estateToUpdate = this.estates.GetById(model.Id);
            var currentUserId = User.Identity.GetUserId();

            if (estateToUpdate.AuthorId == currentUserId)
            {
                if (ModelState.IsValid)
                {
                    estateToUpdate.Name = model.Name;
                    estateToUpdate.Address = model.Address;
                    estateToUpdate.Size = model.Size;

                    this.estates.Update(estateToUpdate);

                    return this.RedirectToAction("Personal", "Estate");
                }
            }

            return this.RedirectToAction("Unauthorized", "Common");            
        }
    }

    #region Helpers
    public class EstateSorterService : IComparer<EstateViewModel>
    {
        private string sortBy;

        public EstateSorterService(string sortBy)
        {
            this.sortBy = sortBy;
        }

        public int Compare(EstateViewModel x, EstateViewModel y)
        {
            if (this.sortBy == "date")
            {
                return DateTime.Compare(x.CreatedOn, y.CreatedOn);
            }
            else if (this.sortBy == "rating")
            {
                if (x.Ratings.Count == 0 && y.Ratings.Count != 0)
                {
                    return -1;
                }
                else if (x.Ratings.Count != 0 && y.Ratings.Count == 0)
                {
                    return 1;
                }
                else if (!(x.Ratings.Count == 0) && !(y.Ratings.Count == 0))
                {
                    var xAverageRating = x.Ratings.Sum(r => r.Value) / x.Ratings.Count;
                    var yAverageRating = y.Ratings.Sum(r => r.Value) / y.Ratings.Count;

                    if (xAverageRating < yAverageRating)
                    {
                        return -1;
                    }
                    else if (xAverageRating > yAverageRating)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
    #endregion
}