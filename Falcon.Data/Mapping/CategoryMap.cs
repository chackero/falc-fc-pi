using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Falcon.Domain.Models;

namespace Falcon.Data.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.idCategory);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.idCategory).HasColumnName("idCategory");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.parent_idCategory).HasColumnName("parent_idCategory");

            // Relationships
            this.HasMany(t => t.Category11)
                .WithMany(t => t.Categories)
                .Map(m =>
                    {
                        m.ToTable("Category_Category");
                        m.MapLeftKey("subCategories_idCategory");
                        m.MapRightKey("Category_idCategory");
                    });

            this.HasOptional(t => t.Category2)
                .WithMany(t => t.Category1)
                .HasForeignKey(d => d.parent_idCategory);

        }
    }
}
