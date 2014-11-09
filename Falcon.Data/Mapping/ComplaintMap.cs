using Falcon.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Falcon.Data.Mapping
{
    public class ComplaintMap : EntityTypeConfiguration<Complaint>
    {
        public ComplaintMap()
        {
            // Primary Key
            this.HasKey(t => t.idComplaint);

            // Properties
            this.Property(t => t.body)
                .HasMaxLength(255);

            this.Property(t => t.status)
                .HasMaxLength(255);

            this.Property(t => t.subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Complaint");
            this.Property(t => t.idComplaint).HasColumnName("idComplaint");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.sendDate).HasColumnName("sendDate");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.subject).HasColumnName("subject");
            this.Property(t => t.defendant_fk).HasColumnName("defendant_fk");
            this.Property(t => t.mission_fk).HasColumnName("mission_fk");
            this.Property(t => t.plaintiff_fk).HasColumnName("plaintiff_fk");

            // Relationships
            this.HasOptional(t => t.Freelancer)
                .WithMany(t => t.Complaints)
                .HasForeignKey(d => d.defendant_fk);
            this.HasOptional(t => t.Owner)
                .WithMany(t => t.Complaints)
                .HasForeignKey(d => d.plaintiff_fk);
            this.HasOptional(t => t.Mission)
                .WithMany(t => t.Complaints)
                .HasForeignKey(d => d.mission_fk);

        }
    }
}
