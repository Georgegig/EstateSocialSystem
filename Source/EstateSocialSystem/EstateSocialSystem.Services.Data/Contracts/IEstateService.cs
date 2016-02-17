namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IEstateService
    {
        void AddEstate(Estate model);

        IQueryable<Estate> GetAll();

        Estate GetById(int id);

        void DeleteById(int id);
    }
}
