namespace EstateSocialSystem.Data.Models
{
    using System;
    using Common.Models;

    public class PostComment : AuditInfo, IDeletableEntity
    {
        public PostComment()
        {
            this.IsVisible = true;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public virtual User User { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
