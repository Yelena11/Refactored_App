using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class CampaignTableStatuMap : EntityTypeConfiguration<CampaignTableStatu>
    {
        public CampaignTableStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignTableStatusId);

            // Properties
            this.Property(t => t.CampaignTableStatusDescription)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CampaignTableStatus");
            this.Property(t => t.CampaignTableStatusId).HasColumnName("CampaignTableStatusId");
            this.Property(t => t.CampaignTableStatusDescription).HasColumnName("CampaignTableStatusDescription");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
