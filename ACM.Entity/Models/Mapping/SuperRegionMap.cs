using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class SuperRegionMap : EntityTypeConfiguration<SuperRegion>
    {
        public SuperRegionMap()
        {
            // Primary Key
            this.HasKey(t => t.SuperRegionId);

            // Properties
            this.Property(t => t.SuperRegionId)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.SuperRegionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SuperRegionStatus)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("SuperRegion");
            this.Property(t => t.SuperRegionId).HasColumnName("SuperRegionId");
            this.Property(t => t.SuperRegionName).HasColumnName("SuperRegionName");
            this.Property(t => t.SuperRegionStatus).HasColumnName("SuperRegionStatus");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
