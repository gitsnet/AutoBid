using AutoBid.Models.CarDetails;
using Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoBid.Models.Misc;
using Core.CarSeller;
using Core.Auction;

namespace AutoBid.Models.Home
{
    public class IndexHomeModel
    {
        public long MakeID { get; set; }
        public string MakeName { get; set; }

        public int ModelID { get; set; }        
        public string ModelName { get; set; }

        public long CarSellerTypeID { get; set; }
        public string CarSellerTypeName { get; set; }

        public long TransmissionID { get; set; }
        public string TransmissionName { get; set; }

        public long BodyTypeID { get; set; }
        public string BodyTypeName { get; set; }

        public long FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }

        public long CarSellingOnID { get; set; }
        public long CarSellingOnName { get; set; }

        public string SearchText { get; set; }

        public List<Make> MakeList { get; set; }
        public List<CarModel> ModelList { get; set; }

        public string minPrice { get; set; }
        public string maxPrice { get; set; }

        public IList<HomeModel> HomeModelList{get;set;}        
        public List<CarDetailsModel> CarDetailsList { get; set; }
        public List<BodyType> bodyTypeList { get; set; }
        public List<TransmissionType> transmissionTypeList { get; set; }
        public List<FuelType> fuelTypeList { get; set; }
        public List<CarSellerType> CarSellerTypeList { get; set; }
        public List<CarSellingOn> CarSellingOnList { get; set; }
        public List<AuctionHouseCarSelling> AuctionHouseCarSellingList { get; set; }
        public List<CarSellerVehicleInfo> CarSellerVehicleInfoList { get; set; }
        //public List<CarViewModel> CarViewModelList { get; set; }
      
    }
}