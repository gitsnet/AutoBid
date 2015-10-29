using Core.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.User
{
    public class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UserType1)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserType1).HasColumnName("UserType");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
        }
    }
}
