using Core.Auction;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Auction
{
    public class AuctionHouseCarSellingVehicleImagesMoreMap : EntityTypeConfiguration<AuctionHouseCarSellingVehicleImagesMore>
    {
        public AuctionHouseCarSellingVehicleImagesMoreMap()
        {
            // Primary Key
            this.HasKey(t => t.AuctionHouseCarSellingVehicleImagesMoreID);

            // Properties
            // Table & Column Mappings
            this.ToTable("AuctionHouseCarSellingVehicleImagesMore");
            this.Property(t => t.AuctionHouseCarSellingVehicleImagesMoreID).HasColumnName("AuctionHouseCarSellingVehicleImagesMoreID");
            this.Property(t => t.AuctionHouseCarSellingID).HasColumnName("AuctionHouseCarSellingID");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Foldername).HasColumnName("Foldername");
            this.Property(t => t.Size).HasColumnName("Size");

            // Relationships
            this.HasOptional(t => t.AuctionHouseCarSelling)
                .WithMany(t => t.AuctionHouseCarSellingVehicleImagesMores)
                .HasForeignKey(d => d.AuctionHouseCarSellingID);

        }
    }
}
