using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdRestrictionCategoryMap : EntityTypeConfiguration<AdRestrictionCategory>
    {
        public AdRestrictionCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.AdRestrictionCategoryId);

            // Properties
            this.Property(t => t.AdRestrictionCategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AdRestrictionCategoryName)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("AdRestrictionCategory");
            this.Property(t => t.AdRestrictionCategoryId).HasColumnName("AdRestrictionCategoryId");
            this.Property(t => t.AdRestrictionCategoryName).HasColumnName("AdRestrictionCategoryName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
