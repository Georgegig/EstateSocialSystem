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

        public Appliance()
        {
            this.estates = new HashSet<Estate>();
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

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
