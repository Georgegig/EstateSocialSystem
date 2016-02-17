namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;
    using System;
    using System.Linq;

    public class RatingService : IRatingService
    {
        private readonly IDeletableEntityRepository<Rating> ratings;

        public RatingService(IDeletableEntityRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public void AddRating(Rating rating)
        {
            var ratingExists = ratings.All().Any(r => r.AuthorId == rating.AuthorId && r.EstateId == rating.EstateId);
            if (!ratingExists)
            {
                this.ratings.Add(rating);
                this.ratings.SaveChanges();
            }
            else
            {
                var ratingToUpdate = this.ratings
                    .All()
                    .FirstOrDefault(r => r.AuthorId == rating.AuthorId && r.EstateId == rating.EstateId);

                ratingToUpdate.Value = rating.Value;

                this.ratings.Update(ratingToUpdate);
                this.ratings.SaveChanges();              
            }
        }

        public IQueryable<Rating> GetAll()
        {
            return this.ratings.All();
        }
    }
}
