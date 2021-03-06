using Falcon.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Falcon.Data.Mapping
{
    public class CVMap : EntityTypeConfiguration<CV>
    {
        public CVMap()
        {
            // Primary Key
            this.HasKey(t => t.idCV);

            // Properties
            this.Property(t => t.languages)
                .HasMaxLength(4000);

            this.Property(t => t.personalStatement)
                .HasMaxLength(4000);

            this.Property(t => t.skills)
                .HasMaxLength(4000);

            this.Property(t => t.targetJobs)
                .HasMaxLength(4000);

            this.Property(t => t.workExperience)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("CV");
            this.Property(t => t.idCV).HasColumnName("idCV");
            this.Property(t => t.languages).HasColumnName("languages");
            this.Property(t => t.lastUpdate).HasColumnName("lastUpdate");
            this.Property(t => t.personalStatement).HasColumnName("personalStatement");
            this.Property(t => t.skills).HasColumnName("skills");
            this.Property(t => t.targetJobs).HasColumnName("targetJobs");
            this.Property(t => t.workExperience).HasColumnName("workExperience");
            this.Property(t => t.document_idDocument).HasColumnName("document_idDocument");

            // Relationships
            this.HasOptional(t => t.Document)
                .WithMany(t => t.CVs)
                .HasForeignKey(d => d.document_idDocument);

        }
    }
}
