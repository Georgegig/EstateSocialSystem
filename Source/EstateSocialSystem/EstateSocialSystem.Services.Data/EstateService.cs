namespace EstateSocialSystem.Services.Data
{
    using System.Linq;
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;
    using System.Collections.Generic;
    using System;

    public class EstateService : IEstateService
    {
        private readonly IDeletableEntityRepository<Estate> estates;

        public EstateService(IDeletableEntityRepository<Estate> estates)
        {
            this.estates = estates;
        }

        public void AddEstate(Estate estate)
        {
            this.estates.Add(estate);
            this.estates.SaveChanges();
        }

        public IQueryable<Estate> GetAll()
        {
            return this.estates.All();
        }

        public Estate GetById(int id)
        {
            return this.estates
                .All()
                .Where(e => e.Id == id)
                .First();
        }
    }
}
