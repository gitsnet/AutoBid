using Core.Auction;
using Core.CarSeller;
using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class Make : BaseEntity
    {
        public Make()
        {
            this.CarSellerVehicleInfoes = new List<CarSellerVehicleInfo>();
            this.AuctionHouseCarSellings = new List<AuctionHouseCarSelling>();
        }
        public int ID { get; set; }
        public string Makename { get; set; }
        public bool IsRemoved { get; set; }
        public virtual ICollection<CarSellerVehicleInfo> CarSellerVehicleInfoes { get; set; }
        public virtual ICollection<AuctionHouseCarSelling> AuctionHouseCarSellings { get; set; }

    }
}
