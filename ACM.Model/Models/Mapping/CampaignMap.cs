using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CampaignMap : EntityTypeConfiguration<Campaign>
    {
        public CampaignMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignId);

            // Properties
            this.Property(t => t.CampaignName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CampaignDetails)
                .HasMaxLength(1000);

            this.Property(t => t.CampaignStatus)
                .HasMaxLength(100);

            this.Property(t => t.TargetAudience)
                .HasMaxLength(1000);

            this.Property(t => t.TargetLoadFrequency)
                .HasMaxLength(100);

            this.Property(t => t.FollowUpRequriements)
                .HasMaxLength(1000);

            this.Property(t => t.CampaignAdvertisementType)
                .HasMaxLength(20);

            this.Property(t => t.CampaignGuid)
                .HasMaxLength(50);

            this.Property(t => t.ScheduledByCampaign)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Campaign");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.CampaignName).HasColumnName("CampaignName");
            this.Property(t => t.CampaignStartDate).HasColumnName("CampaignStartDate");
            this.Property(t => t.CampaingEndDate).HasColumnName("CampaingEndDate");
            this.Property(t => t.CampaignTypeId).HasColumnName("CampaignTypeId");
            this.Property(t => t.CampaignDescription).HasColumnName("CampaignDescription");
            this.Property(t => t.CampaignDetails).HasColumnName("CampaignDetails");
            this.Property(t => t.RequestorId).HasColumnName("RequestorId");
            this.Property(t => t.CampaignStatus).HasColumnName("CampaignStatus");
            this.Property(t => t.PrimaryProductManagerId).HasColumnName("PrimaryProductManagerId");
            this.Property(t => t.SecondaryProductManagerId).HasColumnName("SecondaryProductManagerId");
            this.Property(t => t.SuperCategoryId).HasColumnName("SuperCategoryId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.SubCategoryId).HasColumnName("SubCategoryId");
            this.Property(t => t.PromoButtonTypeId).HasColumnName("PromoButtonTypeId");
            this.Property(t => t.TargetAudience).HasColumnName("TargetAudience");
            this.Property(t => t.TargetLoadFrequency).HasColumnName("TargetLoadFrequency");
            this.Property(t => t.ShowLimit).HasColumnName("ShowLimit");
            this.Property(t => t.FollowUpRequriements).HasColumnName("FollowUpRequriements");
            this.Property(t => t.AssignedPMId).HasColumnName("AssignedPMId");
            this.Property(t => t.CampaignAdvertisementType).HasColumnName("CampaignAdvertisementType");
            this.Property(t => t.CampaignPriority).HasColumnName("CampaignPriority");
            this.Property(t => t.CampaignTableStatusId).HasColumnName("CampaignTableStatusId");
            this.Property(t => t.ProductPlacementId).HasColumnName("ProductPlacementId");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Field1).HasColumnName("Field1");
            this.Property(t => t.Field2).HasColumnName("Field2");
            this.Property(t => t.Field3).HasColumnName("Field3");
            this.Property(t => t.Field4).HasColumnName("Field4");
            this.Property(t => t.Field5).HasColumnName("Field5");
            this.Property(t => t.Field6).HasColumnName("Field6");
            this.Property(t => t.Field7).HasColumnName("Field7");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.CampaignGuid).HasColumnName("CampaignGuid");
            this.Property(t => t.ScheduledByCampaign).HasColumnName("ScheduledByCampaign");

            // Relationships
            this.HasOptional(t => t.CampaignTableStatu)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.CampaignTableStatusId);
            this.HasOptional(t => t.CampaignType)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.CampaignTypeId);
            this.HasOptional(t => t.Category)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.CategoryId);
            this.HasOptional(t => t.ProductPlacement)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.ProductPlacementId);
            this.HasOptional(t => t.PromoButton)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.PromoButtonTypeId);
            this.HasOptional(t => t.SubCategory)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.SubCategoryId);
            this.HasOptional(t => t.SuperCategory)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.SuperCategoryId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(d => d.RequestorId);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.Campaigns1)
                .HasForeignKey(d => d.PrimaryProductManagerId);
            this.HasOptional(t => t.User2)
                .WithMany(t => t.Campaigns2)
                .HasForeignKey(d => d.SecondaryProductManagerId);
            this.HasOptional(t => t.User3)
                .WithMany(t => t.Campaigns3)
                .HasForeignKey(d => d.AssignedPMId);

        }
    }
}
