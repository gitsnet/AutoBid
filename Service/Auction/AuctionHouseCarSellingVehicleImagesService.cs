using System;
using System.Collections.Generic;
using System.Linq;
using Core.Auction;
using Core.Data;

namespace Service.Auction
{
    public partial class AuctionHouseCarSellingVehicleImagesService : IAuctionHouseCarSellingVehicleImagesService
    {

        private readonly IRepository<AuctionHouseCarSellingVehicleImages> _auctionHouseCarSellingVehicleImagesRepository;


        public AuctionHouseCarSellingVehicleImagesService(IRepository<AuctionHouseCarSellingVehicleImages> auctionHouseCarSellingVehicleImagesRepository)
        {
            _auctionHouseCarSellingVehicleImagesRepository = auctionHouseCarSellingVehicleImagesRepository;
        }

        public IQueryable<AuctionHouseCarSellingVehicleImages> GetAuctionHouseCarSellingVehicleImages()
        {
            return _auctionHouseCarSellingVehicleImagesRepository.Table;
        }
        public IList<AuctionHouseCarSellingVehicleImages> GetAllAuctionHouseCarSellingVehicleImages()
        {
            return _auctionHouseCarSellingVehicleImagesRepository.Table.ToList<AuctionHouseCarSellingVehicleImages>();

        }
        public void InsertAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImages auctionHouseCarSellingVehicleImage)
        {
            if (auctionHouseCarSellingVehicleImage == null)
                throw new ArgumentNullException("AuctionHouseSaleVehicleImage");
            _auctionHouseCarSellingVehicleImagesRepository.Insert(auctionHouseCarSellingVehicleImage);
        }
        public void UpdateAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImages auctionHouseCarSellingVehicleImage)
        {
            if (auctionHouseCarSellingVehicleImage == null)
                throw new ArgumentNullException("AuctionHouseSaleVehicleImage");
            _auctionHouseCarSellingVehicleImagesRepository.Update(auctionHouseCarSellingVehicleImage);

        }
        public void DeleteAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImages auctionHouseCarSellingVehicleImage)
        {
            if (auctionHouseCarSellingVehicleImage == null)
                throw new ArgumentNullException("AuctionHouseSaleVehicleImage");
            else {
                AuctionHouseCarSellingVehicleImages result = _auctionHouseCarSellingVehicleImagesRepository.GetById(auctionHouseCarSellingVehicleImage.AuctionHouseCarSellingVehicleImagesID);

                _auctionHouseCarSellingVehicleImagesRepository.Delete(result);
            }
 
        }
    }
}
