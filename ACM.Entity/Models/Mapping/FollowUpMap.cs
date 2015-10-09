using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class FollowUpMap : EntityTypeConfiguration<FollowUp>
    {
        public FollowUpMap()
        {
            // Primary Key
            this.HasKey(t => t.FollowUpId);

            // Properties
            this.Property(t => t.FollowUpDescription)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("FollowUp");
            this.Property(t => t.FollowUpId).HasColumnName("FollowUpId");
            this.Property(t => t.FollowUpDescription).HasColumnName("FollowUpDescription");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
