using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class ProductPlacementMap : EntityTypeConfiguration<ProductPlacement>
    {
        public ProductPlacementMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductPlacementId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            this.Property(t => t.UIMapping)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ProductPlacement");
            this.Property(t => t.ProductPlacementId).HasColumnName("ProductPlacementId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.UIMapping).HasColumnName("UIMapping");
        }
    }
}
