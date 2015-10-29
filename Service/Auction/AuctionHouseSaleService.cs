using Core.Auction;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Auction
{
    public partial class AuctionHouseSaleService : IAuctionHouseSaleService
    {
        private readonly IRepository<AuctionHouseSale> _auctionHouseSaleRepository;
        public AuctionHouseSaleService(IRepository<AuctionHouseSale> auctionHouseSaleRepository)
        {
            _auctionHouseSaleRepository = auctionHouseSaleRepository;
 
        }
        public IList<AuctionHouseSale> GetAllAuctionHouseSale()
        {
            return _auctionHouseSaleRepository.Table.ToList<AuctionHouseSale>();
        }
        public IQueryable<AuctionHouseSale> GetAuctionHouseSale()
        {
            return _auctionHouseSaleRepository.Table;
        }
        public void InsertAuctionHouseSale(AuctionHouseSale auctionHouseSale)
        {
            if (auctionHouseSale == null)
                throw new ArgumentNullException("auctionHouseSale");
            _auctionHouseSaleRepository.Insert(auctionHouseSale);
        }
        public void UpdateAuctionHouseSale(AuctionHouseSale auctionHouseSale)
        {
            if (auctionHouseSale == null)
                throw new ArgumentNullException("auctionHouseSale");
            else
            {
                AuctionHouseSale result = _auctionHouseSaleRepository.GetById(auctionHouseSale.AuctionHouseSaleID);
                result.AuctionHouseSaleID = auctionHouseSale.AuctionHouseSaleID;
                result.SaleDate = auctionHouseSale.SaleDate;
                result.Title = auctionHouseSale.Title;
                  _auctionHouseSaleRepository.Update(result);
            }
 
        }
    }
}
