using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class AdMap : EntityTypeConfiguration<Ad>
    {
        public AdMap()
        {
            // Primary Key
            this.HasKey(t => t.AdId);

            // Properties
            this.Property(t => t.AdName)
                .HasMaxLength(100);

            

            this.Property(t => t.AdLocationCode)
                .HasMaxLength(11);

            this.Property(t => t.MediaFileTagWeb)
                .HasMaxLength(50);

            this.Property(t => t.MediaFileTagMx)
                .HasMaxLength(50);

            this.Property(t => t.MediaType)
                .HasMaxLength(20);

            this.Property(t => t.Field1)
                .HasMaxLength(100);

            this.Property(t => t.Field2)
                .HasMaxLength(100);

            this.Property(t => t.Field3)
                .HasMaxLength(100);

            this.Property(t => t.Field4)
                .HasMaxLength(100);

            this.Property(t => t.Field5)
                .HasMaxLength(100);

            this.Property(t => t.Field6)
                .HasMaxLength(100);

            this.Property(t => t.Field7)
                .HasMaxLength(100);

            this.Property(t => t.AdGuid)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Ad");
            this.Property(t => t.AdId).HasColumnName("AdId");
            this.Property(t => t.AdName).HasColumnName("AdName");
            this.Property(t => t.CampaignId).HasColumnName("CampaignId");
            this.Property(t => t.AdProductTypeId).HasColumnName("AdProductTypeId");
            this.Property(t => t.DNSScrubLevel).HasColumnName("DNSScrubLevel");
            this.Property(t => t.ATMTypeId).HasColumnName("ATMTypeId");
            this.Property(t => t.MediaVendorId).HasColumnName("MediaVendorId");
            this.Property(t => t.AdLocationCode).HasColumnName("AdLocationCode");
            this.Property(t => t.MediaFileIndex).HasColumnName("MediaFileIndex");
            this.Property(t => t.MediaFileTagWeb).HasColumnName("MediaFileTagWeb");
            this.Property(t => t.MediaFileTagMx).HasColumnName("MediaFileTagMx");
            this.Property(t => t.MediaType).HasColumnName("MediaType");
            this.Property(t => t.AdRestrictionId).HasColumnName("AdRestrictionId");
            this.Property(t => t.Field1).HasColumnName("Field1");
            this.Property(t => t.Field2).HasColumnName("Field2");
            this.Property(t => t.Field3).HasColumnName("Field3");
            this.Property(t => t.Field4).HasColumnName("Field4");
            this.Property(t => t.Field5).HasColumnName("Field5");
            this.Property(t => t.Field6).HasColumnName("Field6");
            this.Property(t => t.Field7).HasColumnName("Field7");
            this.Property(t => t.Field8).HasColumnName("Field8");
            this.Property(t => t.Field9).HasColumnName("Field9");
            this.Property(t => t.Field10).HasColumnName("Field10");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.AdGuid).HasColumnName("AdGuid");

            // Relationships
            this.HasOptional(t => t.AdLocation)
                .WithMany(t => t.Ads)
                .HasForeignKey(d => d.AdLocationCode);
            this.HasOptional(t => t.AdProductType)
                .WithMany(t => t.Ads)
                .HasForeignKey(d => d.AdProductTypeId);
            this.HasOptional(t => t.ATMType)
                .WithMany(t => t.Ads)
                .HasForeignKey(d => d.ATMTypeId);

        }
    }
}
