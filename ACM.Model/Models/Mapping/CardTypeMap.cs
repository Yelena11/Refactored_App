using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class CardTypeMap : EntityTypeConfiguration<CardType>
    {
        public CardTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CardTypeId);

            // Properties
            this.Property(t => t.CardDescription)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CardType");
            this.Property(t => t.CardTypeId).HasColumnName("CardTypeId");
            this.Property(t => t.CardDescription).HasColumnName("CardDescription");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
