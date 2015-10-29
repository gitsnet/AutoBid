using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarSeller;
using Core.Data;

namespace Service.CarSeller
{
    public partial class CarSellerMoreDetailService:ICarSellerMoreDetailService
    {
        private readonly IRepository<CarSellerMoreDetail> _carSellerMoreDetailRepository;
        #region:Constructor

        public CarSellerMoreDetailService(IRepository<CarSellerMoreDetail> carSellerMoreDetailRepository)
        {
            _carSellerMoreDetailRepository = carSellerMoreDetailRepository;
        }
        #endregion

        #region:Methods
        public IList<CarSellerMoreDetail> GetAllCarSellerMoreDetail()
        {
            return _carSellerMoreDetailRepository.Table.ToList<CarSellerMoreDetail>();
        }
        public void InsertCarSellerMoreDetail(CarSellerMoreDetail carSellerMoreDetail)
        {
            if (carSellerMoreDetail == null)
                throw new ArgumentNullException("carSellerMoreDetail");
            _carSellerMoreDetailRepository.Insert(carSellerMoreDetail);
        }
        public CarSellerMoreDetail GetCarSellerMoreDetailByID(long id)
        {
            return _carSellerMoreDetailRepository.Table.Where<CarSellerMoreDetail>(v => v.ID == id).FirstOrDefault<CarSellerMoreDetail>();
        }
        public CarSellerMoreDetail GetCarSellerMoreDetailByVehicleID(long VehicleID)
        {
            return _carSellerMoreDetailRepository.Table.Where<CarSellerMoreDetail>(v => v.VehicleID == VehicleID).FirstOrDefault<CarSellerMoreDetail>();
        }
        public void UpdateCarSellerMoreDetail(CarSellerMoreDetail carSellerMoreDetail)
        {
            if (carSellerMoreDetail == null)
                throw new ArgumentNullException("CarSellerMoreDetail");
            _carSellerMoreDetailRepository.Update(carSellerMoreDetail);
        }
        public IQueryable<CarSellerMoreDetail> GetCarSellerMoreDetail()
        {
            return _carSellerMoreDetailRepository.Table;
        }
        #endregion

       
    }
}
