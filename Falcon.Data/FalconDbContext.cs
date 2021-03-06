using System;
using System.Threading;
using System.Threading.Tasks;
using Falcon.Data.Mapping;
using Falcon.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Falcon.Data
{
    public class FalconDbContext : IdentityDbContext<Member, CustomRole,
        int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        static FalconDbContext()
        {
            Database.SetInitializer<FalconDbContext>(null);
        }

        public FalconDbContext()
            : base("Name=falcondbContext")
        {
        }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<hibernate_sequences> hibernate_sequences { get; set; }
        //public DbSet<Member> Members { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new BankAccountMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CircleMap());
            modelBuilder.Configurations.Add(new ComplaintMap());
            modelBuilder.Configurations.Add(new CVMap());
            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new EvaluationMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new FreelancerMap());
            modelBuilder.Configurations.Add(new hibernate_sequencesMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new MissionMap());
            modelBuilder.Configurations.Add(new OwnerMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new PrivateMessageMap());
        }
        public static FalconDbContext Create()
        {
            return new FalconDbContext();
        }
    }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole()
        {
            
        }

        public CustomRole(string name)
        {
            Name = name;
        }
    }

    public class CustomUserStore : UserStore<Member, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        static FalconDbContext falconDbContext = new FalconDbContext();
        public CustomUserStore(FalconDbContext context)
            : base(context)
        {
        }

        public CustomUserStore()
            : base(falconDbContext)
        {
            
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(FalconDbContext context)
            : base(context)
        {
        }
    }

}