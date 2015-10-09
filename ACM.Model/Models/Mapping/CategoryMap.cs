using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryID);

            // Properties
            this.Property(t => t.CategoryName)
                .HasMaxLength(100);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.SuperCategoryID).HasColumnName("SuperCategoryID");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.SuperCategory)
                .WithMany(t => t.Categories)
                .HasForeignKey(d => d.SuperCategoryID);

        }
    }
}
