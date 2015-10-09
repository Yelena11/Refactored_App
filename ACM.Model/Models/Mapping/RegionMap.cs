using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            // Primary Key
            this.HasKey(t => t.RegionId);

            // Properties
            this.Property(t => t.RegionId)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.RegionName)
                .HasMaxLength(100);

            this.Property(t => t.SuperRegionId)
                .HasMaxLength(15);

            this.Property(t => t.RegionStatus)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("Region");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.RegionName).HasColumnName("RegionName");
            this.Property(t => t.SuperRegionId).HasColumnName("SuperRegionId");
            this.Property(t => t.RegionStatus).HasColumnName("RegionStatus");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.SuperRegion)
                .WithMany(t => t.Regions)
                .HasForeignKey(d => d.SuperRegionId);

        }
    }
}
