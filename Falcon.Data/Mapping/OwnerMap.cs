using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Falcon.Domain.Models;

namespace Falcon.Data.Mapping
{
    public class OwnerMap : EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
        {
            // Primary Key
            this.HasKey(t => t.idMember);

            // Properties
            this.Property(t => t.companyDescription)
                .HasMaxLength(255);

            this.Property(t => t.companyName)
                .HasMaxLength(255);

            this.Property(t => t.idMember)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Owner");
            this.Property(t => t.companyDescription).HasColumnName("companyDescription");
            this.Property(t => t.companyName).HasColumnName("companyName");
            this.Property(t => t.idMember).HasColumnName("idMember");
            this.Property(t => t.c_logo_fk).HasColumnName("c_logo_fk");

            // Relationships
            this.HasOptional(t => t.Document)
                .WithMany(t => t.Owners)
                .HasForeignKey(d => d.c_logo_fk);
            this.HasRequired(t => t.Member)
                .WithOptional(t => t.Owner);

        }
    }
}
