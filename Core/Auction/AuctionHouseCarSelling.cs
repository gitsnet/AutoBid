using Core.Misc;
using System;
using System.Collections.Generic;
using Core.Auction;
using Core.CarSeller;

namespace Core.Auction
{
    public partial class AuctionHouseCarSelling:BaseEntity
    {
        //public AuctionHouseCarSelling()
        //{
        //    this.AuctionHouseCarSellingVehicleImages = new List<AuctionHouseCarSellingVehicleImages>();
        //    this.AuctionHouseCarSellingVehicleImagesMores = new List<AuctionHouseCarSellingVehicleImagesMore>();
        //}

        public long AuctionHouseCarSellingID { get; set; }
        public Nullable<long> AuctionHouseID { get; set; }
        public Nullable<long> AuctionHouseSaleID { get; set; }
        public string Reserve { get; set; }
        public Nullable<int> MakeID { get; set; }
        public Nullable<int> ModelID { get; set; }
        public Nullable<long> EngineSizeID { get; set; }
        public string EngineSize { get; set; }
        public string ExteriorInteriorColour { get; set; }
        public Nullable<int> BodyID { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string VINNumber { get; set; }
        public string ExactMileage { get; set; }
        public Nullable<System.DateTime> MOTExpiryDate { get; set; }
        public Nullable<System.DateTime> TaxExpiryDate { get; set; }
        public Nullable<System.DateTime> DateOfFirstRegistration { get; set; }
        public bool? IsImported { get; set; }
        public bool? IsFullVSProvided { get; set; }
        public string VSDetails { get; set; }
        public string FormerKeepersDetails { get; set; }
        public bool? HaveServiceHistory { get; set; }
        public string LastServiceDetails { get; set; }
        public bool? IsHPIClear { get; set; }
        public string TransmissionTypeIDs { get; set; }
        public string FuelTypeIDs { get; set; }
        public string InteriorTrimIDs { get; set; }
        public string ServiceHistoryAuctionIDs { get; set; }
        public string VCARDetails { get; set; }
        public bool? IsVCARregistered { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public virtual AuctionHouse AuctionHouse { get; set; }
        public virtual AuctionHouseSale AuctionHouseSale { get; set; }
        //public virtual CarSellerVehicleInfo CarSellerVehicleInfo { get; set; }
        public virtual BodyType BodyType { get; set; }
        //public virtual EngineSize EngineSize { get; set; }
        public virtual Make Make { get; set; }
        public virtual CarModel Model { get; set; }

        public virtual ICollection<AuctionHouseCarSellingVehicleImages> AuctionHouseCarSellingVehicleImages { get; set; }
        public virtual ICollection<AuctionHouseCarSellingVehicleImagesMore> AuctionHouseCarSellingVehicleImagesMores { get; set; }

        //public virtual ICollection<CarSellerVehicleImage> CarSellerVehicleImages { get; set; }
    }
}
