namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Common.Repository;
    using EstateSocialSystem.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> comments;

        public CommentService(IDeletableEntityRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void AddComment(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }
    }
}
