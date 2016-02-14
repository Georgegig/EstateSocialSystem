namespace EstateSocialSystem.Services.Data
{
    using System.Linq;
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;
    using System;

    public class ApplianceService : IApplianceService
    {
        private readonly IDeletableEntityRepository<Appliance> appliances;
        private readonly IDeletableEntityRepository<Estate> estates;

        public ApplianceService(IDeletableEntityRepository<Appliance> appliances, IDeletableEntityRepository<Estate> estates)
        {
            this.appliances = appliances;
            this.estates = estates;
        }

        public void AddAppliance(Appliance appliance)
        {
            this.appliances.Add(appliance);
            this.appliances.SaveChanges();
        }

        public void AddApplianceToEstate(int applianceId, int estateId)
        {
            this.appliances.All().First(a => a.Id == applianceId).Estates.Add(this.estates.All().First(e => e.Id == estateId));
            this.appliances.SaveChanges();
        }

        public IQueryable<Appliance> GetAll()
        {
            return this.appliances.All();
        }
    }
}
