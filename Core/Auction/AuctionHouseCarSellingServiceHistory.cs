using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Auction;

namespace Core.Auction
{
  public partial  class AuctionHouseCarSellingServiceHistory:BaseEntity
    {
        public long ID { get; set; }
        public Nullable<long> AuctionHouseVehicleID { get; set; }
        public Nullable<long> ServiceHistoryAuctionID { get; set; }
        public virtual ServiceHistoryAuction ServiceHistoryAuction { get; set; }
        public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
    }
}
