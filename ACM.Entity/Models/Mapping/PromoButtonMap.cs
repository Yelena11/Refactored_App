using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class PromoButtonMap : EntityTypeConfiguration<PromoButton>
    {
        public PromoButtonMap()
        {
            // Primary Key
            this.HasKey(t => t.PromoButtonTypeId);

            // Properties
            this.Property(t => t.PromoButtonName)
                .HasMaxLength(50);

            this.Property(t => t.RegisterEntry)
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PromoButton");
            this.Property(t => t.PromoButtonTypeId).HasColumnName("PromoButtonTypeId");
            this.Property(t => t.PromoButtonName).HasColumnName("PromoButtonName");
            this.Property(t => t.RegisterEntry).HasColumnName("RegisterEntry");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
