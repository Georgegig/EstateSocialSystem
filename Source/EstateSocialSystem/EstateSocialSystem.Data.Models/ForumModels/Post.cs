﻿namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post : AuditInfo, IDeletableEntity
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
            this.Votes = new HashSet<PostVote>();
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<PostVote> Votes { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
