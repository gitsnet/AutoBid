using System.Collections.Generic;
using System.Linq;
using Core.Misc;
using Core.Data;

namespace Service.Misc
{
  public partial  class InteriorTrimService:IInteriorTrimService
    {
      private readonly IRepository<InteriorTrim> _interiorTrimRepository;
      public InteriorTrimService(IRepository<InteriorTrim> interiorTrimRepository)
      {
          _interiorTrimRepository = interiorTrimRepository;
 
      }
    public IList<InteriorTrim> GetAllInteriorTrims()
      {
          return _interiorTrimRepository.Table.ToList<InteriorTrim>();
      }

    }
}
