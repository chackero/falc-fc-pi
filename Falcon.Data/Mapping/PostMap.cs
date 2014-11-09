using Falcon.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Falcon.Data.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            // Primary Key
            this.HasKey(t => t.idPost);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Post");
            this.Property(t => t.idPost).HasColumnName("idPost");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.poster_idMember).HasColumnName("poster_idMember");

            // Relationships
            this.HasMany(t => t.Circles)
                .WithMany(t => t.Posts)
                .Map(m =>
                    {
                        m.ToTable("Circle_Post");
                        m.MapLeftKey("posts_idPost");
                        m.MapRightKey("Circle_idCircle");
                    });

            this.HasMany(t => t.Events)
                .WithMany(t => t.Posts)
                .Map(m =>
                    {
                        m.ToTable("Event_Post");
                        m.MapLeftKey("posts_idPost");
                        m.MapRightKey("Event_idEvent");
                    });

            this.HasMany(t => t.Missions)
                .WithMany(t => t.Posts)
                .Map(m =>
                    {
                        m.ToTable("Mission_Post");
                        m.MapLeftKey("posts_idPost");
                        m.MapRightKey("Mission_idMission");
                    });

            this.HasOptional(t => t.Member)
                .WithMany(t => t.Posts)
                .HasForeignKey(d => d.poster_idMember);

        }
    }
}
