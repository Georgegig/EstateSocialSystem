﻿namespace EstateSocialSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class EstateSocialSystemDbContext : IdentityDbContext<User>, IEstateSocialSystemDbContext
    {
        public EstateSocialSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        ////SOCIAL SYSTEM
        public IDbSet<Estate> Estates { get; set; }

        public IDbSet<Appliance> Appliances { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<EstateComment> EstateComments { get; set; }

        public IDbSet<EstateRating> EstateRatings { get; set; }

        public IDbSet<ApplianceComment> ApplianceComment { get; set; }

        public IDbSet<ApplianceRating> ApplianceRating { get; set; }


        //// FORUM SYSTEM
        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        //// BLOG SYSTEM
        public IDbSet<BlogPost> BlogPosts { get; set; }

        public IDbSet<Page> Pages { get; set; }

        public IDbSet<BlogTag> BlogTags { get; set; }

        public IDbSet<PostComment> PostComments { get; set; }

        public IDbSet<Setting> Settings { get; set; }

        public IDbSet<Video> Videos { get; set; }

        public static EstateSocialSystemDbContext Create()
        {
            return new EstateSocialSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //// Configure OwnerID as PK for Manufacturer
            modelBuilder.Entity<Manufacturer>()
                .HasKey(e => e.OwnerId);

            //// Configure OwnerId as FK for Manufacturer
            modelBuilder.Entity<User>()
                        .HasOptional(u => u.Manufacturer) //// Mark Manufacturer is optional for Student
                        .WithRequired(m => m.Owner) //// Create inverse relationship
                        .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
