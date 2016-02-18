namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Common.Repository;
    using EstateSocialSystem.Data.Models;

    public class EstateCommentService : IEstateCommentService
    {
        private readonly IDeletableEntityRepository<EstateComment> comments;

        public EstateCommentService(IDeletableEntityRepository<EstateComment> comments)
        {
            this.comments = comments;
        }

        public void AddComment(EstateComment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }
    }
}
