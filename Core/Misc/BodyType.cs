using Core.Auction;
using Core.CarSeller;
using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class BodyType : BaseEntity
    {
        public BodyType()
        {
            this.CarSellerVehicleInfoes = new List<CarSellerVehicleInfo>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
        public virtual ICollection<CarSellerVehicleInfo> CarSellerVehicleInfoes { get; set; }
        public virtual ICollection<AuctionHouseCarSelling> AuctionHouseCarSellings { get; set; }
    }
}
