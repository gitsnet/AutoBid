using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarSeller;
using Core.Data;

namespace Service.CarSeller
{
    public partial class CarSellerVehicleInfoService:ICarSellerVehicleInfoService
    {
        private readonly IRepository<CarSellerVehicleInfo> _carSellerVehicleInfoRepository;
        #region:Constructor

        public CarSellerVehicleInfoService(IRepository<CarSellerVehicleInfo> carSellerVehicleInfoRepository)
        {
            _carSellerVehicleInfoRepository = carSellerVehicleInfoRepository;
        }
        #endregion

        #region:Methods
        public IList<CarSellerVehicleInfo> GetAllCarSellerVehicleInfo()
        {
            return _carSellerVehicleInfoRepository.Table.ToList<CarSellerVehicleInfo>();
        }
        public void InsertCarSellerVehicleInfo(CarSellerVehicleInfo carSellerVehicleInfo)
        {
            if (carSellerVehicleInfo == null)
                throw new ArgumentNullException("CarSellerVehicleInfo");
            _carSellerVehicleInfoRepository.Insert(carSellerVehicleInfo);
        }
        public CarSellerVehicleInfo GetCarSellerVehicleInfoByID(long id)
        {
            return _carSellerVehicleInfoRepository.Table.Where<CarSellerVehicleInfo>(v => v.ID == id).FirstOrDefault<CarSellerVehicleInfo>();
        }
        
        public void UpdateCarSellerVehicleInfo(CarSellerVehicleInfo carSellerVehicleInfo)
        {
            if (carSellerVehicleInfo == null)
                throw new ArgumentNullException("carSellerVehicleInfo");
            else
            {
                CarSellerVehicleInfo result = _carSellerVehicleInfoRepository.GetById(carSellerVehicleInfo.ID);
                result.IsSendToAuction = carSellerVehicleInfo.IsSendToAuction;
                _carSellerVehicleInfoRepository.Update(result);

            }
        }
        public void DeleteCarSellerVehicleInfo(CarSellerVehicleInfo carSellerVehicleInfo)
        {
            if (carSellerVehicleInfo == null)
                throw new ArgumentNullException("carSellerVehicleInfo");
            else
            {
                CarSellerVehicleInfo result = _carSellerVehicleInfoRepository.GetById(carSellerVehicleInfo.ID);
                
                _carSellerVehicleInfoRepository.Delete(result);

            }
 
        }
        #endregion
        public IQueryable<CarSellerVehicleInfo> GetCarSellerVehicleInfo()
        {
            return _carSellerVehicleInfoRepository.Table;
        }
       
    }
}
