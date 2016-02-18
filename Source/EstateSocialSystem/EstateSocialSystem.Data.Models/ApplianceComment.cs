namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplianceComment : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int ApplianceId { get; set; }

        [ForeignKey("ApplianceId")]
        public virtual Appliance Appliance { get; set; }
    }
}
