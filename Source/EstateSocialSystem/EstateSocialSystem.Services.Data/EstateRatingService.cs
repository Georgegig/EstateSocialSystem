namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;
    using System;
    using System.Linq;

    public class EstateRatingService : IEstateRatingService
    {
        private readonly IDeletableEntityRepository<EstateRating> ratings;

        public EstateRatingService(IDeletableEntityRepository<EstateRating> ratings)
        {
            this.ratings = ratings;
        }

        public void AddRating(EstateRating rating)
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

        public IQueryable<EstateRating> GetAll()
        {
            return this.ratings.All();
        }
    }
}
