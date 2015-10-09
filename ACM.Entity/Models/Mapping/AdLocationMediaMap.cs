using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class AdLocationMediaMap : EntityTypeConfiguration<AdLocationMedia>
    {
        public AdLocationMediaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.CreatedDate, t.CreatedBy, t.AdLocationCode, t.MediaFileTypeMask, t.DuplicateMask, t.Status });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CreatedBy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AdLocationCode)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.MediaSufix)
                .HasMaxLength(50);

            this.Property(t => t.MediaFileTypeMask)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DuplicateMask)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FileSpec640)
                .HasMaxLength(255);

            this.Property(t => t.FileSpec800)
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("AdLocationMedia");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.MediaSufix).HasColumnName("MediaSufix");
            this.Property(t => t.MediaFileTypeMask).HasColumnName("MediaFileTypeMask");
            this.Property(t => t.DuplicateMask).HasColumnName("DuplicateMask");
            this.Property(t => t.FileSpec640).HasColumnName("FileSpec640");
            this.Property(t => t.FileSpec800).HasColumnName("FileSpec800");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.AdLocation)
                .WithMany(t => t.AdLocationMedias)
                .HasForeignKey(d => d.AdLocationCode);

        }
    }
}
