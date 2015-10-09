using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class ETMConfigurationMap : EntityTypeConfiguration<ETMConfiguration>
    {
        public ETMConfigurationMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignId);

            // Properties
            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ETMDuration)
                .HasMaxLength(50);

            this.Property(t => t.ETMEndonInteraction)
                .HasMaxLength(50);

            this.Property(t => t.ETMCanSwitchToNextETM)
                .HasMaxLength(50);

            this.Property(t => t.SupressDefault)
                .HasMaxLength(3);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ETMConfiguration");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.ETMDuration).HasColumnName("ETMDuration");
            this.Property(t => t.ETMEndonInteraction).HasColumnName("ETMEndonInteraction");
            this.Property(t => t.ETMCanSwitchToNextETM).HasColumnName("ETMCanSwitchToNextETM");
            this.Property(t => t.SupressDefault).HasColumnName("SupressDefault");
            this.Property(t => t.EventTriggerId).HasColumnName("EventTriggerId");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithOptional(t => t.ETMConfiguration);
            this.HasOptional(t => t.EventTrigger)
                .WithMany(t => t.ETMConfigurations)
                .HasForeignKey(d => d.EventTriggerId);

        }
    }
}
