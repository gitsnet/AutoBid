using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;
using Core.Data;

namespace Service.Auction
{
    public partial class AuctionHouseCarSellingVehicleImagesMoreService : IAuctionHouseCarSellingVehicleImagesMoreService
    {
        private readonly IRepository<AuctionHouseCarSellingVehicleImagesMore> _auctionHouseCarSellingVehicleImagesMoreRepository;
        public AuctionHouseCarSellingVehicleImagesMoreService(IRepository<AuctionHouseCarSellingVehicleImagesMore> auctionHouseCarSellingVehicleImagesMoreRepository)
        {
            _auctionHouseCarSellingVehicleImagesMoreRepository = auctionHouseCarSellingVehicleImagesMoreRepository;
        }
        public IQueryable<AuctionHouseCarSellingVehicleImagesMore> GetAuctionHouseCarSellingVehicleImagesMore()
        {
            return _auctionHouseCarSellingVehicleImagesMoreRepository.Table;
        }
        public IList<AuctionHouseCarSellingVehicleImagesMore> GetAllAuctionHouseCarSellingVehicleImagesMore()
        {
            return _auctionHouseCarSellingVehicleImagesMoreRepository.Table.ToList<AuctionHouseCarSellingVehicleImagesMore>();
        }
        public void InsertAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImagesMore auctionHouseCarSellingVehicleImageMore)
        {
            if (auctionHouseCarSellingVehicleImageMore == null)
                throw new ArgumentNullException("auctionHouseCarSaleVehicleImageMore");
            _auctionHouseCarSellingVehicleImagesMoreRepository.Insert(auctionHouseCarSellingVehicleImageMore);
        }
        public void UpdateAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImagesMore auctionHouseCarSellingVehicleImageMore)
        {
            if (auctionHouseCarSellingVehicleImageMore == null)
                throw new ArgumentNullException("auctionHouseCarSaleVehicleImageMore");
            _auctionHouseCarSellingVehicleImagesMoreRepository.Update(auctionHouseCarSellingVehicleImageMore);
 
        }
        public void DeleteAuctionHouseCarSellingVehicleImage(AuctionHouseCarSellingVehicleImagesMore auctionHouseCarSellingVehicleImageMore)
        {
            if (auctionHouseCarSellingVehicleImageMore == null)
                throw new ArgumentNullException("auctionHouseCarSaleVehicleImageMore");
            _auctionHouseCarSellingVehicleImagesMoreRepository.Delete(auctionHouseCarSellingVehicleImageMore);
 
        }
    }
}
