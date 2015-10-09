using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class AdSchedulingConditionMap : EntityTypeConfiguration<AdSchedulingCondition>
    {
        public AdSchedulingConditionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AdLocationCode)
                .IsRequired()
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("AdSchedulingConditions");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DeploymentPeriodID).HasColumnName("DeploymentPeriodID");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.AllRegionsFlag).HasColumnName("AllRegionsFlag");
            this.Property(t => t.AllStateFlag).HasColumnName("AllStateFlag");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.AdSchedulingConditions)
                .HasForeignKey(d => d.AdId);
            this.HasRequired(t => t.AdLocation)
                .WithMany(t => t.AdSchedulingConditions)
                .HasForeignKey(d => d.AdLocationCode);
            this.HasRequired(t => t.DeploymentPeriod)
                .WithMany(t => t.AdSchedulingConditions)
                .HasForeignKey(d => d.DeploymentPeriodID);

        }
    }
}
