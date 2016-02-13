namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;

    public class RatingService : IRatingService
    {
        private readonly IDeletableEntityRepository<Rating> ratings;

        public RatingService(IDeletableEntityRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public void AddRating(Rating rating)
        {
            this.ratings.Add(rating);
            this.ratings.SaveChanges();
        }
    }
}
