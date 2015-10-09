using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class ATMTypeMap : EntityTypeConfiguration<ATMType>
    {
        public ATMTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ATMTypeId);

            // Properties
            this.Property(t => t.ATMTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ATMTypeName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ShortName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ATMType");
            this.Property(t => t.ATMTypeId).HasColumnName("ATMTypeId");
            this.Property(t => t.ATMTypeName).HasColumnName("ATMTypeName");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
