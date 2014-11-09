using Falcon.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Falcon.Data.Mapping
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

            // Table & Column Mappings
            this.ToTable("Freelancer");
            this.Property(t => t.idMember).HasColumnName("idMember");
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

            this.HasOptional(t => t.CV)
                .WithMany(t => t.Freelancers)
                .HasForeignKey(d => d.curriculum_idCV);
            this.HasRequired(t => t.Member)
                .WithOptional(t => t.Freelancer);

        }
    }
}
