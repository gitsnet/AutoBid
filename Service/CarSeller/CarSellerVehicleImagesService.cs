using System;
using System.Collections.Generic;
using System.Linq;
using Core.CarSeller;
using Core.Data;

namespace Service.CarSeller
{
    public partial class CarSellerVehicleImagesService:ICarSellerVehicleImagesService
    {
        private readonly IRepository<CarSellerVehicleImage> _carSellerVehicleImageRepository;
        #region:Constructor

        public CarSellerVehicleImagesService(IRepository<CarSellerVehicleImage> carSellerVehicleImageRepository)
        {
            _carSellerVehicleImageRepository = carSellerVehicleImageRepository;
        }
        #endregion

        #region:Methods
        public IList<CarSellerVehicleImage> GetAllCarSellerVehicleImage()
        {
            return _carSellerVehicleImageRepository.Table.ToList<CarSellerVehicleImage>();
        }
        public void InsertCarSellerVehicleImage(CarSellerVehicleImage carSellerVehicleImage)
        {
            if (carSellerVehicleImage == null)
                throw new ArgumentNullException("CarSellerVehicleImage");
            _carSellerVehicleImageRepository.Insert(carSellerVehicleImage);
        }
        public CarSellerVehicleImage GetCarSellerVehicleImageByID(long id)
        {
            return _carSellerVehicleImageRepository.Table.Where<CarSellerVehicleImage>(v => v.ID == id).FirstOrDefault<CarSellerVehicleImage>();
        }

        public IList<CarSellerVehicleImage> GetCarSellerVehicleImageByVehicleID(long VehicleID)
        {
            return _carSellerVehicleImageRepository.Table.Where<CarSellerVehicleImage>(v => v.VehicleID == VehicleID).ToList<CarSellerVehicleImage>();
        }
        public void UpdateCarSellerVehicleImage(CarSellerVehicleImage carSellerVehicleImage)
        {
            if (carSellerVehicleImage == null)
                throw new ArgumentNullException("CarSellerVehicleImage");
            _carSellerVehicleImageRepository.Update(carSellerVehicleImage);
        }
        public void DeleteCarSellerVehicleImage(CarSellerVehicleImage carsellervehicleimage)
        {
            if (carsellervehicleimage == null)
                throw new ArgumentException("CarSellerVehicleImage");
            _carSellerVehicleImageRepository.Delete(carsellervehicleimage);
        }
        #endregion

       
    }
}
