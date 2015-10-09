using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class SubCategoryMap : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.SubCategoryID);

            // Properties
            this.Property(t => t.SubCategoryName)
                .HasMaxLength(100);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("SubCategory");
            this.Property(t => t.SubCategoryID).HasColumnName("SubCategoryID");
            this.Property(t => t.SubCategoryName).HasColumnName("SubCategoryName");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.SubCategories)
                .HasForeignKey(d => d.CategoryID);

        }
    }
}
