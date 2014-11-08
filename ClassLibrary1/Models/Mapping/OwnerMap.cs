using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class OwnerMap : EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
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

            this.Property(t => t.companyDescription)
                .HasMaxLength(255);

            this.Property(t => t.companyName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Owner");
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
            this.Property(t => t.companyDescription).HasColumnName("companyDescription");
            this.Property(t => t.companyName).HasColumnName("companyName");
            this.Property(t => t.c_logo_fk).HasColumnName("c_logo_fk");

            // Relationships
            this.HasOptional(t => t.BankAccount)
                .WithMany(t => t.Owners)
                .HasForeignKey(d => d.bankaccount_fk);
            this.HasOptional(t => t.Document)
                .WithMany(t => t.Owners)
                .HasForeignKey(d => d.c_logo_fk);
            this.HasOptional(t => t.Document1)
                .WithMany(t => t.Owners1)
                .HasForeignKey(d => d.profilepic_fk);

        }
    }
}
