namespace EstateSocialSystem.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using System.Web.Mvc;

    public class RatingController : Controller
    {
        private readonly IEstateRatingService estateRatings;
        private readonly IApplianceRatingService applianceRatings;

        public RatingController(IEstateRatingService estateRatings, IApplianceRatingService applianceRatings)
        {
            this.estateRatings = estateRatings;
            this.applianceRatings = applianceRatings;
        }

        // Post: Add EstateRating
        [HttpPost]
        [Authorize]
        public ActionResult AddEstateRating(int rate, int id)
        {
            var rating = new EstateRating
            {
                Value = rate,
                EstateId = id,
                AuthorId = User.Identity.GetUserId()
            };

            this.estateRatings.AddRating(rating);

            return this.RedirectToAction("Display", "Estate", new { id = id });
        }

        // Post: Add ApplianceRating
        [HttpPost]
        [Authorize]
        public ActionResult AddApplianceRating(int rate, int id)
        {
            var rating = new ApplianceRating
            {
                Value = rate,
                ApplianceId = id,
                AuthorId = User.Identity.GetUserId()
            };

            this.applianceRatings.AddRating(rating);

            return this.RedirectToAction("Display", "Appliance", new { id = id });
        }
    }
}