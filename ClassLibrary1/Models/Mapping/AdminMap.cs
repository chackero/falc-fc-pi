using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
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

            this.Property(t => t.city)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstname)
                .HasMaxLength(255);

            this.Property(t => t.lastname)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.role)
                .HasMaxLength(255);

            this.Property(t => t.status)
                .HasMaxLength(255);

            this.Property(t => t.username)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Admin");
            this.Property(t => t.idMember).HasColumnName("idMember");
            this.Property(t => t.activation).HasColumnName("activation");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstname).HasColumnName("firstname");
            this.Property(t => t.lastname).HasColumnName("lastname");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.bankaccount_fk).HasColumnName("bankaccount_fk");
            this.Property(t => t.profilepic_fk).HasColumnName("profilepic_fk");

            // Relationships
            this.HasOptional(t => t.Document)
                .WithMany(t => t.Admins)
                .HasForeignKey(d => d.profilepic_fk);
            this.HasOptional(t => t.BankAccount)
                .WithMany(t => t.Admins)
                .HasForeignKey(d => d.bankaccount_fk);

        }
    }
}
