namespace EstateSocialSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Answer : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }
        
        public virtual Post Post { get; set; }
    }
}
