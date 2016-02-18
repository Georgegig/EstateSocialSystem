namespace EstateSocialSystem.Services.Data
{
    using System.Linq;
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;
    using EstateSocialSystem.Data;
    using System;

    public class ApplianceService : IApplianceService
    {
        private readonly IDeletableEntityRepository<Appliance> appliances;
        //// TODO: FIX CONTEXT Duplication 
        private readonly EstateSocialSystemDbContext context;

        public ApplianceService(IDeletableEntityRepository<Appliance> appliances, EstateSocialSystemDbContext context)
        {
            this.appliances = appliances;
            this.context = context;
        }

        public void AddAppliance(Appliance appliance)
        {
            this.appliances.Add(appliance);
            this.appliances.SaveChanges();
        }

        public void AddApplianceToEstate(int applianceId, int id)
        {
            this.context.Appliances.First(a => a.Id == applianceId).Estates.Add(this.context.Estates.First(e => e.Id == id));
            this.context.SaveChanges();
        }

        public IQueryable<Appliance> GetAll()
        {
            return this.appliances.All();
        }

        public Appliance GetById(int id)
        {
            return this.appliances.All().Where(a => a.Id == id).First();
        }
    }
}
