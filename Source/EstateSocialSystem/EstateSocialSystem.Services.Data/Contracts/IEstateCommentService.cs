namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Models;

    public interface IEstateCommentService
    {
        void AddComment(EstateComment comment);
    }
}
