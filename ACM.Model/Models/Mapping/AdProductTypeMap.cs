using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdProductTypeMap : EntityTypeConfiguration<AdProductType>
    {
        public AdProductTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductTypeId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("AdProductType");
            this.Property(t => t.ProductTypeId).HasColumnName("ProductTypeId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.SpecificProductCodesId).HasColumnName("SpecificProductCodesId");
            this.Property(t => t.ATMWorldAdType).HasColumnName("ATMWorldAdType");
            this.Property(t => t.AdCategoryId).HasColumnName("AdCategoryId");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.AdCategory)
                .WithMany(t => t.AdProductTypes)
                .HasForeignKey(d => d.AdCategoryId);
            this.HasOptional(t => t.SpecificProductCode)
                .WithMany(t => t.AdProductTypes)
                .HasForeignKey(d => d.SpecificProductCodesId);

        }
    }
}
