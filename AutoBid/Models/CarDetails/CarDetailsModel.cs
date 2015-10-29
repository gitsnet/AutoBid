using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.CarBuyer;
using Core.CarSeller;
using Core.Misc;
using AutoBid.Models.CarSeller;
using AutoBid.Models.Home;
using AutoBid.Models.Misc;
using Core.Auction;

namespace AutoBid.Models.CarDetails
{
    public class CarDetailsModel
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ExactMileage { get; set; }
        public string TransmissionType { get; set; }
        public string ContactNumber { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }
        public string FuelType { get; set; }
        public string Title { get; set; }
        public string fuelType;
        public List<CarSellerVehicleImage> CarImages { get; set; }
        public List<AuctionHouseCarSellingVehicleImages> AucCarImages { get; set; }

        public string carType;

        public List<Make> MakeList { get; set; }

        // public List<MakeModel> MakeList { get; set; }
        public CarDetailsModel()
        {
            MakeList = new List<Make>();
        }
    }
}