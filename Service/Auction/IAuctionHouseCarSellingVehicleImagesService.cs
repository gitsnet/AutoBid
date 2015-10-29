using System.Collections.Generic;
using System.Linq;
using Core.Auction;

namespace Service.Auction
{
    public partial interface  IAuctionHouseCarSellingVehicleImagesService
    {
        IList<AuctionHouseCarSellingVehicleImages> GetAllAuctionHouseCarSellingVehicleImages();
        IQueryable<AuctionHouseCarSellingVehicleImages> GetAuctionHouseCarSellingVehicleImages();
        void InsertAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImages auctionHouseCarSellingVehicleImage);
        void UpdateAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImages auctionHouseCarSellingVehicleImage);
        void DeleteAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImages auctionHouseCarSellingVehicleImage);
    }
}
