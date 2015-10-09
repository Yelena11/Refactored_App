using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdOutStandingTaskMap : EntityTypeConfiguration<AdOutStandingTask>
    {
        public AdOutStandingTaskMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AdId, t.CampaignId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.AdId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OutStandingTasks)
                .HasMaxLength(100);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("AdOutStandingTask");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.OutStandingTasks).HasColumnName("OutStandingTasks");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.TasksOrder).HasColumnName("TasksOrder");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.AdOutStandingTasks)
                .HasForeignKey(d => d.AdId);

        }
    }
}
