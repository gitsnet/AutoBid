using Core.CarBuyer;
using Core.Misc;
using System;
using System.Collections.Generic;
using Core.Auction;

namespace Core.CarSeller
{
    public partial class CarSellerVehicleInfo : BaseEntity
    {
        public CarSellerVehicleInfo()
        {
            this.CarSellerMoreDetails = new List<CarSellerMoreDetail>();
            this.CarBuyerInfo = new List<CarBuyerInfo>();
        }

        public int ID { get; set; }
        public int CarSellerInfoID { get; set; }
        public string Title { get; set; }
        public string RegistrationNumber { get; set; }
        public Nullable<int> MakeID { get; set; }
        public Nullable<int> ModelID { get; set; }
        public Nullable<int> BodyTypeID { get; set; }
        public string Color { get; set; }
        public string EngineSize { get; set; }
        public Nullable<System.DateTime> MOTExpiryDate { get; set; }
        public Nullable<int> TransmissionTypeID { get; set; }
        public string ExactMileage { get; set; }
        public string InteriorColor { get; set; }
        public string Trim { get; set; }
        public Nullable<System.DateTime> TAXExpiryDate { get; set; }
        public string ServiceHistory { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfFirstRegistration { get; set; }
        public virtual BodyType BodyType { get; set; }
        public virtual Make Make { get; set; }

        public virtual CarSellerType CarSellerType { get; set; }
        public virtual FuelType FuelType { get; set; }

        public virtual CarModel Model { get; set; }
        public virtual ICollection<CarSellerVehicleFuelType> CarSellerVehicleFuelTypes { get; set; }
        public virtual ICollection<CarSellerVehicleImage> CarSellerVehicleImages { get; set; }
        public virtual CarSellerInfo CarSellerInfo { get; set; }
        public virtual ICollection<CarSellerMoreDetail> CarSellerMoreDetails { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }
        public virtual List<CarBuyerInfo> CarBuyerInfo { get; set; }
        public virtual DateTime? AddedDate { get; set; }

        //public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }


        public bool IsSendToAuction{ get; set; }
    }
}
