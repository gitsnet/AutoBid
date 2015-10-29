using Core.Seller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Seller
{
    public class SellerInfoMap : EntityTypeConfiguration<SellerInfo>
    {
        public SellerInfoMap()
        {

            // Primary Key
            this.HasKey(t => new { t.ID, t.UserKey, t.UserName, t.CreatedOn, t.CreatedFromIP });

            // Properties
            //this.Property(t => t.ID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserKey)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Email)
                .HasMaxLength(256);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(250);

            this.Property(t => t.MiddleName)
                .HasMaxLength(250);

            this.Property(t => t.LastName)
                .HasMaxLength(250);

            this.Property(t => t.Address001)
                .HasMaxLength(250);

            this.Property(t => t.Address002)
                .HasMaxLength(250);

            this.Property(t => t.Address003)
                .HasMaxLength(250);

            this.Property(t => t.ContactNo)
                .HasMaxLength(250);

            this.Property(t => t.PostalCode)
                .HasMaxLength(250);

            this.Property(t => t.CreatedFromIP)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SellerInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserKey).HasColumnName("UserKey");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address001).HasColumnName("Address001");
            this.Property(t => t.Address002).HasColumnName("Address002");
            this.Property(t => t.Address003).HasColumnName("Address003");
            this.Property(t => t.ContactNo).HasColumnName("ContactNo");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedFromIP).HasColumnName("CreatedFromIP");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
            this.Property(t => t.SellerTypeID).HasColumnName("SellerTypeID");
        }
    }
}
