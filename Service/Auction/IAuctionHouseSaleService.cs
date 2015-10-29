using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;

namespace Service.Auction
{
    public partial interface IAuctionHouseSaleService
    {
        IList<AuctionHouseSale> GetAllAuctionHouseSale();
        //AuctionHouseSale GetAuctionSaleByID(long id);
        void InsertAuctionHouseSale(AuctionHouseSale auctionHouseSale);
        void UpdateAuctionHouseSale(AuctionHouseSale auctionHouseSale);
        IQueryable<AuctionHouseSale> GetAuctionHouseSale(); 
    }
}
