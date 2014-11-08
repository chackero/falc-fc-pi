using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class CircleMap : EntityTypeConfiguration<Circle>
    {
        public CircleMap()
        {
            // Primary Key
            this.HasKey(t => t.idCircle);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Circle");
            this.Property(t => t.idCircle).HasColumnName("idCircle");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.creator_fk).HasColumnName("creator_fk");

            // Relationships
            this.HasMany(t => t.Freelancers)
                .WithMany(t => t.Circles1)
                .Map(m =>
                    {
                        m.ToTable("Circle_Freelancer");
                        m.MapLeftKey("Circle_idCircle");
                        m.MapRightKey("freelancers_idMember");
                    });

            this.HasOptional(t => t.Freelancer)
                .WithMany(t => t.Circles)
                .HasForeignKey(d => d.creator_fk);

        }
    }
}
