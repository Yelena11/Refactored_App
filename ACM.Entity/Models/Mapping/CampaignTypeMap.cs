using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class CampaignTypeMap : EntityTypeConfiguration<CampaignType>
    {
        public CampaignTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignTypeId);

            // Properties
            this.Property(t => t.CampaignTypeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CampaignTypeStatus)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CampaignType");
            this.Property(t => t.CampaignTypeId).HasColumnName("CampaignTypeId");
            this.Property(t => t.CampaignTypeName).HasColumnName("CampaignTypeName");
            this.Property(t => t.CampaignTypeStatus).HasColumnName("CampaignTypeStatus");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
