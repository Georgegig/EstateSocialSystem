namespace EstateSocialSystem.Data.Models
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
        //// SOCIAL SYSTEM
        private ICollection<Estate> estates;
        private ICollection<Appliance> appliances;
        private ICollection<EstateRating> ratings;
        private ICollection<EstateComment> comments;

        //// FORUM SYSTEM
        private ICollection<Post> posts;

        //// BLOG SYSTEM
        private ICollection<PostComment> blogComments;

        public User()
        {
            //// SOCIAL SYSTEM
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;
            this.estates = new HashSet<Estate>();
            this.appliances = new HashSet<Appliance>();
            this.ratings = new HashSet<EstateRating>();
            this.comments = new HashSet<EstateComment>();

            ////FORUM SYSTEM
            this.posts = new HashSet<Post>();

            //// BLOG SYSTEM
            this.blogComments = new HashSet<PostComment>();
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

        public virtual ICollection<EstateRating> Ratings { get { return this.ratings; } set { this.ratings = value; } }

        public virtual ICollection<EstateComment> Comments { get { return this.comments; } set { this.comments = value; } }

        ////FORUM SYSTEM
        public virtual ICollection<Post> Posts { get { return this.posts; } set { this.posts = value; } }

        ////BLOG SYSTEM
        public virtual ICollection<PostComment> BlogComments { get { return this.blogComments; } set { this.blogComments = value; } }

    }
}
