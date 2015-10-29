using Core.CarSeller;
using System.Collections.Generic;

namespace Service.CarSeller
{
    public partial interface ICarSellerVehicleImagesService
    {
        #region:CarSellerVehicleImagesService
        IList<CarSellerVehicleImage> GetAllCarSellerVehicleImage();
        CarSellerVehicleImage GetCarSellerVehicleImageByID(long id);
        IList<CarSellerVehicleImage> GetCarSellerVehicleImageByVehicleID(long VehicleID);
        void InsertCarSellerVehicleImage(CarSellerVehicleImage carSellerVehicleImage);
        void UpdateCarSellerVehicleImage(CarSellerVehicleImage carSellerVehicleImage);
        void DeleteCarSellerVehicleImage(CarSellerVehicleImage carsellervehicleimage);
        #endregion
    }
}
