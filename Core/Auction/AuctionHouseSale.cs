using System;
using System.Collections.Generic;

namespace Core.Auction
{
    public partial class AuctionHouseSale:BaseEntity
    {
        public long AuctionHouseSaleID { get; set; }
        public Nullable<long> AuctionHouseID { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string Title { get; set; }
        public virtual AuctionHouse AuctionHouse { get; set; }
        public virtual List<AuctionHouseCarSelling> AuctionHouseCarSellingList { get; set; }
    }
}
