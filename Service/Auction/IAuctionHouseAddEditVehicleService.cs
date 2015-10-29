using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;

namespace Service.Auction
{
    public interface IAuctionHouseAddEditVehicleService
    {
        IList<AuctionHouseCarSelling> GetAllAuctionHouseCarSelling();
        IQueryable<AuctionHouseCarSelling> GetAuctionHouseCarSelling();
        AuctionHouseCarSelling GetAuctionHouseCarSellingByID(long id);
       List<AuctionHouseCarSelling> GetAuctionHouseCarSellingBySaleID(long SaleId);
        AuctionHouseCarSelling InsertAuctionHouseCarSelling(AuctionHouseCarSelling auctionHouseCarSelling);
        bool UpdateAuctionHouseCarSelling(AuctionHouseCarSelling auctionHouseCarSelling);
        void DeleteAuctionHouseCarSelling(AuctionHouseCarSelling auctionHouseCarSelling);
    }
}
