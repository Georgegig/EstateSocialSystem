﻿namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer : AuditInfo, IDeletableEntity
    {
        private ICollection<Appliance> appliances;

        public Manufacturer()
        {
            this.appliances = new HashSet<Appliance>();
        }

        [Key, ForeignKey("Owner")]
        public string OwnerId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Address { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }       

        public virtual User Owner { get; set; }

        public virtual ICollection<Appliance> Appliances { get { return this.appliances; } set { this.appliances = value; } }
    }
}
