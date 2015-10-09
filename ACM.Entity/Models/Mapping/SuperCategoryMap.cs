using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class SuperCategoryMap : EntityTypeConfiguration<SuperCategory>
    {
        public SuperCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.SuperCategoryID);

            // Properties
            this.Property(t => t.SuperCategoryName)
                .HasMaxLength(100);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("SuperCategory");
            this.Property(t => t.SuperCategoryID).HasColumnName("SuperCategoryID");
            this.Property(t => t.SuperCategoryName).HasColumnName("SuperCategoryName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
