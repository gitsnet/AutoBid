using Core.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.User
{
    public class AspNetUsersAdditionalInfoMap : EntityTypeConfiguration<AspNetUsersAdditionalInfo>
    {
        public AspNetUsersAdditionalInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UserKey)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.CreatedFromIP)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AspNetUsersAdditionalInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserKey).HasColumnName("UserKey");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedFromIP).HasColumnName("CreatedFromIP");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
            this.Property(t => t.SellerTypeID).HasColumnName("SellerTypeID");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.AspNetUsersAdditionalInfoes)
                .HasForeignKey(d => d.UserKey);

        }
    }
}
