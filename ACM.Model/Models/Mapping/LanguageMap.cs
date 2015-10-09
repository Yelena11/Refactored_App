using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.LanguageId);

            // Properties
            this.Property(t => t.LanguageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Status)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Languages");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
