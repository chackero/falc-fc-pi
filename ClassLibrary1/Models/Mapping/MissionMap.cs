using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class MissionMap : EntityTypeConfiguration<Mission>
    {
        public MissionMap()
        {
            // Primary Key
            this.HasKey(t => t.idMission);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.duration)
                .HasMaxLength(255);

            this.Property(t => t.status)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Mission");
            this.Property(t => t.idMission).HasColumnName("idMission");
            this.Property(t => t.budget).HasColumnName("budget");
            this.Property(t => t.deadline).HasColumnName("deadline");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.plannedStart).HasColumnName("plannedStart");
            this.Property(t => t.postDate).HasColumnName("postDate");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.category_idCategory).HasColumnName("category_idCategory");
            this.Property(t => t.evaluation_idEval).HasColumnName("evaluation_idEval");
            this.Property(t => t.owner_fk).HasColumnName("owner_fk");
            this.Property(t => t.worker_id).HasColumnName("worker_id");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.Missions)
                .HasForeignKey(d => d.category_idCategory);
            this.HasOptional(t => t.Evaluation)
                .WithMany(t => t.Missions)
                .HasForeignKey(d => d.evaluation_idEval);
            this.HasOptional(t => t.Freelancer)
                .WithMany(t => t.Missions)
                .HasForeignKey(d => d.worker_id);
            this.HasOptional(t => t.Owner)
                .WithMany(t => t.Missions)
                .HasForeignKey(d => d.owner_fk);

        }
    }
}
