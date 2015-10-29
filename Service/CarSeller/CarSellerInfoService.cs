using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarSeller;
using Core.Data;

namespace Service.CarSeller
{
    public partial class CarSellerInfoService:ICarSellerInfoService
    {
        private readonly IRepository<CarSellerInfo> _carSellerInfoRepository;
        #region:Constructor

        public CarSellerInfoService(IRepository<CarSellerInfo> carSellerInfoRepository)
        {
            _carSellerInfoRepository = carSellerInfoRepository;
        }
        #endregion

        #region:Methods
        public IList<CarSellerInfo> GetAllCarSellerInfo()
        {
            return _carSellerInfoRepository.Table.ToList<CarSellerInfo>();
        }
        public void InsertCarSellerInfo(CarSellerInfo carSellerInfo)
        {
            if (carSellerInfo == null)
                throw new ArgumentNullException("CarSellerInfo");
            _carSellerInfoRepository.Insert(carSellerInfo);
        }
        public void UpdateCarSellerInfo(CarSellerInfo carSellerInfo)
        {
            if (carSellerInfo == null)
                throw new ArgumentNullException("carSellerInfo");
            _carSellerInfoRepository.Update(carSellerInfo);
        }
        public CarSellerInfo GetCarSellerInfoByCarSellerInfoID(int CarSellerInfoID)
        {
            return _carSellerInfoRepository.Table.Where<CarSellerInfo>(csi => csi.ID == CarSellerInfoID).FirstOrDefault<CarSellerInfo>();
        }
        #endregion

       
    }
}
