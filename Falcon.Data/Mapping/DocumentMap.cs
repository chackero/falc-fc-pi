using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Falcon.Domain.Models;

namespace Falcon.Data.Mapping
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            // Primary Key
            this.HasKey(t => t.idDocument);

            // Properties
            this.Property(t => t.path)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Document");
            this.Property(t => t.idDocument).HasColumnName("idDocument");
            this.Property(t => t.path).HasColumnName("path");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.attach_id).HasColumnName("attach_id");

            // Relationships
            this.HasOptional(t => t.Post)
                .WithMany(t => t.Documents)
                .HasForeignKey(d => d.attach_id);

        }
    }
}
