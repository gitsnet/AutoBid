using Core.CarBuyer;
using Core.User;
using System;
using System.Collections.Generic;


namespace Core.CarSeller
{
    public partial class CarSellerInfo : BaseEntity
    {
        public CarSellerInfo()
        {
            this.CarSellerVehicleInfoes = new List<CarSellerVehicleInfo>();
            //this.CarBuyerInfo = new List<CarBuyerInfo>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> SellerTypeID { get; set; }
        public Nullable<int> WayOfSelling { get; set; }
        public virtual AspNetUsersAdditionalInfo AspNetUsersAdditionalInfo { get; set; }
        public virtual CarSellerType CarSellerType { get; set; }
        public virtual CarSellingOn CarSellingOn { get; set; }
        public virtual ICollection<CarSellerVehicleInfo> CarSellerVehicleInfoes { get; set; }

        //public virtual ICollection<CarBuyerInfo> CarBuyerInfo { get; set; }
    }
}
