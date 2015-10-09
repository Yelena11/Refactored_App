using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CampaignLocationMap : EntityTypeConfiguration<CampaignLocation>
    {
        public CampaignLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignId);

            // Properties
            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SuperRegionId)
                .HasMaxLength(15);

            this.Property(t => t.RegionId)
                .HasMaxLength(15);

            this.Property(t => t.StateCode)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.SpecifyRegionName)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("CampaignLocation");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.SuperRegionId).HasColumnName("SuperRegionId");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.StateCode).HasColumnName("StateCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.SpecifyRegionName).HasColumnName("SpecifyRegionName");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithOptional(t => t.CampaignLocation);
            this.HasOptional(t => t.Region)
                .WithMany(t => t.CampaignLocations)
                .HasForeignKey(d => d.RegionId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.CampaignLocations)
                .HasForeignKey(d => d.StateCode);
            this.HasOptional(t => t.SuperRegion)
                .WithMany(t => t.CampaignLocations)
                .HasForeignKey(d => d.SuperRegionId);

        }
    }
}
