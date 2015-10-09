using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdRestrictionMap : EntityTypeConfiguration<AdRestriction>
    {
        public AdRestrictionMap()
        {
            // Primary Key
            this.HasKey(t => t.AdRestrictionId);

            // Properties
            this.Property(t => t.RestrictionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.ACMName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AdRestriction");
            this.Property(t => t.AdRestrictionId).HasColumnName("AdRestrictionId");
            this.Property(t => t.RestrictionName).HasColumnName("RestrictionName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ACMCategoryId).HasColumnName("ACMCategoryId");
            this.Property(t => t.ACMName).HasColumnName("ACMName");

            // Relationships
            this.HasOptional(t => t.AdRestrictionCategory)
                .WithMany(t => t.AdRestrictions)
                .HasForeignKey(d => d.ACMCategoryId);

        }
    }
}
