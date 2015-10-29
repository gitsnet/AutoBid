using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;
using Core.Data;

namespace Service.Auction
{
    public partial class AuctionHouseAddEditVehicleService : IAuctionHouseAddEditVehicleService
    {
        private readonly IRepository<AuctionHouseCarSelling> _auctionHouseCarSellingRepository;
        public AuctionHouseAddEditVehicleService(IRepository<AuctionHouseCarSelling> auctionHouseCarSellingRepository)
        {
            _auctionHouseCarSellingRepository = auctionHouseCarSellingRepository;
        }
        public IList<AuctionHouseCarSelling> GetAllAuctionHouseCarSelling()
        {
            return _auctionHouseCarSellingRepository.Table.ToList<AuctionHouseCarSelling>();
        }
        public IQueryable<AuctionHouseCarSelling> GetAuctionHouseCarSelling()
        {
            return _auctionHouseCarSellingRepository.Table;
        }
        public AuctionHouseCarSelling GetAuctionHouseCarSellingByID(long id)
        {
            return _auctionHouseCarSellingRepository.Table.Where(t => t.AuctionHouseCarSellingID == id).FirstOrDefault<AuctionHouseCarSelling>();
        }
        public AuctionHouseCarSelling InsertAuctionHouseCarSelling(AuctionHouseCarSelling auctionHouseCarSelling)
        {
            if (auctionHouseCarSelling == null)
                return null;
            else
            {
                _auctionHouseCarSellingRepository.Insert(auctionHouseCarSelling);
                return auctionHouseCarSelling;
            }
        }
        public bool UpdateAuctionHouseCarSelling(AuctionHouseCarSelling auctionHouseCarSelling)
        {
            if (auctionHouseCarSelling == null)
                return false;
            else
            {
                _auctionHouseCarSellingRepository.Update(auctionHouseCarSelling);
                return true;
            }
            
        }
        public List<AuctionHouseCarSelling> GetAuctionHouseCarSellingBySaleID(long SaleId)
        {
            return _auctionHouseCarSellingRepository.Table.Where(t => t.AuctionHouseSaleID == SaleId).ToList<AuctionHouseCarSelling>();
        }
        public void DeleteAuctionHouseCarSelling(AuctionHouseCarSelling auctionHouseCarSelling)
        {
            if (auctionHouseCarSelling == null)
                throw new ArgumentNullException("auctionHouseCarSelling");
            else
            {
                AuctionHouseCarSelling result = _auctionHouseCarSellingRepository.GetById(auctionHouseCarSelling.AuctionHouseCarSellingID);

                _auctionHouseCarSellingRepository.Delete(result);

            }
        }
    }
}
