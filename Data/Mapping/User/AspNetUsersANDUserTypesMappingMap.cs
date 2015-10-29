using Core.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.User
{
    public class AspNetUsersANDUserTypesMappingMap : EntityTypeConfiguration<AspNetUsersANDUserTypesMapping>
    {
        public AspNetUsersANDUserTypesMappingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            //this.Property(t => t.ID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AspNetUsersANDUserTypesMapping");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserTypeID).HasColumnName("UserTypeID");

            // Relationships
            this.HasRequired(t => t.AspNetUsersAdditionalInfo)
                .WithMany(t => t.AspNetUsersANDUserTypesMappings)
                .HasForeignKey(d => d.UserID);
            this.HasRequired(t => t.UserType)
                .WithMany(t => t.AspNetUsersANDUserTypesMappings)
                .HasForeignKey(d => d.UserTypeID);

        }
    }
}
