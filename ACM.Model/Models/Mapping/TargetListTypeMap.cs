using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class TargetListTypeMap : EntityTypeConfiguration<TargetListType>
    {
        public TargetListTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.TargetListTypeId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TargetListType");
            this.Property(t => t.TargetListTypeId).HasColumnName("TargetListTypeId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
