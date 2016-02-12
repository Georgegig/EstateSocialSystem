namespace EstateSocialSystem.Services.Data
{
    using System.Linq;
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;

    public class ApplianceService : IApplianceService
    {
        private readonly IDeletableEntityRepository<Appliance> appliances;

        public ApplianceService(IDeletableEntityRepository<Appliance> appliances)
        {
            this.appliances = appliances;
        }

        public void AddAppliance(Appliance appliance)
        {
            this.appliances.Add(appliance);
            this.appliances.SaveChanges();
        }

        public IQueryable<Appliance> GetAll()
        {
            return this.appliances.All();
        }
    }
}
