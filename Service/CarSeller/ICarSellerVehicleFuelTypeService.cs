using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
    public partial interface ICarSellerVehicleFuelTypeService
    {
        void InsertCarSellerVehicleFuelType(CarSellerVehicleFuelType carSellerVehicleFuelType);
        void UpdateCarSellerVehicleFuelType(CarSellerVehicleFuelType carSellerVehicleFuelType);
        void DeleteCarSellerVehicleFuelType(List<CarSellerVehicleFuelType> carSellerVehicleFuelType);
        List<CarSellerVehicleFuelType> CarSellerVehicleFuelTypeByVehicleID(int VehicleID);
        
    }
}
