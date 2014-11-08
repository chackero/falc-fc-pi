using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Falcon.Domain.Models;

namespace Falcon.Data.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.idEvent);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Event");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.creator_fk).HasColumnName("creator_fk");

            // Relationships
            this.HasMany(t => t.Freelancers)
                .WithMany(t => t.Events1)
                .Map(m =>
                    {
                        m.ToTable("Event_Freelancer");
                        m.MapLeftKey("joinedEvents_idEvent");
                        m.MapRightKey("participants_idMember");
                    });

            this.HasOptional(t => t.Freelancer)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.creator_fk);

        }
    }
}
