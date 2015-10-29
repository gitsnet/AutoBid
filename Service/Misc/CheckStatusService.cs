using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;


namespace Service.Misc
{
  public partial class CheckStatusService:ICheckStatusService
    {
      private readonly IRepository<CheckStatus> _checkStatusRepository;
      public CheckStatusService(IRepository<CheckStatus> checkStatusRepository)
      {
          _checkStatusRepository = checkStatusRepository;
 
      }
      public IList<CheckStatus> GetAllCheckStatus()
      {
          return _checkStatusRepository.Table.ToList<CheckStatus>();
      }
    }
}
