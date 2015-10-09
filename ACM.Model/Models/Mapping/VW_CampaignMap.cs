using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class VW_CampaignMap : EntityTypeConfiguration<VW_Campaign>
    {
        public VW_CampaignMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignName);

            // Properties
            this.Property(t => t.CampaignName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("VW_Campaign");
            this.Property(t => t.CampaignName).HasColumnName("CampaignName");
        }
    }
}
