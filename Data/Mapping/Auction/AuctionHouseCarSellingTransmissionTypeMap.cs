using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Auction
{
 public class AuctionHouseCarSellingTransmissionTypeMap:EntityTypeConfiguration<AuctionHouseCarSellingTransmissionType>
    {
        public AuctionHouseCarSellingTransmissionTypeMap()
        {
            this.ToTable("AuctionHouseCarSellingTransmissionType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AuctionHouseVehicleID).HasColumnName("AuctionHouseVehicleID");
            this.Property(t => t.TransmissionTypeID).HasColumnName("TransmissionTypeID");

        }
    }
}
