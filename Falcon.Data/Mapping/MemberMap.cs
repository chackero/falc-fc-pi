using Falcon.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Falcon.Data.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.idMember);

            // Properties
            this.Property(t => t.city)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);
            
            //this.Property(t => t.email)
            //    .HasMaxLength(255);
            
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
           //this.Property(t => t.username)
           //     .HasMaxLength(255);

            this.Ignore(t => t.email);
            this.Ignore(t => t.username);
            // Table & Column Mappings
            this.ToTable("Member");
            this.Property(t => t.idMember).HasColumnName("idMember");
            this.Property(t => t.activation).HasColumnName("activation");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.country).HasColumnName("country");
            //this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstname).HasColumnName("firstname");
            this.Property(t => t.lastname).HasColumnName("lastname");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.status).HasColumnName("status");
            //this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.bankaccount_fk).HasColumnName("bankaccount_fk");
            this.Property(t => t.profilepic_fk).HasColumnName("profilepic_fk");

            // Relationships
            this.HasOptional(t => t.BankAccount)
                .WithMany(t => t.Members)
                .HasForeignKey(d => d.bankaccount_fk);
            this.HasOptional(t => t.Document)
                .WithMany(t => t.Members)
                .HasForeignKey(d => d.profilepic_fk);

        }
    }
}
