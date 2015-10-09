using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class LOBMap : EntityTypeConfiguration<LOB>
    {
        public LOBMap()
        {
            // Primary Key
            this.HasKey(t => t.LOBId);

            // Properties
            this.Property(t => t.LOBName)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("LOB");
            this.Property(t => t.LOBId).HasColumnName("LOBId");
            this.Property(t => t.LOBName).HasColumnName("LOBName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
