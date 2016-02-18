namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplianceRating : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int ApplianceId { get; set; }

        [ForeignKey("ApplianceId")]
        public virtual Appliance Appliance { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
