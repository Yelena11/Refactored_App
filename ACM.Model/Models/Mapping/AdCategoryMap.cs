using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdCategoryMap : EntityTypeConfiguration<AdCategory>
    {
        public AdCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.AdCategoryId);

            // Properties
            this.Property(t => t.AdCategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("AdCategory");
            this.Property(t => t.AdCategoryId).HasColumnName("AdCategoryId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
