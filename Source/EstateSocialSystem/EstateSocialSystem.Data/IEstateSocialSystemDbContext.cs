namespace EstateSocialSystem.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IEstateSocialSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<Estate> Estates { get; set; }

        IDbSet<Appliance> Appliances { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
