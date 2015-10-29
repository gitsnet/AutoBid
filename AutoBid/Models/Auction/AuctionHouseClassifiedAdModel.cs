using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Auction;

namespace AutoBid.Models.Auction
{
    public class AuctionHouseClassifiedAdModel
    {
        public AuctionHouseClassifiedAdModel()
        {
            AuctionHouseCarSellingList = new List<AuctionHouseCarSelling>();
 
        }

       public List<AuctionHouseCarSelling> AuctionHouseCarSellingList { get; set; }

       public string Reserve { get; set; }
       public string RegistrationNo { get; set; }
       public string VehicleName { get; set; }


    }
}