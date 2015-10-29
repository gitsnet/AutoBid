using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Auction;

namespace Core.Auction
{
  public partial  class AuctionHouseCarSellingInteriorTrim:BaseEntity
    {
        public long ID { get; set; }
        public Nullable<long> AuctionHouseVehicleID { get; set; }
        public Nullable<long> InteriorTrimID { get; set; }
        public virtual InteriorTrim InteriorTrim { get; set; }
        public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
    }
}
