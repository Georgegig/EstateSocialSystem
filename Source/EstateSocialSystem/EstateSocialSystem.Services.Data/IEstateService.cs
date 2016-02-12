﻿namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public interface IEstateService
    {
        void CreateEstate(Estate model);

        IQueryable<Estate> GetAll();

        Estate GetById(int id);
    }
}
