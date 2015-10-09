using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Entity.Models.Mapping
{
    public class EventTriggerMap : EntityTypeConfiguration<EventTrigger>
    {
        public EventTriggerMap()
        {
            // Primary Key
            this.HasKey(t => t.EventTriggerId);

            // Properties
            this.Property(t => t.EventTriggerName)
                .HasMaxLength(50);

            this.Property(t => t.RegisterEntry)
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("EventTrigger");
            this.Property(t => t.EventTriggerId).HasColumnName("EventTriggerId");
            this.Property(t => t.EventTriggerName).HasColumnName("EventTriggerName");
            this.Property(t => t.RegisterEntry).HasColumnName("RegisterEntry");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
