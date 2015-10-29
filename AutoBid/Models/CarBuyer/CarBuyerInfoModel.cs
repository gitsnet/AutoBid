using Core.Auction;
using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Models.CarBuyer
{
    public class CarBuyerInfoModel
    {
        
        public string Title { get; set; }
        public string BuyDate { get; set; }
        public string BuyingPrice { get; set; }
        public string BuyerImage { get; set; }
        public IList<CarSellerVehicleImage> BuyerImages { get; set; }
        public int VehicleID { get; set; }
        public string EncodedVehicleID { get; set; }
        public int WayOfSellingID { get; set; }
        public string WayOfSelling { get; set; }
        public double OfferMadePrice { get; set; }
        public CarSellerInfo carSellerInfo { get; set; }
        public List<AuctionHouse> AuctionHouseList { get; set; }
        public long AuctionHouseID { get; set; }
        public long AuctionHouseCarSellingID { get; set; }
        public AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
        public string Filename { get; set; }
        public string Foldername { get; set; }
        public int Size { get; set; }
        

        public bool IsSendToAuction { get; set; }
    }
}