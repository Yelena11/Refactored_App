using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class DeploymentPeriodMap : EntityTypeConfiguration<DeploymentPeriod>
    {
        public DeploymentPeriodMap()
        {
            // Primary Key
            this.HasKey(t => t.DeploymentPeriodId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Closed)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("DeploymentPeriod");
            this.Property(t => t.DeploymentPeriodId).HasColumnName("DeploymentPeriodId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.DeploymentDate).HasColumnName("DeploymentDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DefaultStartDate).HasColumnName("DefaultStartDate");
            this.Property(t => t.DefaultEndDate).HasColumnName("DefaultEndDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Closed).HasColumnName("Closed");
        }
    }
}
