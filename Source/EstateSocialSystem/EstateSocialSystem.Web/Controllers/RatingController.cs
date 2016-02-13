namespace EstateSocialSystem.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using System.Web.Mvc;

    public class RatingController : Controller
    {
        private readonly IRatingService ratings;

        public RatingController(RatingService ratings)
        {
            this.ratings = ratings;
        }

        // Post: Add Rating
        [HttpPost]
        [Authorize]
        public ActionResult Add(int rate, int id)
        {
            var rating = new Rating
            {
                Value = rate,
                EstateId = id,
                AuthorId = User.Identity.GetUserId()
            };

            this.ratings.AddRating(rating);

            return this.RedirectToAction("Display", "Estate", new { id = id });
        }
    }
}