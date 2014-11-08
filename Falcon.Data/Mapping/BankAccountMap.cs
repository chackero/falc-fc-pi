using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Falcon.Domain.Models;

namespace Falcon.Data.Mapping
{
    public class BankAccountMap : EntityTypeConfiguration<BankAccount>
    {
        public BankAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.idAccount);

            // Properties
            // Table & Column Mappings
            this.ToTable("BankAccount");
            this.Property(t => t.idAccount).HasColumnName("idAccount");
            this.Property(t => t.balance).HasColumnName("balance");
        }
    }
}
