using Falcon.Domain.Models;
using Microsoft.AspNet.Identity;

namespace Falcon.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Falcon.Data.FalconDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Falcon.Data.FalconDbContext context)
        {
            /*
            context.Roles.AddOrUpdate(new CustomRole("Freelancer"));
            context.Roles.AddOrUpdate(new CustomRole("Owner"));
            context.Roles.AddOrUpdate(new CustomRole("Admin"));
            var manager = new MembersManager(new CustomUserStore());
            var member = new Member
            {
                UserName = "falconadmin"
            };

            manager.Create(member, "Falcon2Admin");
            var admin = new Admin();
            admin.idMember = manager.FindByName("falconadmin").Id;
            context.Admins.Add(admin);
             * 
            var manager = new MembersManager(new CustomUserStore());
            manager.AddToRole(manager.FindByName("falconadmin").Id, "Admin");
            context.SaveChanges();
             *
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
             */
        }
    }
}
