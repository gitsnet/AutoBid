using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;

namespace Service.Misc
{
   public partial class EngineSizeService:IEngineSizeService
    {
       private readonly IRepository<EngineSize> _engineSizeRepository;
       public EngineSizeService(IRepository<EngineSize> engineSizeRepository)
       {
           _engineSizeRepository = engineSizeRepository;
 
       }
       public IList<EngineSize> GetAllEngineSizes()
       {
           return _engineSizeRepository.Table.ToList<EngineSize>();
       }
    }
}
