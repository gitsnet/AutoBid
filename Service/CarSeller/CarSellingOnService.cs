using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarSeller;
using Core.Data;

namespace Service.CarSeller
{
    public partial class CarSellingOnService:ICarSellingOnService
    {
        private readonly IRepository<CarSellingOn> _carSellingOnRepository;
        #region:Constructor

        public CarSellingOnService(IRepository<CarSellingOn> carSellingOnRepository)
        {
            _carSellingOnRepository = carSellingOnRepository;
        }
        #endregion

        #region:Methods
        public IList<CarSellingOn> GetAllCarSellinOn()
        {
            return _carSellingOnRepository.Table.ToList<CarSellingOn>();
        }
        #endregion
    }
}
