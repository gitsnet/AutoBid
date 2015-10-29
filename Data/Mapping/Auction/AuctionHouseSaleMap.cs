using Core.Auction;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Auction
{
    public class AuctionHouseSaleMap : EntityTypeConfiguration<AuctionHouseSale>
    {
        public AuctionHouseSaleMap()
        {
            // Primary Key
            this.HasKey(t => t.AuctionHouseSaleID);

            // Properties
            // Table & Column Mappings
            this.ToTable("AuctionHouseSale");
            this.Property(t => t.AuctionHouseSaleID).HasColumnName("AuctionHouseSaleID");
            this.Property(t => t.AuctionHouseID).HasColumnName("AuctionHouseID");
            this.Property(t => t.SaleDate).HasColumnName("SaleDate");
            this.Property(t => t.Title).HasColumnName("Title");

            // Relationships
            this.HasOptional(t => t.AuctionHouse)
                .WithMany(t => t.AuctionHouseSales)
                .HasForeignKey(d => d.AuctionHouseID);

        }
    }
}
