namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Estate: AuditInfo, IDeletableEntity
    {
        private ICollection<Appliance> appliances;
        private ICollection<Rating> ratings;
        private ICollection<Comment> comments;

        public Estate()
        {
            this.appliances = new HashSet<Appliance>();
            this.ratings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public double Size { get; set; }

        public virtual ICollection<Appliance> Appliances { get { return this.appliances; } set { this.appliances = value; } }

        public virtual ICollection<Rating> Ratings { get { return this.ratings; } set { this.ratings = value; } }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
