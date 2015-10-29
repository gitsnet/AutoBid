using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;
using Core.Misc;

namespace Core.Auction
{
  public partial  class AuctionHouseCarSellingTransmissionType:BaseEntity
    {
        public long ID { get; set; }
        public Nullable<long> AuctionHouseVehicleID { get; set; }
        public Nullable<int> TransmissionTypeID { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }
        public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
    }
}
