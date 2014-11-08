using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class hibernate_sequencesMap : EntityTypeConfiguration<hibernate_sequences>
    {
        public hibernate_sequencesMap()
        {
            // Primary Key
            this.HasKey(t => t.sequence_name);

            // Properties
            this.Property(t => t.sequence_name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("hibernate_sequences");
            this.Property(t => t.sequence_name).HasColumnName("sequence_name");
            this.Property(t => t.next_val).HasColumnName("next_val");
        }
    }
}
