namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Common.Repository;
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public class ApplianceRatingService : IApplianceRatingService
    {
        private readonly IDeletableEntityRepository<ApplianceRating> ratings;

        public ApplianceRatingService(IDeletableEntityRepository<ApplianceRating> ratings)
        {
            this.ratings = ratings;
        }

        public void AddRating(ApplianceRating rating)
        {
            var ratingExists = ratings.All().Any(r => r.AuthorId == rating.AuthorId && r.ApplianceId == rating.ApplianceId);
            if (!ratingExists)
            {
                this.ratings.Add(rating);
                this.ratings.SaveChanges();
            }
            else
            {
                var ratingToUpdate = this.ratings
                    .All()
                    .FirstOrDefault(r => r.AuthorId == rating.AuthorId && r.ApplianceId == rating.ApplianceId);

                ratingToUpdate.Value = rating.Value;

                this.ratings.Update(ratingToUpdate);
                this.ratings.SaveChanges();
            }
        }

        public IQueryable<ApplianceRating> GetAll()
        {
            return this.ratings.All();
        }
    }
}
