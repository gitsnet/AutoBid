using System.Collections.Generic;
using System.Linq;
using Core.Misc;
using Core.Data;

namespace Service.Misc
{
  public partial  class ServiceHistoryAuctionService:IServiceHistoryAuctionService
    {
      private readonly IRepository<ServiceHistoryAuction> _serviceHistoryAuctionRepository;
      public ServiceHistoryAuctionService(IRepository<ServiceHistoryAuction> serviceHistoryAuctionRepository)
      {
          _serviceHistoryAuctionRepository = serviceHistoryAuctionRepository;
 
      }
      public IList<ServiceHistoryAuction> GetAllServiceHistoryAuctions()
      {
          return _serviceHistoryAuctionRepository.Table.ToList<ServiceHistoryAuction>();
      }
      
    }
}
