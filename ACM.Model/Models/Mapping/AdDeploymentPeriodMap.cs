using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdDeploymentPeriodMap : EntityTypeConfiguration<AdDeploymentPeriod>
    {
        public AdDeploymentPeriodMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Adid, t.CampaignId, t.DeploymentPeriodId });

            // Properties
            this.Property(t => t.Adid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DeploymentPeriodId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AdStatus)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AdDeploymentPeriod");
            this.Property(t => t.Adid).HasColumnName("Adid");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.DeploymentPeriodId).HasColumnName("DeploymentPeriodId");
            this.Property(t => t.AdStatus).HasColumnName("AdStatus");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.AdDeploymentPeriods)
                .HasForeignKey(d => d.Adid);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.AdDeploymentPeriods)
                .HasForeignKey(d => d.DeploymentPeriodId);

        }
    }
}
