using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class StateAdDisplayRuleMap : EntityTypeConfiguration<StateAdDisplayRule>
    {
        public StateAdDisplayRuleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AdLocationCode)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.StateCode)
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("StateAdDisplayRules");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DeploymentPeriodId).HasColumnName("DeploymentPeriodId");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.Ixclude).HasColumnName("Ixclude");
            this.Property(t => t.StateCode).HasColumnName("StateCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.StateAdDisplayRules)
                .HasForeignKey(d => d.AdId);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.StateAdDisplayRules)
                .HasForeignKey(d => d.DeploymentPeriodId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.StateAdDisplayRules)
                .HasForeignKey(d => d.StateCode);

        }
    }
}
