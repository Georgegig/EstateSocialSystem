namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public interface IEstateRatingService
    {
        void AddRating(EstateRating rating);

        IQueryable<EstateRating> GetAll();
    }
}
