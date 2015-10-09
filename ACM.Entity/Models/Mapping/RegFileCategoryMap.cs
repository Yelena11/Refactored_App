using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class RegFileCategoryMap : EntityTypeConfiguration<RegFileCategory>
    {
        public RegFileCategoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Category, t.Description, t.IsDeployable, t.IsTargeted });

            // Properties
            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IsDeployable)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.IsTargeted)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.VendorGroup)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("RegFileCategory");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDeployable).HasColumnName("IsDeployable");
            this.Property(t => t.IsTargeted).HasColumnName("IsTargeted");
            this.Property(t => t.ATMTypeID).HasColumnName("ATMTypeID");
            this.Property(t => t.VendorGroup).HasColumnName("VendorGroup");
            this.Property(t => t.CategoryIndex).HasColumnName("CategoryIndex");

            // Relationships
            this.HasOptional(t => t.ATMType)
                .WithMany(t => t.RegFileCategories)
                .HasForeignKey(d => d.ATMTypeID);

        }
    }
}
