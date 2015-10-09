using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class ATMAdDisplayRuleMap : EntityTypeConfiguration<ATMAdDisplayRule>
    {
        public ATMAdDisplayRuleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DeploymentPeriodID, t.AdLocationCode, t.ATMID, t.Ixclude });

            // Properties
            this.Property(t => t.DeploymentPeriodID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AdLocationCode)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.ATMID)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.Ixclude)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ATMAdDisplayRules");
            this.Property(t => t.DeploymentPeriodID).HasColumnName("DeploymentPeriodID");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.ATMID).HasColumnName("ATMID");
            this.Property(t => t.Ixclude).HasColumnName("Ixclude");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.ATMAdDisplayRules)
                .HasForeignKey(d => d.AdId);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.ATMAdDisplayRules)
                .HasForeignKey(d => d.DeploymentPeriodID);

        }
    }
}
