using Falcon.Domain.Models;
using System.Data.Entity.ModelConfiguration;

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
