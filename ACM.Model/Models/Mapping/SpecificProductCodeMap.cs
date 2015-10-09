using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class SpecificProductCodeMap : EntityTypeConfiguration<SpecificProductCode>
    {
        public SpecificProductCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.SpecificProductCodesId);

            // Properties
            this.Property(t => t.SpecificProductCodesId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("SpecificProductCodes");
            this.Property(t => t.SpecificProductCodesId).HasColumnName("SpecificProductCodesId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
