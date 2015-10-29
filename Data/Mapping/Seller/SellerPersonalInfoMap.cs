using Core.Seller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Seller
{
    public class SellerPersonalInfoMap : EntityTypeConfiguration<SellerPersonalInfo>
    {
        public SellerPersonalInfoMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(250);           

            this.Property(t => t.LastName)
                .HasMaxLength(250);

            this.Property(t => t.Address)
                .HasMaxLength(500);

            this.Property(t => t.Email)
                .HasMaxLength(250);          

            this.Property(t => t.ContactNo)
                .HasMaxLength(250);

            this.Property(t => t.PostalCode)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SellerPersonalInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FirstName).HasColumnName("FirstName");          
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.ContactNo).HasColumnName("ContactNo");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");

            // Relationships
            this.HasOptional(t => t.AspNetUsersAdditionalInfo)
                .WithMany(t => t.SellerPersonalInfoes)
                .HasForeignKey(d => d.UserID);

        }
    }
}
