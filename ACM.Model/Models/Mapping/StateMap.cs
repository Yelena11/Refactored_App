using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            // Primary Key
            this.HasKey(t => t.StateCode);

            // Properties
            this.Property(t => t.StateCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.StateName)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("States");
            this.Property(t => t.StateCode).HasColumnName("StateCode");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
