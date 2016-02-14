namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public interface IRatingService
    {
        void AddRating(Rating rating);

        IQueryable<Rating> GetAll();
    }
}
