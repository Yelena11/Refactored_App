using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CampaignDeploymentPeriodMap : EntityTypeConfiguration<CampaignDeploymentPeriod>
    {
        public CampaignDeploymentPeriodMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CampaignId, t.DeploymentPeriodId });

            // Properties
            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DeploymentPeriodId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CampaignStatus)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CampaignDeploymentPeriod");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.DeploymentPeriodId).HasColumnName("DeploymentPeriodId");
            this.Property(t => t.CampaignStatus).HasColumnName("CampaignStatus");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithMany(t => t.CampaignDeploymentPeriods)
                .HasForeignKey(d => d.CampaignId);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.CampaignDeploymentPeriods)
                .HasForeignKey(d => d.DeploymentPeriodId);

        }
    }
}
