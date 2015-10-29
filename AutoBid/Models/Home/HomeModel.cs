using Core.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Models.Home
{
    public class HomeModel
    {
        public string VehicleImage { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string Price { get; set; }
        public string EncodedVehicleID { get; set; }
        public string ID { get; set; }
     
    }
}