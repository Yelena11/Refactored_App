using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class CustomerTypeMap : EntityTypeConfiguration<CustomerType>
    {
        public CustomerTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerTypeId);

            // Properties
            this.Property(t => t.CustomerTypeDesc)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("CustomerType");
            this.Property(t => t.CustomerTypeId).HasColumnName("CustomerTypeId");
            this.Property(t => t.CustomerTypeDesc).HasColumnName("CustomerTypeDesc");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
