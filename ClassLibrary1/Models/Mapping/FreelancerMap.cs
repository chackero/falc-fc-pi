using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class FreelancerMap : EntityTypeConfiguration<Freelancer>
    {
        public FreelancerMap()
        {
            // Primary Key
            this.HasKey(t => t.idMember);

            // Properties
            this.Property(t => t.idMember)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.city)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstname)
                .HasMaxLength(255);

            this.Property(t => t.lastname)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.role)
                .HasMaxLength(255);

            this.Property(t => t.status)
                .HasMaxLength(255);

            this.Property(t => t.username)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Freelancer");
            this.Property(t => t.idMember).HasColumnName("idMember");
            this.Property(t => t.activation).HasColumnName("activation");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstname).HasColumnName("firstname");
            this.Property(t => t.lastname).HasColumnName("lastname");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.bankaccount_fk).HasColumnName("bankaccount_fk");
            this.Property(t => t.profilepic_fk).HasColumnName("profilepic_fk");
            this.Property(t => t.curriculum_idCV).HasColumnName("curriculum_idCV");

            // Relationships
            this.HasMany(t => t.Freelancer1)
                .WithMany(t => t.Freelancers)
                .Map(m =>
                    {
                        m.ToTable("friends_lists");
                        m.MapLeftKey("freelancer_1");
                        m.MapRightKey("freelancer_2");
                    });

            this.HasMany(t => t.Missions1)
                .WithMany(t => t.Freelancers)
                .Map(m =>
                    {
                        m.ToTable("Mission_Freelancer");
                        m.MapLeftKey("freelancers_idMember");
                        m.MapRightKey("Mission_idMission");
                    });

            this.HasOptional(t => t.BankAccount)
                .WithMany(t => t.Freelancers)
                .HasForeignKey(d => d.bankaccount_fk);
            this.HasOptional(t => t.CV)
                .WithMany(t => t.Freelancers)
                .HasForeignKey(d => d.curriculum_idCV);
            this.HasOptional(t => t.Document)
                .WithMany(t => t.Freelancers)
                .HasForeignKey(d => d.profilepic_fk);

        }
    }
}
