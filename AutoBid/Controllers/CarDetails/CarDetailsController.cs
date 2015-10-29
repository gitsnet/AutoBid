using Service.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBid.Models.CarDetails;
using Core.CarSeller;
using AutoBid.Helper;
using Core.Auction;
using Service.Auction;
using Service.Misc;
using Core.Misc;


namespace AutoBid.Controllers.CarDetails
{

    public class CarDetailsController : Controller
    {
        //
        // GET: /CarDetails/
        private readonly ICarSellerVehicleInfoService _carsellervehicleinfoService;
        private readonly ICarSellerVehicleImagesService _carSellerVehicleImagesService;
        private readonly ICarSellerVehicleFuelTypeService _carSellerVehicleFuelTypeService;
        private readonly IAuctionHouseAddEditVehicleService _auctionHouseAddEditVehicleService;
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly IFuelTypeService _fuelTypeService;
         private readonly IMakeService _makeService;
         private readonly ICarModelService _carModelService;
         private readonly IAuctionHouseCarSellingVehicleImagesService _auctionHouseCarSellingVehicleImagesService;

        public CarDetailsController
            (ICarSellerVehicleInfoService carsellervehicleinfoService, 
            ICarSellerVehicleImagesService carSellerVehicleImagesService, 
            ICarSellerVehicleFuelTypeService carSellerVehicleFuelTypeService, 
            IAuctionHouseAddEditVehicleService auctionHouseAddEditVehicleService,
            ITransmissionTypeService transmissionTypeService,
            IFuelTypeService fuelTypeService,
            IMakeService makeService,
            ICarModelService carModelService,
            IAuctionHouseCarSellingVehicleImagesService auctionHouseCarSellingVehicleImagesService
            )
        {
            _carsellervehicleinfoService = carsellervehicleinfoService;
            _carSellerVehicleImagesService = carSellerVehicleImagesService;
            _carSellerVehicleFuelTypeService = carSellerVehicleFuelTypeService;
            _auctionHouseAddEditVehicleService = auctionHouseAddEditVehicleService;
            _transmissionTypeService=transmissionTypeService;
            _fuelTypeService=fuelTypeService;
            _makeService = makeService;
            _carModelService = carModelService;
            _auctionHouseCarSellingVehicleImagesService = auctionHouseCarSellingVehicleImagesService;

        }

        //[Route("CarDetails/Index/{type}/{id}")]
        public ActionResult Index(string type,string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                   
                    //string IDS = Convert.ToString(CommonHelper.Base64Decode(id) ?? "");
                    //int Id = Convert.ToInt32(id);
                    
                    CarDetailsModel carDetailsModel = new CarDetailsModel();

                    if (type.ToLower() == "carseller")
                    {
                        int Id = Convert.ToInt32(CommonHelper.Base64Decode(id) ?? "");

                        CarSellerVehicleInfo carVehicleDetail = _carsellervehicleinfoService.GetCarSellerVehicleInfoByID(Id);
                        if (carVehicleDetail != null)
                        {
                           
                            carDetailsModel.Price = carVehicleDetail.Price != null ? Convert.ToDecimal(carVehicleDetail.Price) : 0;
                            carDetailsModel.Description = carVehicleDetail.Description ?? "";
                            carDetailsModel.ExactMileage = carVehicleDetail.ExactMileage ?? "";
                            if (carVehicleDetail.CarSellerMoreDetails.Count > 0)
                            {
                                carDetailsModel.ContactNumber = carVehicleDetail.CarSellerMoreDetails.FirstOrDefault().ContactNumber ?? "";
                                carDetailsModel.Email = carVehicleDetail.CarSellerMoreDetails.FirstOrDefault().ContactEmailID;
                            }
                            carDetailsModel.TransmissionType = carVehicleDetail.TransmissionType.Type ?? "";
                            carDetailsModel.MakeName = carVehicleDetail.Make.Makename ?? "";
                            carDetailsModel.ModelName = carVehicleDetail.Model.Modelname ?? "";
                            carDetailsModel.RegistrationNo = carVehicleDetail.RegistrationNumber ?? "";

                            List<CarSellerVehicleFuelType> carSellerVehicleFuelTypes = _carSellerVehicleFuelTypeService.CarSellerVehicleFuelTypeByVehicleID(Convert.ToInt16(Id));
                            foreach (var item in carSellerVehicleFuelTypes)
                            {
                                carDetailsModel.FuelType += item.FuelType.Type + " ,";
                            }
                            carDetailsModel.FuelType = carDetailsModel.FuelType.Remove(carDetailsModel.FuelType.Length - 1);
                            var img = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(Id).ToList();
                            if (img != null)
                                carDetailsModel.CarImages = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(Id).ToList();
                            else
                                carDetailsModel.CarImages = null;

                            carDetailsModel.carType = type;

                           
                        }
                    }
                    else
                    {
                        long ID = Convert.ToInt64(id);
                        AuctionHouseCarSelling aucVehicleDetail = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSellingByID(ID);
                        string[] tranType = aucVehicleDetail.TransmissionTypeIDs.Split(',');
                        string trans = "";
                        foreach (var item in tranType)
                        {
                            int i = Convert.ToInt32(item);

                            TransmissionType tran1 = _transmissionTypeService.GeTransmissionTypeQueryable().Where(t => t.ID ==i).FirstOrDefault();
                            trans += tran1.Type + ",";
                        }

                        string[] fuelType = aucVehicleDetail.FuelTypeIDs.Split(',');
                        string fuels = "";
                        foreach (var item in fuelType)
                        {
                            int i = Convert.ToInt32(item);

                            FuelType fuel1 = _fuelTypeService.GeFuelTypeQueryable().Where(t => t.ID == i).FirstOrDefault();
                            fuels += fuel1.Type + ",";
                        }

                        string make = aucVehicleDetail.Make.Makename;
                        string model = aucVehicleDetail.Model.Modelname;


                        if (aucVehicleDetail != null)
                        {
                            
                            carDetailsModel.Price = aucVehicleDetail.Reserve != null ? Convert.ToDecimal(aucVehicleDetail.Reserve) : 0;
                            carDetailsModel.Description = aucVehicleDetail.VCARDetails ?? "";
                            carDetailsModel.ExactMileage = aucVehicleDetail.ExactMileage ?? "";
                           
                            carDetailsModel.TransmissionType = trans.Trim(',') ?? "";
                            carDetailsModel.fuelType = fuels.Trim(',') ?? "";
                            carDetailsModel.MakeName = make ?? "";
                            carDetailsModel.ModelName = model ?? "";
                            carDetailsModel.RegistrationNo = aucVehicleDetail.RegistrationNo ?? "";

                           
                            var aucImg = _auctionHouseCarSellingVehicleImagesService.GetAuctionHouseCarSellingVehicleImages().Where(t=>t.AuctionHouseCarSellingID==ID).ToList();
                            if (aucImg != null)
                                carDetailsModel.AucCarImages =aucImg.ToList(); 
                               
                            else
                                carDetailsModel.AucCarImages = null;

                            carDetailsModel.carType = type;

                           
                        }
                    }
                    return View(carDetailsModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("VehiclesShortlisted", "Buyer");
               
            }

        }

      
    }
}