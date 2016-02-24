namespace EstateSocialSystem.Data.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SeedData
    {
        public static Random Rand = new Random();
        private readonly List<string> roles = new List<string>() { "Manufacturer", "Regular", "Administrator" };
        private readonly List<string> users = new List<string>() { "manufacturer@site.com", "regular@site.com", "admin@site.com" };

        public void Seed(EstateSocialSystemDbContext context)
        {
            ////Seed User Roles
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            for (int i = 0; i < roles.Count; i++)
            {
                if (RoleManager.RoleExists(roles[i]) == false)
                {
                    RoleManager.Create(new IdentityRole(roles[i]));
                }
            }            

            //// FORUM SEEDING 
            if (!context.Answers.Any())
            {
                for (int i = 1; i <= 18; i++)
                {
                    var Answer = new Answer()
                    {
                        Title = string.Format("Answer {0}", i),
                        Content = string.Format("Answer <b>content></b> {0}", i)
                    };

                    context.Answers.Add(Answer);
                }

                context.SaveChanges();
            }

            if (!context.Tags.Any())
            {
                var tagList = new List<Tag>();
                for (int i = 1; i <= 20; i++)
                {
                    var tag = new Tag() { Name = string.Format("Tag {0}", i) };
                    context.Tags.Add(tag);
                    tagList.Add(tag);
                }

                var tagIndex = 0;
                for (int i = 1; i <= 20; i++)
                {
                    var post = new Post() { Content = string.Format("Post content {0}", i), Title = string.Format("Post Title {0}", i) };
                    for (int j = 0; j < 5; j++)
                    {
                        post.Tags.Add(tagList[tagIndex % tagList.Count]);
                        tagIndex++;
                    }

                    context.Posts.Add(post);
                }

                context.SaveChanges();

            }
            ////END

            ////Blog Seed
            if (context.Settings.Any())
            {
                return;
            }

            context.Settings.Add(new Setting { Name = "Logo URL", Value = "/img/header-logo.png" });
            context.Settings.Add(new Setting { Name = "Home Title", Value = "Home Title" });
            context.Settings.Add(new Setting { Name = "Blog Name", Value = "Blog Name" });
            context.Settings.Add(new Setting { Name = "Blog Url", Value = "Blog Url" });
            context.Settings.Add(new Setting { Name = "Keywords", Value = "Keywords" });
            context.Settings.Add(new Setting { Name = "Author", Value = "Author" });
            context.Settings.Add(new Setting { Name = "GitHub Profile", Value = "GitHub Profile" });
            context.Settings.Add(new Setting { Name = "GitHub Badge HTML Code", Value = "GitHub Badge HTML Code" });
            context.Settings.Add(new Setting { Name = "StackOverflow Badge HTML Code", Value = "StackOverflow Badge HTML Code" });
            context.Settings.Add(new Setting { Name = "Stack Overflow Profile", Value = "Stack Overflow Profile" });
            context.Settings.Add(new Setting { Name = "Linked In Profile", Value = "Linked In Profile" });
            context.Settings.Add(new Setting { Name = "Contact Email", Value = "Contact Email" });
            context.Settings.Add(new Setting { Name = "Facebook Profile", Value = "Facebook Profile" });
            context.Settings.Add(new Setting { Name = "Foursquare Profile", Value = "Foursquare Profile" });
            context.Settings.Add(new Setting { Name = "Google Profile", Value = "Google+ Profile" });
            context.Settings.Add(new Setting { Name = "RSS Url", Value = "RSS Url" });
            ////END
        }
    }
}
