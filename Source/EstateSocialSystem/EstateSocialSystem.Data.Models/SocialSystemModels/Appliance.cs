namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Appliance : AuditInfo, IDeletableEntity
    {
        private ICollection<Estate> estates;
        private ICollection<ApplianceComment> comments;
        private ICollection<ApplianceRating> ratings;

        public Appliance()
        {
            this.estates = new HashSet<Estate>();
            this.comments = new HashSet<ApplianceComment>();
            this.ratings = new HashSet<ApplianceRating>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual User Manufacturer { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int Input { get; set; }

        [Required]
        public int Output { get; set; }

        public virtual ICollection<Estate> Estates { get { return this.estates; } set { this.estates = value; } }

        public virtual ICollection<ApplianceComment> Comments { get { return this.comments; } set { this.comments = value; } }

        public virtual ICollection<ApplianceRating> Ratings { get { return this.ratings; } set { this.ratings = value; } }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
