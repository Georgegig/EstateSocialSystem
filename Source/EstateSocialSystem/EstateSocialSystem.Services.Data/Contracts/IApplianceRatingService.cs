namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public interface IApplianceRatingService
    {
        void AddRating(ApplianceRating rating);

        IQueryable<ApplianceRating> GetAll();
    }
}
