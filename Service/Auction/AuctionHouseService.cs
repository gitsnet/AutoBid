using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Auction;
using Core.Data;


namespace Service.Auction
{
    public partial class AuctionHouseService : IAuctionHouseService
    {
        private readonly IRepository<AuctionHouse> _auctionHouseRepository;
        public AuctionHouseService(IRepository<AuctionHouse> auctionHouseRepository)
        {
            _auctionHouseRepository = auctionHouseRepository;
        }
        public IList<AuctionHouse> GetAllAuctionDetails()
        {
            return _auctionHouseRepository.Table.ToList<AuctionHouse>();
        }
        public AuctionHouse GetAuctionByAuctionID(long id)
        {
            return _auctionHouseRepository.Table.Where(t => t.UserID == id).FirstOrDefault<AuctionHouse>();
        }
        public void InsertAuctionHouseDetails(AuctionHouse auctionHouseDetails)
        {
            if (auctionHouseDetails == null)
                throw new ArgumentNullException("AuctionHouse");
            _auctionHouseRepository.Insert(auctionHouseDetails);

        }
        public void UpdateAuctionHouseDetails(AuctionHouse auctionHouseDetails)
        {
            if (auctionHouseDetails == null)
                throw new ArgumentNullException("AuctionHouse");
            _auctionHouseRepository.Update(auctionHouseDetails);
        }
        public IQueryable<AuctionHouse> GetAllQueryableAuctionDetails()
        {
            return _auctionHouseRepository.Table;
        }
    }
}
