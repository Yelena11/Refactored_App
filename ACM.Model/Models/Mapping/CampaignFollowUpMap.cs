using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CampaignFollowUpMap : EntityTypeConfiguration<CampaignFollowUp>
    {
        public CampaignFollowUpMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignId);

            // Properties
            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FollowUpRequirements)
                .HasMaxLength(1000);

            this.Property(t => t.FollowUpSystemName)
                .HasMaxLength(500);

            this.Property(t => t.Business)
                .HasMaxLength(3);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CampaignFollowUp");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.FollowUpRequirements).HasColumnName("FollowUpRequirements");
            this.Property(t => t.FollowUpId).HasColumnName("FollowUpId");
            this.Property(t => t.FollowUpSystem).HasColumnName("FollowUpSystem");
            this.Property(t => t.FollowUpSystemName).HasColumnName("FollowUpSystemName");
            this.Property(t => t.Business).HasColumnName("Business");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithOptional(t => t.CampaignFollowUp);
            this.HasOptional(t => t.FollowUp)
                .WithMany(t => t.CampaignFollowUps)
                .HasForeignKey(d => d.FollowUpId);

        }
    }
}
