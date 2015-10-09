using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class ATMCampaignDisplayRuleMap : EntityTypeConfiguration<ATMCampaignDisplayRule>
    {
        public ATMCampaignDisplayRuleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ATMID)
                .HasMaxLength(18);

            // Table & Column Mappings
            this.ToTable("ATMCampaignDisplayRules");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DeploymentPeriodId).HasColumnName("DeploymentPeriodId");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.Ixclude).HasColumnName("Ixclude");
            this.Property(t => t.ATMID).HasColumnName("ATMID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithMany(t => t.ATMCampaignDisplayRules)
                .HasForeignKey(d => d.CampaignId);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.ATMCampaignDisplayRules)
                .HasForeignKey(d => d.DeploymentPeriodId);

        }
    }
}
