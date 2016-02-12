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
        }
    }
}
