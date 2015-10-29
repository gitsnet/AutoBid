using Core.Auction;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Auction
{
    public class AuctionHouseMap : EntityTypeConfiguration<AuctionHouse>
    {
        public AuctionHouseMap()
        {
            // Primary Key
            this.HasKey(t => t.AuctionHouseID);

            // Properties
            this.Property(t => t.AuctionHouseName)
                .HasMaxLength(50);

            this.Property(t => t.WebSite)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.ContactNo)
                .HasMaxLength(50);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            this.Property(t => t.Longitude)
                .HasMaxLength(50);

            this.Property(t => t.Latitude)
                .HasMaxLength(50);

            this.Property(t => t.Buyer_Fees)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AuctionHouse");
            this.Property(t => t.AuctionHouseID).HasColumnName("AuctionHouseID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AuctionHouseName).HasColumnName("AuctionHouseName");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.WebSite).HasColumnName("WebSite");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.ContactNo).HasColumnName("ContactNo");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.About).HasColumnName("About");
            this.Property(t => t.Buyer_Fees).HasColumnName("Buyer_Fees");
            this.Property(t => t.TermsCondition).HasColumnName("TermsCondition");
            this.Property(t => t.SalesCommission).HasColumnName("SalesCommission");
        }
    }
}
