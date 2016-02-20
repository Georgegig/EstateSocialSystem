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

            //// var regularUser = new User()
            //// {
            ////     UserName = this.users[1],
            ////     FirstName = "Regular",
            ////     LastName = "RegularUser",
            ////     Email = this.users[1],
            ////     IsManufacturer = false
            //// };
            //// 
            //// var manufacturerUser = new User()
            //// {
            ////     UserName = this.users[0],
            ////     FirstName = "Manufacturer",
            ////     LastName = "ManufacturerUser",
            ////     Email = this.users[0],
            ////     IsManufacturer = true
            //// };
            ////
            //// var administratorUser = new User()
            //// {
            ////     UserName = this.users[2],
            ////     FirstName = "Administrator",
            ////     LastName = "AdministratorUser",
            ////     Email = this.users[2],
            ////     IsManufacturer = false
            //// };
            ////
            //// context.Users.Add(regularUser);
            //// context.Users.Add(manufacturerUser);
            //// context.Users.Add(administratorUser);
            //// context.SaveChanges();
            ////
            //// regularUser.Roles.Add(new IdentityUserRole()
            //// {
            ////     RoleId = RoleManager.Roles.First(r => r.Name == "Regular").Id,
            ////     UserId = regularUser.Id
            //// });
            ////
            //// administratorUser.Roles.Add(new IdentityUserRole()
            //// {
            ////     RoleId = RoleManager.Roles.First(r => r.Name == "Administrator").Id,
            ////     UserId = regularUser.Id
            //// });
            ////
            //// manufacturerUser.Roles.Add(new IdentityUserRole()
            //// {
            ////     RoleId = RoleManager.Roles.First(r => r.Name == "Manufacturer").Id,
            ////     UserId = regularUser.Id
            //// });
            ////
            //// context.SaveChanges();

            ////Seed Ratings

            ////Seed Appliances

            ////Seed Estates

            ////Seed Users

            //// FORUM SEEDING 
            if (!context.Answers.Any())
            {
                for (int i = 1; i <= 18; i++)
                {
                    var feedback = new Answer()
                    {
                        Title = string.Format("Feedback {0}", i),
                        Content = string.Format("Feedback <b>content></b> {0}", i)
                    };

                    context.Answers.Add(feedback);
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
        }
    }
}
