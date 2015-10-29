using Core.Seller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Seller
{
    public class SellerCardDetailMap : EntityTypeConfiguration<SellerCardDetail>
    {
        public SellerCardDetailMap()
        {
           
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(250);

            this.Property(t => t.MiddleName)
                .HasMaxLength(250);

            this.Property(t => t.LastName)
                .HasMaxLength(250);

            this.Property(t => t.ContactNo)
                .HasMaxLength(50);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            this.Property(t => t.CardNumber)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SellerCardDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.ContactNo).HasColumnName("ContactNo");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.BillingAddress).HasColumnName("BillingAddress");
            this.Property(t => t.LikeToReceiveMarketingProducts).HasColumnName("LikeToReceiveMarketingProducts");

            // Relationships
            this.HasRequired(t => t.AspNetUsersAdditionalInfo)
                .WithMany(t => t.SellerCardDetails)
                .HasForeignKey(d => d.UserID);

        }
    }
}
