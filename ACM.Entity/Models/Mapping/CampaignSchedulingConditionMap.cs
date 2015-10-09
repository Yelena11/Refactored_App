using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class CampaignSchedulingConditionMap : EntityTypeConfiguration<CampaignSchedulingCondition>
    {
        public CampaignSchedulingConditionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CampaignSchedulingConditions");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DeploymentPeriodID).HasColumnName("DeploymentPeriodID");
            this.Property(t => t.CampaignID).HasColumnName("CampaignID");
            this.Property(t => t.AllRegionsFlag).HasColumnName("AllRegionsFlag");
            this.Property(t => t.AllStateFlag).HasColumnName("AllStateFlag");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithMany(t => t.CampaignSchedulingConditions)
                .HasForeignKey(d => d.CampaignID);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.CampaignSchedulingConditions)
                .HasForeignKey(d => d.DeploymentPeriodID);

        }
    }
}
