namespace EstateSocialSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using System;

    public class ContentHolder : AuditInfo, IDeletableEntity
    {
        private ICollection<BlogTag> blogTags;

        public ContentHolder()
        {
            this.blogTags = new HashSet<BlogTag>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public virtual ICollection<BlogTag> SubmissionTypes
        {
            get { return this.blogTags; }
            set { this.blogTags = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
