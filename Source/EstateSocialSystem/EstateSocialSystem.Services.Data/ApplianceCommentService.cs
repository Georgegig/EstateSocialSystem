namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Common.Repository;
    using EstateSocialSystem.Data.Models;

    public class ApplianceCommentService : IApplianceCommentService
    {
        private readonly IDeletableEntityRepository<ApplianceComment> comments;

        public ApplianceCommentService(IDeletableEntityRepository<ApplianceComment> comments)
        {
            this.comments = comments;
        }

        public void AddComment(ApplianceComment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }
    }
}
