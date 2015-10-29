using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;

namespace Service.Auction
{
   public partial interface IAuctionHouseCarSellingVehicleImagesMoreService
    {
        IList<AuctionHouseCarSellingVehicleImagesMore> GetAllAuctionHouseCarSellingVehicleImagesMore();
        IQueryable<AuctionHouseCarSellingVehicleImagesMore> GetAuctionHouseCarSellingVehicleImagesMore();
        void InsertAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImagesMore auctionHouseCarSellingVehicleImageMore);
        void UpdateAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImagesMore auctionHouseCarSellingVehicleImageMore);
        void DeleteAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImagesMore auctionHouseCarSellingVehicleImageMore);

    }
}
