using Core.Auction;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Auction
{
    public class AuctionHouseCarSellingVehicleImagesMap : EntityTypeConfiguration<AuctionHouseCarSellingVehicleImages>
    {
        public AuctionHouseCarSellingVehicleImagesMap()
        {
            this.HasKey(t => t.AuctionHouseCarSellingVehicleImagesID);

            // Properties
            // Table & Column Mappings
            this.ToTable("AuctionHouseCarSellingVehicleImages");
            this.Property(t => t.AuctionHouseCarSellingVehicleImagesID).HasColumnName("AuctionHouseCarSellingVehicleImagesID");
            this.Property(t => t.AuctionHouseCarSellingID).HasColumnName("AuctionHouseCarSellingID");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Foldername).HasColumnName("Foldername");
            this.Property(t => t.Size).HasColumnName("Size");

            // Relationships
            this.HasOptional(t => t.AuctionHouseCarSelling)
                .WithMany(t => t.AuctionHouseCarSellingVehicleImages)
                .HasForeignKey(d => d.AuctionHouseCarSellingID);

        }
    }
}
