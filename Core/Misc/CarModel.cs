using Core.Auction;
using Core.CarSeller;
using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class CarModel : BaseEntity
    {
        public CarModel()
        {
            this.CarSellerVehicleInfoes = new List<CarSellerVehicleInfo>();
        }
        public int ID { get; set; }
        public Nullable<int> MakeID { get; set; }
        public string Modelname { get; set; }

        //public string Makename { get; set; }
        
        public virtual ICollection<CarSellerVehicleInfo> CarSellerVehicleInfoes { get; set; }
        public virtual ICollection<AuctionHouseCarSelling> AuctionHouseCarSellings { get; set; }
    }
}
