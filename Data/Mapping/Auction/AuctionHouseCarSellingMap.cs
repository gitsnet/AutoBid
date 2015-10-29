using Core.Auction;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Auction
{
    public class AuctionHouseCarSellingMap : EntityTypeConfiguration<AuctionHouseCarSelling>
    {
        public AuctionHouseCarSellingMap()
        {
            // Primary Key
            this.HasKey(t => t.AuctionHouseCarSellingID);

            // Properties
            this.Property(t => t.Reserve)
                .HasMaxLength(50);

            this.Property(t => t.ExteriorInteriorColour)
                .HasMaxLength(500);

            this.Property(t => t.VINNumber)
                .HasMaxLength(500);

            this.Property(t => t.ExactMileage)
                .HasMaxLength(500);

            this.Property(t => t.VSDetails)
                .HasMaxLength(500);

            this.Property(t => t.FormerKeepersDetails)
                .HasMaxLength(500);

            this.Property(t => t.LastServiceDetails)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("AuctionHouseCarSelling");
            this.Property(t => t.AuctionHouseCarSellingID).HasColumnName("AuctionHouseCarSellingID");
            this.Property(t => t.AuctionHouseID).HasColumnName("AuctionHouseID");
            this.Property(t => t.AuctionHouseSaleID).HasColumnName("AuctionHouseSaleID");
            this.Property(t => t.Reserve).HasColumnName("Reserve");
            this.Property(t => t.MakeID).HasColumnName("MakeID");
            this.Property(t => t.ModelID).HasColumnName("ModelID");
            this.Property(t => t.EngineSizeID).HasColumnName("EngineSizeID");
            this.Property(t => t.ExteriorInteriorColour).HasColumnName("ExteriorInteriorColour");
            this.Property(t => t.BodyID).HasColumnName("BodyID");
            this.Property(t => t.RegistrationDate).HasColumnName("RegistrationDate");
            this.Property(t => t.VINNumber).HasColumnName("VINNumber");
            this.Property(t => t.ExactMileage).HasColumnName("ExactMileage");
            this.Property(t => t.MOTExpiryDate).HasColumnName("MOTExpiryDate");
            this.Property(t => t.TaxExpiryDate).HasColumnName("TaxExpiryDate");
            this.Property(t => t.DateOfFirstRegistration).HasColumnName("DateOfFirstRegistration");
            this.Property(t => t.IsImported).HasColumnName("IsImported");
            this.Property(t => t.IsFullVSProvided).HasColumnName("IsFullVSProvided");
            this.Property(t => t.VSDetails).HasColumnName("VSDetails");
            this.Property(t => t.FormerKeepersDetails).HasColumnName("FormerKeepersDetails");
            this.Property(t => t.HaveServiceHistory).HasColumnName("HaveServiceHistory");
            this.Property(t => t.LastServiceDetails).HasColumnName("LastServiceDetails");
            this.Property(t => t.IsHPIClear).HasColumnName("IsHPIClear");
            this.Property(t => t.TransmissionTypeIDs).HasColumnName("TransmissionTypeIDs");
            this.Property(t => t.FuelTypeIDs).HasColumnName("FuelTypeIDs");
            this.Property(t => t.InteriorTrimIDs).HasColumnName("InteriorTrimIDs");
            this.Property(t => t.ServiceHistoryAuctionIDs).HasColumnName("ServiceHistoryAuctionIDs");
            this.Property(t => t.VCARDetails).HasColumnName("VCARDetails");
            this.Property(t => t.IsVCARregistered).HasColumnName("IsVCARregistered");
            this.Property(t => t.RegistrationNo).HasColumnName("RegistrationNo");
             this.Property(t => t.EngineSize).HasColumnName("EngineSize");
             this.Property(t => t.VehicleID).HasColumnName("VehicleID");

            // Relationships
            this.HasOptional(t => t.AuctionHouse)
                .WithMany(t => t.AuctionHouseCarSellings)
                .HasForeignKey(d => d.AuctionHouseID);

            //this.HasOptional(t => t.AuctionHouseSale)
            //   .WithMany(t => t.AuctionHouseCarSellingList)
            //   .HasForeignKey(d => d.AuctionHouseSaleID);

            this.HasOptional(t => t.BodyType)
               .WithMany(t => t.AuctionHouseCarSellings)
              .HasForeignKey(d => d.BodyID);

            //this.HasOptional(t => t.EngineSize)
            //    .WithMany(t => t.AuctionHouseCarSellings)
            //    .HasForeignKey(d => d.EngineSizeID);
            this.HasOptional(t => t.Make)
                .WithMany(t => t.AuctionHouseCarSellings)
                .HasForeignKey(d => d.MakeID);
            this.HasOptional(t => t.Model)
                .WithMany(t => t.AuctionHouseCarSellings)
                .HasForeignKey(d => d.ModelID);
           

        }
    }
}
