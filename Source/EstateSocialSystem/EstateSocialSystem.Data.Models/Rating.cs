namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rating : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int EstateId { get; set; }

        [ForeignKey("EstateId")]
        public virtual Estate Estate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
