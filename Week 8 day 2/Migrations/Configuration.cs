using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Week_8_day_2.Models;

namespace Week_8_day_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Week_8_day_2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week_8_day_2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any())
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Developer"));
                roleManager.Create(new IdentityRole("Employee"));

                context.SaveChanges();
            }


            if (!context.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    Email = "brianchase055@gmail.com",
                    UserName = "brianchase055@gmail.com",
                    FirstName = "Brian",
                    LastName = "Stickney",
                    Race = Race.White,
                    DOB = DateTime.Parse("3/1/1990")
                };

                userManager.Create(user, "P@sssword1");

                userManager.AddToRole(user.Id, "Admin");
                userManager.AddToRole(user.Id, "Developer");

                context.SaveChanges();
            }
        }
    }
}
