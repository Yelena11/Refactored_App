using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class RegionAdDisplayRuleMap : EntityTypeConfiguration<RegionAdDisplayRule>
    {
        public RegionAdDisplayRuleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AdLocationCode)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.RegionId)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.SuperRegionId)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.StateCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("RegionAdDisplayRules");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DeploymentPeriodId).HasColumnName("DeploymentPeriodId");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.Ixclude).HasColumnName("Ixclude");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.SuperRegionId).HasColumnName("SuperRegionId");
            this.Property(t => t.StateCode).HasColumnName("StateCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.RegionAdDisplayRules)
                .HasForeignKey(d => d.AdId);
            this.HasRequired(t => t.AdLocation)
                .WithMany(t => t.RegionAdDisplayRules)
                .HasForeignKey(d => d.AdLocationCode);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.RegionAdDisplayRules)
                .HasForeignKey(d => d.DeploymentPeriodId);
            this.HasRequired(t => t.Region)
                .WithMany(t => t.RegionAdDisplayRules)
                .HasForeignKey(d => d.RegionId);
            this.HasRequired(t => t.State)
                .WithMany(t => t.RegionAdDisplayRules)
                .HasForeignKey(d => d.StateCode);

        }
    }
}
