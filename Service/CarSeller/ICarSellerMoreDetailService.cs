using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
    public partial interface ICarSellerMoreDetailService
    {
        #region:CarSellerVehicleDetailsService
        IList<CarSellerMoreDetail> GetAllCarSellerMoreDetail();
        CarSellerMoreDetail GetCarSellerMoreDetailByID(long id);
        CarSellerMoreDetail GetCarSellerMoreDetailByVehicleID(long VehicleID);
        void InsertCarSellerMoreDetail(CarSellerMoreDetail carSellerMoreDetail);
        void UpdateCarSellerMoreDetail(CarSellerMoreDetail carSellerMoreDetail);
        IQueryable<CarSellerMoreDetail> GetCarSellerMoreDetail();
        #endregion
    }
}
