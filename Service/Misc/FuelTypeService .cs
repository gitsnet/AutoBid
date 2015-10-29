using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;
namespace Service.Misc
{
    public partial class FuelTypeService : IFuelTypeService
    {
        private readonly IRepository<FuelType> _FuelTypeRepository;
        public FuelTypeService(IRepository<FuelType> FuelTypeRepository)
        {
            _FuelTypeRepository = FuelTypeRepository;
        }
        public IList<FuelType> GetAllFuelTypes()
        {
            return _FuelTypeRepository.Table.ToList<FuelType>();
        }
        public IQueryable<FuelType> GeFuelTypeQueryable()
        {
            return _FuelTypeRepository.Table;
        }
    }
}
