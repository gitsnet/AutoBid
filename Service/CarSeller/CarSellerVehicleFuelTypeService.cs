using Core.CarSeller;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
    public partial class CarSellerVehicleFuelTypeService:ICarSellerVehicleFuelTypeService
    {
         private readonly IRepository<CarSellerVehicleFuelType> _carSellerVehicleFuelTypeRepository;
        #region:Constructor

         public CarSellerVehicleFuelTypeService(IRepository<CarSellerVehicleFuelType> carSellerVehicleFuelTypeRepository)
        {
            _carSellerVehicleFuelTypeRepository = carSellerVehicleFuelTypeRepository;
        }

         public void InsertCarSellerVehicleFuelType(CarSellerVehicleFuelType carSellerVehicleFuelType)
         {
             if (carSellerVehicleFuelType == null)
                 throw new ArgumentNullException("CarSellerVehicleFuelType");
             _carSellerVehicleFuelTypeRepository.Insert(carSellerVehicleFuelType);
         }

         public void UpdateCarSellerVehicleFuelType(CarSellerVehicleFuelType carSellerVehicleFuelType)
         {
             if (carSellerVehicleFuelType == null)
                 throw new ArgumentNullException("CarSellerVehicleFuelType");
             _carSellerVehicleFuelTypeRepository.Update(carSellerVehicleFuelType);
         }
         public void DeleteCarSellerVehicleFuelType(List<CarSellerVehicleFuelType> carSellerVehicleFuelType)
         {
             foreach (CarSellerVehicleFuelType item in carSellerVehicleFuelType)
             {
                 _carSellerVehicleFuelTypeRepository.Delete(item);
             }
         }
        #endregion


         public List<CarSellerVehicleFuelType> CarSellerVehicleFuelTypeByVehicleID(int VehicleID)
         {
             return _carSellerVehicleFuelTypeRepository.Table.Where(v => v.VehicleID == VehicleID).ToList();
         }
    }
}
