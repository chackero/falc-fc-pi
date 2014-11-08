using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Falcon.Domain.Models;

namespace Falcon.Data.Mapping
{
    public class AdminMap : EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            // Primary Key
            this.HasKey(t => t.idMember);

            // Properties
            this.Property(t => t.idMember)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Admin");
            this.Property(t => t.idMember).HasColumnName("idMember");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithOptional(t => t.Admin);

        }
    }
}
