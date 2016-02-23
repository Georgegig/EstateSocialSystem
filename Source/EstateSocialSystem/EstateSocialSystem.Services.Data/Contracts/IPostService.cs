namespace EstateSocialSystem.Services.Data.Contracts
{
    using EstateSocialSystem.Data.Models;
    using System.Linq;

    public interface IPostService
    {
        void AddEstate(Post model);

        IQueryable<Post> GetAll();

        Post GetById(int id);

        void DeleteById(int id);

        void Update(Post estate);
    }
}
