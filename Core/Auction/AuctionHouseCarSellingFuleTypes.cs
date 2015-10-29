using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Auction;

namespace Core.Auction
{
  public partial  class AuctionHouseCarSellingFuleTypes:BaseEntity
    {
        public long ID { get; set; }
        public Nullable<long> AuctionHouseVehicleID { get; set; }
        public Nullable<int> FuelTypeID { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
    }
}
