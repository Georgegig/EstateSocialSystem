namespace EstateSocialSystem.Services.Data
{
    using EstateSocialSystem.Data.Common.Repository;
    using EstateSocialSystem.Data.Models;
    using Contracts;
    using System.Linq;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public PostService(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public void AddEstate(Post post)
        {
            this.posts.Add(post);
            this.posts.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.posts.Delete(id);
            this.posts.SaveChanges();
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts.All();
        }

        public Post GetById(int id)
        {
            return this.posts
                .All()
                .Where(e => e.Id == id)
                .First();
        }

        public void Update(Post post)
        {
            this.posts.Update(post);
            this.posts.SaveChanges();
        }
    }
}
