using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CampaignTargetFileProviderMap : EntityTypeConfiguration<CampaignTargetFileProvider>
    {
        public CampaignTargetFileProviderMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignId);

            // Properties
            this.Property(t => t.CampaignId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IWillProvideTargetFile)
                .HasMaxLength(100);

            this.Property(t => t.OPRProvideTargetFile)
                .HasMaxLength(100);

            this.Property(t => t.Frequency)
                .HasMaxLength(50);

            this.Property(t => t.ECNCardNumber)
                .HasMaxLength(15);

            this.Property(t => t.TargetFileCompleted)
                .HasMaxLength(3);

            this.Property(t => t.OPRCriteria)
                .HasMaxLength(1000);

            this.Property(t => t.OPR)
                .HasMaxLength(20);

            this.Property(t => t.FollowUPNeeded)
                .HasMaxLength(3);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            this.Property(t => t.Field1)
                .HasMaxLength(100);

            this.Property(t => t.Field2)
                .HasMaxLength(100);

            this.Property(t => t.Field3)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CampaignTargetFileProvider");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.IWillProvideTargetFile).HasColumnName("IWillProvideTargetFile");
            this.Property(t => t.OPRProvideTargetFile).HasColumnName("OPRProvideTargetFile");
            this.Property(t => t.Frequency).HasColumnName("Frequency");
            this.Property(t => t.ECNCardNumber).HasColumnName("ECNCardNumber");
            this.Property(t => t.TargetFileCompleted).HasColumnName("TargetFileCompleted");
            this.Property(t => t.OPRCriteria).HasColumnName("OPRCriteria");
            this.Property(t => t.OPR).HasColumnName("OPR");
            this.Property(t => t.FollowUPNeeded).HasColumnName("FollowUPNeeded");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Field1).HasColumnName("Field1");
            this.Property(t => t.Field2).HasColumnName("Field2");
            this.Property(t => t.Field3).HasColumnName("Field3");
            this.Property(t => t.Filed4).HasColumnName("Filed4");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Campaign)
                .WithOptional(t => t.CampaignTargetFileProvider);

        }
    }
}
