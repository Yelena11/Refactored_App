using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class AdLocationMap : EntityTypeConfiguration<AdLocation>
    {
        public AdLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.AdLocationCode);

            // Properties
            this.Property(t => t.AdLocationCode)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.AdLocationDesc)
                .HasMaxLength(255);

            this.Property(t => t.RegistryKeyName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ReportUnderbooked)
                .HasMaxLength(1);

            this.Property(t => t.RegFileCategory)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.AdType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Category)
                .HasMaxLength(20);

            this.Property(t => t.Verified)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("AdLocation");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.AdLocationDesc).HasColumnName("AdLocationDesc");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.Discontinued).HasColumnName("Discontinued");
            this.Property(t => t.AdLocationOrder).HasColumnName("AdLocationOrder");
            this.Property(t => t.RegistryKeyName).HasColumnName("RegistryKeyName");
            this.Property(t => t.ReportUnderbooked).HasColumnName("ReportUnderbooked");
            this.Property(t => t.RegFileCategory).HasColumnName("RegFileCategory");
            this.Property(t => t.AdType).HasColumnName("AdType");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Verified).HasColumnName("Verified");
            this.Property(t => t.VerifiedBy).HasColumnName("VerifiedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            // Relationships
            this.HasRequired(t => t.Language)
                .WithMany(t => t.AdLocations)
                .HasForeignKey(d => d.LanguageId);

        }
    }
}
