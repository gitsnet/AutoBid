using System;
using System.Collections.Generic;

namespace Core.Auction
{
    public partial class AuctionHouseCarSellingVehicleImagesMore:BaseEntity
    {
        public long AuctionHouseCarSellingVehicleImagesMoreID { get; set; }
        public Nullable<long> AuctionHouseCarSellingID { get; set; }
        public string Filename { get; set; }
        public string Foldername { get; set; }
        public Nullable<int> Size { get; set; }
        public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
    }
}
