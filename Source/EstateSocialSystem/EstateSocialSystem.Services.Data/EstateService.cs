namespace EstateSocialSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EstateSocialSystem.Data.Models;
    using EstateSocialSystem.Data.Common.Repository;

    public class EstateService : IEstateService
    {
        private readonly IDeletableEntityRepository<Estate> estates;

        public EstateService(IDeletableEntityRepository<Estate> estates)
        {
            this.estates = estates;
        }

        public void CreateEstate(Estate estate)
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
