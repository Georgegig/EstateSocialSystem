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

        IDbSet<EstateComment> EstateComments { get; set; }

        IDbSet<EstateRating> EstateRatings { get; set; }

        IDbSet<ApplianceComment> ApplianceComment { get; set; }

        IDbSet<ApplianceRating> ApplianceRating { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Tag> Tags { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
