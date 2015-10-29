using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
    public partial interface ICarSellerVehicleInfoService
    {
        #region:CarSellerVehicleInfoService
        IList<CarSellerVehicleInfo> GetAllCarSellerVehicleInfo();
        CarSellerVehicleInfo GetCarSellerVehicleInfoByID(long id);
        void InsertCarSellerVehicleInfo(CarSellerVehicleInfo carSellerVehicleInfo);
        void UpdateCarSellerVehicleInfo(CarSellerVehicleInfo carSellerVehicleInfo);
        void DeleteCarSellerVehicleInfo(CarSellerVehicleInfo carSellerVehicleInfo);
        IQueryable<CarSellerVehicleInfo> GetCarSellerVehicleInfo();

        #endregion
    }
}
