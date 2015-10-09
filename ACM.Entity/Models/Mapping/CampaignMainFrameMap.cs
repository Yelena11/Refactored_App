using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class CampaignMainFrameMap : EntityTypeConfiguration<CampaignMainFrame>
    {
        public CampaignMainFrameMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignId);

            // Properties
            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BusinessProductCode)
                .HasMaxLength(10);

            this.Property(t => t.ConsumerProductCode)
                .HasMaxLength(10);

            this.Property(t => t.TargetYearPeriod)
                .HasMaxLength(7);

            this.Property(t => t.EmployeeWashOut)
                .HasMaxLength(3);

            this.Property(t => t.HV_WashOut)
                .HasMaxLength(3);

            this.Property(t => t.TrustWashOut)
                .HasMaxLength(3);

            this.Property(t => t.PCS_WashOut)
                .HasMaxLength(3);

            this.Property(t => t.Sourced_From)
                .HasMaxLength(10);

            this.Property(t => t.Sourced_LOB)
                .HasMaxLength(50);

            this.Property(t => t.CCLR_Channel)
                .HasMaxLength(10);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            this.Property(t => t.Field1)
                .HasMaxLength(100);

            this.Property(t => t.Field2)
                .HasMaxLength(100);

            this.Property(t => t.Field3)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CampaignMainFrame");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.CardTypeId).HasColumnName("CardTypeId");
            this.Property(t => t.TargetListTypeId).HasColumnName("TargetListTypeId");
            this.Property(t => t.CustomerTypeId).HasColumnName("CustomerTypeId");
            this.Property(t => t.BusinessProductCode).HasColumnName("BusinessProductCode");
            this.Property(t => t.ConsumerProductCode).HasColumnName("ConsumerProductCode");
            this.Property(t => t.TargetYearPeriod).HasColumnName("TargetYearPeriod");
            this.Property(t => t.EmployeeWashOut).HasColumnName("EmployeeWashOut");
            this.Property(t => t.HV_WashOut).HasColumnName("HV_WashOut");
            this.Property(t => t.TrustWashOut).HasColumnName("TrustWashOut");
            this.Property(t => t.PCS_WashOut).HasColumnName("PCS_WashOut");
            this.Property(t => t.Sourced_From).HasColumnName("Sourced_From");
            this.Property(t => t.Sourced_LOB).HasColumnName("Sourced_LOB");
            this.Property(t => t.SpecialProcessId).HasColumnName("SpecialProcessId");
            this.Property(t => t.CCLR_Channel).HasColumnName("CCLR_Channel");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Field1).HasColumnName("Field1");
            this.Property(t => t.Field2).HasColumnName("Field2");
            this.Property(t => t.Field3).HasColumnName("Field3");
            this.Property(t => t.Filed4).HasColumnName("Filed4");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithOptional(t => t.CampaignMainFrame);
            this.HasOptional(t => t.CardType)
                .WithMany(t => t.CampaignMainFrames)
                .HasForeignKey(d => d.CardTypeId);
            this.HasOptional(t => t.CustomerType)
                .WithMany(t => t.CampaignMainFrames)
                .HasForeignKey(d => d.CustomerTypeId);
            this.HasOptional(t => t.SpecialProcessType)
                .WithMany(t => t.CampaignMainFrames)
                .HasForeignKey(d => d.SpecialProcessId);
            this.HasOptional(t => t.TargetListType)
                .WithMany(t => t.CampaignMainFrames)
                .HasForeignKey(d => d.TargetListTypeId);

        }
    }
}
