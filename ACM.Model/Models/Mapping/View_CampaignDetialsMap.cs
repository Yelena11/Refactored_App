using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class View_CampaignDetialsMap : EntityTypeConfiguration<View_CampaignDetials>
    {
        public View_CampaignDetialsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CampaignName, t.CampaignDetails, t.CampaignTypeName, t.CreatedBy });

            // Properties
            this.Property(t => t.CampaignName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.CampaignDetails)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.TargetAudience)
                .HasMaxLength(1000);

            this.Property(t => t.FollowUpRequriements)
                .HasMaxLength(1000);

            this.Property(t => t.CampaignStatus)
                .HasMaxLength(50);

            this.Property(t => t.LOBName)
                .HasMaxLength(50);

            this.Property(t => t.CampaignTypeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SuperRegionName)
                .HasMaxLength(50);

            this.Property(t => t.RegionName)
                .HasMaxLength(100);

            this.Property(t => t.TargetFileProviderDesc)
                .HasMaxLength(100);

            this.Property(t => t.Frequency)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("View_CampaignDetials");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.CampaignName).HasColumnName("CampaignName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.CampaignDetails).HasColumnName("CampaignDetails");
            this.Property(t => t.TargetAudience).HasColumnName("TargetAudience");
            this.Property(t => t.FollowUpRequriements).HasColumnName("FollowUpRequriements");
            this.Property(t => t.CampaignStartDate).HasColumnName("CampaignStartDate");
            this.Property(t => t.CampaingEndDate).HasColumnName("CampaingEndDate");
            this.Property(t => t.AssignedPMId).HasColumnName("AssignedPMId");
            this.Property(t => t.CampaignStatus).HasColumnName("CampaignStatus");
            this.Property(t => t.LOBName).HasColumnName("LOBName");
            this.Property(t => t.CampaignTypeName).HasColumnName("CampaignTypeName");
            this.Property(t => t.SuperRegionName).HasColumnName("SuperRegionName");
            this.Property(t => t.RegionName).HasColumnName("RegionName");
            this.Property(t => t.TargetFileProviderDesc).HasColumnName("TargetFileProviderDesc");
            this.Property(t => t.Frequency).HasColumnName("Frequency");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
