﻿namespace EstateSocialSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Estate> estates;
        private ICollection<Appliance> appliances;
        private ICollection<Rating> ratings;
        private ICollection<Comment> comments;

        public User()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;
            this.estates = new HashSet<Estate>();
            this.appliances = new HashSet<Appliance>();
            this.ratings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(12)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public  string LastName { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        [DefaultValue(false)]
        public bool IsManufacturer { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // //Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //// Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Estate> Estates { get { return this.estates; } set { this.estates = value; } }

        public virtual ICollection<Appliance> Appliances { get { return this.appliances; } set { this.appliances = value; } }

        public virtual ICollection<Rating> Ratings { get { return this.ratings; } set { this.ratings = value; } }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }
    }
}
