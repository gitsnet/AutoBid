using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;
namespace Service.Misc
{
    public partial class BodyTypeService : IBodyTypeService
    {
        private readonly IRepository<BodyType> _bodyTypeRepository;
        public BodyTypeService(IRepository<BodyType> bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }
        public IList<BodyType> GetAllBodyTypes()
        {
            return _bodyTypeRepository.Table.ToList<BodyType>().Where(t => t.IsRemoved==false).ToList<BodyType>();
        }
    }
}
