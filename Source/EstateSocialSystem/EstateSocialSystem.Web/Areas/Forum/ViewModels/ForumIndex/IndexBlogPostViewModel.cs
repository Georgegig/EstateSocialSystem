namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<IndexBlogPostTagViewModel> Tags { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<PostVote> Votes { get; set; }

        public string Url
        {
            get
            {
                return string.Format("/questions/{0}/{1}", this.Id, this.Title.ToLower().Replace(" ", "-"));
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                .ForMember(x => x.VotesCount,
                opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int)v.Type) : 0));
        }
    }
}