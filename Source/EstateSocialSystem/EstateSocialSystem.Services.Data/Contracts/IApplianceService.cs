namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public interface IApplianceService
    {
        void AddAppliance(Appliance appliance);

        IQueryable<Appliance> GetAll();

        void AddApplianceToEstate(int applianceId, int estateId);

        Appliance GetById(int id);

        void DeleteById(int id);

        void Update(Appliance estate);
    }
}
