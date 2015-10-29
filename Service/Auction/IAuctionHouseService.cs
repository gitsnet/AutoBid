using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;

namespace Service.Auction
{
   public partial interface IAuctionHouseService
    {
        #region Auction
       IList<AuctionHouse> GetAllAuctionDetails();
       AuctionHouse GetAuctionByAuctionID(long id);
       void InsertAuctionHouseDetails(AuctionHouse auctionHouseDetails);
       void UpdateAuctionHouseDetails(AuctionHouse auctionHouseDetails);
       IQueryable<AuctionHouse> GetAllQueryableAuctionDetails(); 
        #endregion
    }
}
