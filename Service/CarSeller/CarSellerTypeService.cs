using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarSeller;
using Core.Data;

namespace Service.CarSeller
{
    public partial class CarSellerTypeService:ICarSellerTypeService
    {
        private readonly IRepository<CarSellerType> _carSellerTypeRepository;
        #region:Constructor

        public CarSellerTypeService(IRepository<CarSellerType> carSellerTypeRepository)
        {
            _carSellerTypeRepository = carSellerTypeRepository;
        }
        #endregion

        #region:Methods
        public IList<CarSellerType> GetAllCarSellerType()
        {
            
            return _carSellerTypeRepository.Table.ToList<CarSellerType>();
        }

        public IQueryable<CarSellerType> GetCarSellerTypeQueryable()
        {
          return  _carSellerTypeRepository.Table;
        }
        #endregion

       
    }
}
