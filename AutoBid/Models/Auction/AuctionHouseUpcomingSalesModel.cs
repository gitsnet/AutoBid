using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Misc;
using Core.Auction;
using System.ComponentModel.DataAnnotations;

namespace AutoBid.Models.Auction
{
    public class AuctionHouseUpcomingSalesModel
    {
    
       public AuctionHouseSale aucHouseSale { get; set; }


       [Required(ErrorMessage = "Sale Date is Required")]
       
       public string SaleDate { get; set; }

       public long SaleID { get; set; }
    

    }
   
}