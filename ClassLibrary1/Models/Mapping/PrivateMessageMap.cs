using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class PrivateMessageMap : EntityTypeConfiguration<PrivateMessage>
    {
        public PrivateMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.idPM);

            // Properties
            this.Property(t => t.body)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PrivateMessage");
            this.Property(t => t.idPM).HasColumnName("idPM");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.receiver_fk).HasColumnName("receiver_fk");
            this.Property(t => t.sender_fk).HasColumnName("sender_fk");

            // Relationships
            this.HasOptional(t => t.Freelancer)
                .WithMany(t => t.PrivateMessages)
                .HasForeignKey(d => d.receiver_fk);
            this.HasOptional(t => t.Freelancer1)
                .WithMany(t => t.PrivateMessages1)
                .HasForeignKey(d => d.sender_fk);

        }
    }
}
