using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;
namespace Service.Misc
{
    public partial class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly IRepository<TransmissionType> _TransmissionTypeRepository;
        public TransmissionTypeService(IRepository<TransmissionType> TransmissionTypeRepository)
        {
            _TransmissionTypeRepository = TransmissionTypeRepository;
        }
        public IList<TransmissionType> GetAllTransmissionTypes()
        {
            return _TransmissionTypeRepository.Table.ToList<TransmissionType>();
        }
        public IQueryable<TransmissionType> GeTransmissionTypeQueryable()
        {
            return _TransmissionTypeRepository.Table;
        }
    }
}
