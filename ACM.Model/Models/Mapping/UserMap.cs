using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ACM.Model.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.LoginId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Phoneno)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.ManagerFirstName)
                .HasMaxLength(50);

            this.Property(t => t.ManagerLastName)
                .HasMaxLength(50);

            this.Property(t => t.ManagerEmail)
                .HasMaxLength(50);

            this.Property(t => t.AU)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LoginId).HasColumnName("LoginId");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Phoneno).HasColumnName("Phoneno");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.LOBId).HasColumnName("LOBId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.ManagerFirstName).HasColumnName("ManagerFirstName");
            this.Property(t => t.ManagerLastName).HasColumnName("ManagerLastName");
            this.Property(t => t.ManagerEmail).HasColumnName("ManagerEmail");
            this.Property(t => t.AU).HasColumnName("AU");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.LOB)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.LOBId);
            this.HasOptional(t => t.Role)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.RoleId);
            this.HasOptional(t => t.Role1)
                .WithMany(t => t.Users1)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
