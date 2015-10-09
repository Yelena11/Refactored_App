using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class MediaFileTypeMap : EntityTypeConfiguration<MediaFileType>
    {
        public MediaFileTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FileExt)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.GroupName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.IsStaticImage)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.IsAnimated)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.IsFlash)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MediaFileType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FileExt).HasColumnName("FileExt");
            this.Property(t => t.GroupCode).HasColumnName("GroupCode");
            this.Property(t => t.GroupName).HasColumnName("GroupName");
            this.Property(t => t.IsStaticImage).HasColumnName("IsStaticImage");
            this.Property(t => t.IsAnimated).HasColumnName("IsAnimated");
            this.Property(t => t.ATMTypeId).HasColumnName("ATMTypeId");
            this.Property(t => t.FileSpecSize).HasColumnName("FileSpecSize");
            this.Property(t => t.IsFlash).HasColumnName("IsFlash");

            // Relationships
            this.HasRequired(t => t.ATMType)
                .WithMany(t => t.MediaFileTypes)
                .HasForeignKey(d => d.ATMTypeId);

        }
    }
}
