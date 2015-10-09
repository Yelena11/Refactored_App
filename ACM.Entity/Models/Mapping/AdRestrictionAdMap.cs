using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class AdRestrictionAdMap : EntityTypeConfiguration<AdRestrictionAd>
    {
        public AdRestrictionAdMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AdRestrictionAd");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AdRestrictionId).HasColumnName("AdRestrictionId");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");

            // Relationships
            this.HasRequired(t => t.Ad)
                .WithMany(t => t.AdRestrictionAds)
                .HasForeignKey(d => d.AdId);
            this.HasRequired(t => t.AdRestriction)
                .WithMany(t => t.AdRestrictionAds)
                .HasForeignKey(d => d.AdRestrictionId);

        }
    }
}
