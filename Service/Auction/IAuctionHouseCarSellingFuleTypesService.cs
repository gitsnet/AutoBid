using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;

namespace Service.Auction
{
    public partial interface IAuctionHouseCarSellingFuleTypesService
    {
        void InsertCarSellerVehicleFuelType(AuctionHouseCarSellingFuleTypes auctionHouseCarSellingFuleTypes);
        void UpdateCarSellerVehicleFuelType(AuctionHouseCarSellingFuleTypes auctionHouseCarSellingFuleTypes);
        void DeleteCarSellerVehicleFuelType(List<AuctionHouseCarSellingFuleTypes> auctionHouseCarSellingFuleTypes);
        List<AuctionHouseCarSellingFuleTypes> AuctionHouseCarSellingFuleTypesByID(int id);
    }
}
