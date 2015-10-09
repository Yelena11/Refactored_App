using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class SpecialProcessTypeMap : EntityTypeConfiguration<SpecialProcessType>
    {
        public SpecialProcessTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.SpecialProcessTypeId);

            // Properties
            this.Property(t => t.SpecialProcessTypeDesc)
                .HasMaxLength(10);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("SpecialProcessType");
            this.Property(t => t.SpecialProcessTypeId).HasColumnName("SpecialProcessTypeId");
            this.Property(t => t.SpecialProcessTypeDesc).HasColumnName("SpecialProcessTypeDesc");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
