using AutoBid.Models.Home;
using Service.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBid.Helper;
using AutoBid.Models.CarSeller;
using Service.Misc;
using Core.Misc;
using AutoBid.Models.CarDetails;
using AutoBid.Models.Misc;
using Core.CarSeller;
using Service.Auction;
using Core.Auction;
using System.Collections;

namespace AutoBid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarSellerVehicleInfoService _carSellerVehicleInfoService;
        private readonly ICarSellerVehicleImagesService _carSellerVehicleImagesService;
        private readonly ICarSellerVehicleFuelTypeService _carSellerVehicleFuelTypeService;
        private readonly ICarModelService _carModelService;
        private readonly IMakeService _makeService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly ITransmissionTypeService _transmissionTyeService;
        private readonly ICarSellerTypeService _carSellerTyeService;
        private readonly ICarSellingOnService _carSellingOnService;
        private readonly ICarSellerMoreDetailService _carSellerMoreDetailService;
        private readonly IAuctionHouseAddEditVehicleService _auctionHouseAddEditVehicleService;
        private readonly IAuctionHouseSaleService _auctionHouseSaleService;

        public HomeController(
            ICarSellerVehicleInfoService carSellerVehicleInfoService,
             ICarSellerVehicleImagesService carSellerVehicleImagesService, ICarModelService carModelService, IMakeService makeService, ICarSellerVehicleFuelTypeService carSellerVehicleFuelTypeService, IBodyTypeService bodyTypeService, IFuelTypeService fuelTypeService, ITransmissionTypeService transmissionTyeService, ICarSellerTypeService carSellerTyeService, ICarSellingOnService carSellingOnService, ICarSellerMoreDetailService carSellerMoreDetailService,
             IAuctionHouseAddEditVehicleService auctionHouseAddEditVehicleService,
            IAuctionHouseSaleService auctionHouseSaleService)
        {
            _carSellerVehicleInfoService = carSellerVehicleInfoService;
            _carSellerVehicleImagesService = carSellerVehicleImagesService;
            _carSellerVehicleFuelTypeService = carSellerVehicleFuelTypeService;
            _carModelService = carModelService;
            _makeService = makeService;
            _bodyTypeService = bodyTypeService;
            _fuelTypeService = fuelTypeService;
            _transmissionTyeService = transmissionTyeService;
            _carSellerTyeService = carSellerTyeService;
            _carSellingOnService = carSellingOnService;
            _carSellerMoreDetailService = carSellerMoreDetailService;
            _auctionHouseAddEditVehicleService = auctionHouseAddEditVehicleService;
            _auctionHouseSaleService = auctionHouseSaleService;

        }
        public ActionResult Index()
        {
            IndexHomeModel objIndexHomeModel = new IndexHomeModel();
            List<HomeModel> modelList = new List<HomeModel>();
            var carSellerVehicleInfoList = _carSellerVehicleInfoService.GetAllCarSellerVehicleInfo().Where(m => m.Price != null && m.CarSellerVehicleImages.Count > 0).OrderByDescending(m => m.ID).Take(10);
            if (carSellerVehicleInfoList != null)
            {
                foreach (var item in carSellerVehicleInfoList)
                {
                    HomeModel obj = new HomeModel();
                    obj.VehicleMake = item.Make.Makename;
                    obj.VehicleModel = item.Model.Modelname;
                    obj.Price = item.Price.ToString();
                    obj.VehicleImage = "/Content/Assets/CarSellerImages/" + item.CarSellerVehicleImages.FirstOrDefault().Filename;
                    obj.ID = item.CarSellerVehicleImages.FirstOrDefault().VehicleID.ToString();
                    obj.EncodedVehicleID = CommonHelper.Base64Encode(obj.ID);

                    modelList.Add(obj);

                }
            }
            objIndexHomeModel.HomeModelList = modelList;
          
            DateTime dt=DateTime.UtcNow.Date;

            List<AuctionHouseCarSelling> AuctionHouseCarSellingList = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.AuctionHouseSale.SaleDate == dt).OrderByDescending(t=>t.AuctionHouseCarSellingID).Take(2).ToList();

         
            if (AuctionHouseCarSellingList.Count > 0)
            {
                objIndexHomeModel.AuctionHouseCarSellingList = AuctionHouseCarSellingList;
            }
            return View(objIndexHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetMake(string query)
        {
            List<MakeModel> makeModelList = new List<MakeModel>();

            var makeList = _makeService.GetMakesQueryable().Where(t=>t.Makename.Contains(query));
            if (makeList != null)
            {
                foreach (var item in makeList)
                {
                    MakeModel model = new MakeModel();
                    model.ID = item.ID;
                    model.Makename = item.Makename;
                    makeModelList.Add(model);
                }
            }
            return Json(makeModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetModels(long ID)
        {
            List<CarViewModel> carViewModelList = new List<CarViewModel>();
            var carModelList = _carModelService.GetAllCarModels().Where<CarModel>(cm => cm.MakeID == ID).ToList<CarModel>();
            foreach (var item in carModelList)
            {
                CarViewModel model = new CarViewModel();
                model.ID = item.ID;
                model.Modelname = item.Modelname;
                carViewModelList.Add(model);
            }

            return Json(carViewModelList, JsonRequestBehavior.AllowGet);

        }
      
        //public ActionResult Search()
        //{
        //    IndexHomeModel objIndexHomeModel = new IndexHomeModel();
        //    List<CarDetailsModel> carDetailsModelList = new List<CarDetailsModel>();
        //    List<MakeModel> makeModelList = new List<MakeModel>();
        //    List<CarModel> carModelList = new List<CarModel>();
        //    List<CarViewModel> carViewModelList = new List<CarViewModel>();

        //    List<BodyType> bodyTypeList = new List<BodyType>();
        //    List<CarSellerType> carSellerTypeList = new List<CarSellerType>();
        //    List<TransmissionType> transmissionTypeList = new List<TransmissionType>();
        //    List<FuelType> fuelTypeList = new List<FuelType>();
        //    List<CarSellingOn> carSellingOnList = new List<CarSellingOn>();
        //    var makelist = _makeService.GetAllMakes();
        //    if (makelist != null)
        //    {

        //        foreach (var item1 in makelist)
        //        {
        //            MakeModel obj = new MakeModel();
        //            obj.ID = item1.ID;
        //            obj.Makename = item1.Makename;
        //            makeModelList.Add(obj);

        //        }

        //    }

        //    //var carModelList = _carModelService.GetAllCarModels().Where<CarModel>(cm => cm.Makename == model.MakeName).ToList<CarModel>();
        //    //foreach (var item in carModelList)
        //    //{
        //    //    CarViewModel carViewmodel = new CarViewModel();
        //    //    carViewmodel.ID = item.ID;
        //    //    carViewmodel.Modelname = item.Modelname;
        //    //    carViewModelList.Add(carViewmodel);
        //    //}

        //    var varBodyTypeList = _bodyTypeService.GetAllBodyTypes();
        //    if (varBodyTypeList != null)
        //    {
        //        foreach (var item in varBodyTypeList)
        //        {
        //            BodyType obj = new BodyType();
        //            obj.ID = item.ID;
        //            obj.Type = item.Type;
        //            bodyTypeList.Add(obj);

        //        }
        //    }

        //    var varCarSellerTypeList = _carSellerTyeService.GetAllCarSellerType();
        //    if (varCarSellerTypeList != null)
        //    {
        //        foreach (var item in varCarSellerTypeList)
        //        {
        //            CarSellerType obj = new CarSellerType();
        //            obj.ID = item.ID;
        //            obj.Type = item.Type;
        //            carSellerTypeList.Add(obj);

        //        }
        //    }

        //    var varTransmissionTypeList = _transmissionTyeService.GetAllTransmissionTypes();
        //    if (varTransmissionTypeList != null)
        //    {
        //        foreach (var item in varTransmissionTypeList)
        //        {
        //            TransmissionType obj = new TransmissionType();
        //            obj.ID = item.ID;
        //            obj.Type = item.Type;
        //            transmissionTypeList.Add(obj);

        //        }
        //    }

        //    var varFuelTypeList = _fuelTypeService.GetAllFuelTypes();
        //    if (varFuelTypeList != null)
        //    {
        //        foreach (var item in varFuelTypeList)
        //        {
        //            FuelType obj = new FuelType();
        //            obj.ID = item.ID;
        //            obj.Type = item.Type;
        //            fuelTypeList.Add(obj);

        //        }
        //    }


        //    var varcarSellingOnList = _carSellingOnService.GetAllCarSellinOn();
        //    if (varcarSellingOnList != null)
        //    {
        //        foreach (var item in varcarSellingOnList)
        //        {
        //            CarSellingOn obj = new CarSellingOn();
        //            obj.ID = item.ID;
        //            obj.Way = item.Way;
        //            carSellingOnList.Add(obj);

        //        }
        //    }


        //    var carModelList1 = _carModelService.GetAllCarModels();
        //    if (carModelList1 != null)
        //    {
        //        foreach (var item in carModelList1)
        //        {
        //            CarModel obj = new CarModel();
        //            obj.ID = item.ID;
        //            obj.Modelname = item.Modelname;
        //            obj.MakeID = item.MakeID;
        //            carModelList.Add(obj);

        //        }
        //    }




        //    objIndexHomeModel.CarDetailsList = carDetailsModelList;
        //    objIndexHomeModel.MakeModelList = makeModelList;
        //    objIndexHomeModel.bodyTypeList = bodyTypeList;
        //    objIndexHomeModel.CarSellerTypeList = carSellerTypeList;
        //    objIndexHomeModel.transmissionTypeList = transmissionTypeList;
        //    objIndexHomeModel.fuelTypeList = fuelTypeList;
        //    objIndexHomeModel.CarSellingOnList = carSellingOnList;
        //    objIndexHomeModel.ModelList = carModelList;


        //    return View(objIndexHomeModel);
        //}
        [HttpGet]
        public ActionResult Search(IndexHomeModel model)
        {
            IndexHomeModel objIndexHomeModel = new IndexHomeModel();
            try
            {
                List<CarSellerVehicleInfo> searchList = null;
                decimal minPrice = Convert.ToDecimal(model.minPrice);
                decimal maxPrice = Convert.ToDecimal(model.maxPrice);

              
                List<CarDetailsModel> carDetailsModelList = new List<CarDetailsModel>();                
                
                List<Make> makeModelList = new List<Make>();
                List<CarModel> carModelList = new List<CarModel>();
                List<BodyType> bodyTypeList = new List<BodyType>();
                List<CarSellerType> carSellerTypeList = new List<CarSellerType>();
                List<TransmissionType> transmissionTypeList = new List<TransmissionType>();
                List<FuelType> fuelTypeList = new List<FuelType>();
                List<CarSellingOn> carSellingOnList = new List<CarSellingOn>();


                //CarDetailsSearchModel obj = new CarDetailsSearchModel();
                //obj.BodyTypeName = model.MakeName;
                //list.Add(obj);
                //list.Add(model.MakeName);
                //list.Add(model.ModelName);
                //list.Add(model.CarSellerTypeName);
                //list.Add(model.BodyTypeName);
                //list.Add(model.TransmissionName);
                //list.Add(model.FuelTypeName);
                //list.Add(model.SearchText);

                List<String> list = new List<String>();
                list.Add(model.MakeName);
                list.Add(model.ModelName);
                list.Add(model.CarSellerTypeName);
                list.Add(model.BodyTypeName);
                list.Add(model.TransmissionName);
                list.Add(model.FuelTypeName);
                list.Add(model.SearchText);



                //ArrayList list = new ArrayList();
                //list.Add(model.MakeName);
                //list.Add(model.ModelName);
                //list.Add(model.CarSellerTypeName);
                //list.Add(model.BodyTypeName);
                //list.Add(model.TransmissionName);
                //list.Add(model.FuelTypeName);



                searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(p => list.Any(p2 => p2.Contains(p.Make.Makename) && p2.Contains(p.Model.Modelname) && p2.Contains(p.BodyType.Type) && p2.Contains(p.TransmissionType.Type) && p2.Contains(p.Price.ToString()))).ToList();

                //searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(p => !list.Contains(p.Make.Makename) && !list.Contains(p.Model.Modelname) && !list.Contains(p.BodyType.ToString()) && !list.Contains(p.TransmissionType.ToString()) && !list.Contains(p.FuelType.ToString()) && !list.Contains(p.Price.ToString())).ToList();

                //searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(p => !list.Contains(p.Make.Makename) && !list.Contains(p.Model.Modelname) && !list.Contains(p.BodyType.ToString()) && !list.Contains(p.TransmissionType.ToString()) && !list.Contains(p.FuelType.ToString()) && !list.Contains(p.Price.ToString())).ToList();

                
                //if (!(string.IsNullOrEmpty(model.MakeName)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName)).ToList();

                //}

                //if (!(string.IsNullOrEmpty(model.ModelName)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Model.Modelname.Contains(model.ModelName)).ToList();

                //}

                ////if (!(string.IsNullOrEmpty(model.CarSellerTypeName)))
                ////{
                ////    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.CarSellerType.Type.Contains(model.CarSellerTypeName) || u.CarSellerType.Type.Contains(model.SearchText)).ToList();

                ////}

                //if (!(string.IsNullOrEmpty(model.BodyTypeName)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.BodyType.Type.Contains(model.BodyTypeName)).ToList();

                //}

                //if (!(string.IsNullOrEmpty(model.TransmissionName)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.TransmissionType.Type.Contains(model.TransmissionName)).ToList();

                //}

                //if (!(string.IsNullOrEmpty(model.FuelTypeName)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.CarSellerVehicleFuelTypes.Any(c => c.FuelType.Type == model.FuelTypeName)).ToList();

                //}

                //if (!(string.IsNullOrEmpty(model.minPrice)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Price >= minPrice).ToList();

                //}

                //if (!(string.IsNullOrEmpty(model.maxPrice)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Price <= maxPrice).ToList();

                //}





                //if (!(string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.ModelName)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && u.Model.Modelname.Contains(model.ModelName)).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.maxPrice)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && (u.Price <= maxPrice)).ToList();
                //}

                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.minPrice)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && (u.Price >= minPrice)).ToList();
                //}

                //if ((!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.maxPrice)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Model.Modelname.Contains(model.ModelName)).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.minPrice)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Model.Modelname.Contains(model.ModelName) && (u.Price >= minPrice)).ToList();
                //}

                //if ((!string.IsNullOrEmpty(model.maxPrice)) && (!string.IsNullOrEmpty(model.minPrice)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Price >= minPrice && u.Price <= maxPrice).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.minPrice)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && u.Model.Modelname.Contains(model.ModelName) && (u.Price >= minPrice)).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.maxPrice)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && u.Model.Modelname.Contains(model.ModelName) && (u.Price <= maxPrice)).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.maxPrice)) && (!string.IsNullOrEmpty(model.minPrice)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && (u.Price <= maxPrice) && (u.Price >= minPrice)).ToList();
                //}

                //if ((!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.maxPrice)) && (!string.IsNullOrEmpty(model.minPrice)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Model.Modelname.Contains(model.ModelName) && (u.Price <= maxPrice) && (u.Price >= minPrice)).ToList();

                //}
                //if ((!string.IsNullOrEmpty(model.maxPrice)) && (!string.IsNullOrEmpty(model.minPrice)) && (!string.IsNullOrEmpty(model.MakeName)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && (u.Price <= maxPrice) && (u.Price >= minPrice)).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.maxPrice)) && (!string.IsNullOrEmpty(model.minPrice)) && (!string.IsNullOrEmpty(model.ModelName)))
                //{
                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Model.Modelname.Contains(model.ModelName) && (u.Price <= maxPrice) && (u.Price >= minPrice)).ToList();

                //}

                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.minPrice)) && (!string.IsNullOrEmpty(model.maxPrice)) && (!string.IsNullOrEmpty(model.TransmissionName)) && (!string.IsNullOrEmpty(model.BodyTypeName)))
                //{


                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && u.Model.Modelname.Contains(model.ModelName) && (u.Price >= minPrice && u.Price <= maxPrice)  && u.TransmissionType.Type.Contains(model.TransmissionName) && u.BodyType.Type.Contains(model.BodyTypeName) || u.Make.Makename.Contains(model.SearchText) || u.Model.Modelname.Contains(model.SearchText) || u.TransmissionType.Type.Contains(model.SearchText) || u.BodyType.Type.Contains(model.SearchText)).ToList();

                //}


                //if ((!string.IsNullOrEmpty(model.MakeName)) && (!string.IsNullOrEmpty(model.ModelName)) && (!string.IsNullOrEmpty(model.TransmissionName)) && (!string.IsNullOrEmpty(model.BodyTypeName)) && (!string.IsNullOrEmpty(model.FuelTypeName)))
                //{


                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.MakeName) && u.Model.Modelname.Contains(model.ModelName) && u.TransmissionType.Type.Contains(model.TransmissionName) && u.BodyType.Type.Contains(model.BodyTypeName) && u.CarSellerVehicleFuelTypes.Any(c=>c.FuelType.Type == model.FuelTypeName) || (u.Make.Makename.Contains(model.SearchText) || u.Model.Modelname.Contains(model.SearchText) || u.TransmissionType.Type.Contains(model.SearchText) || u.BodyType.Type.Contains(model.SearchText) || u.CarSellerVehicleFuelTypes.Any(c => c.FuelType.Type == model.FuelTypeName)) ).ToList();

                //}




                //if ((string.IsNullOrEmpty(model.MakeName)) && (string.IsNullOrEmpty(model.ModelName)) && (string.IsNullOrEmpty(model.minPrice)) && (string.IsNullOrEmpty(model.maxPrice)))
                //{

                //    searchList = _carSellerVehicleInfoService.GetAllCarSellerVehicleInfo().ToList();

                //}

                //if ((string.IsNullOrEmpty(model.MakeName)) && (string.IsNullOrEmpty(model.ModelName)) && (string.IsNullOrEmpty(model.TransmissionName)) && (string.IsNullOrEmpty(model.BodyTypeName)) && (string.IsNullOrEmpty(model.FuelTypeName)) && (!string.IsNullOrEmpty(model.SearchText)))
                //{


                //    searchList = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(u => u.Make.Makename.Contains(model.SearchText) || u.Model.Modelname.Contains(model.SearchText) || u.TransmissionType.Type.Contains(model.SearchText) || u.BodyType.Type.Contains(model.SearchText) || u.CarSellerVehicleFuelTypes.Any(c => c.FuelType.Type == model.FuelTypeName)).ToList();

                //}

                //if ((string.IsNullOrEmpty(model.MakeName)) && (string.IsNullOrEmpty(model.ModelName)) && (string.IsNullOrEmpty(model.TransmissionName)) && (string.IsNullOrEmpty(model.BodyTypeName)) && (string.IsNullOrEmpty(model.FuelTypeName)) && (string.IsNullOrEmpty(model.SearchText)))
                //{


                //    searchList = _carSellerVehicleInfoService.GetAllCarSellerVehicleInfo().ToList();

                //}

                if (searchList != null)
                {

                    foreach (var item in searchList)
                    {
                        if ((item.Title != null) && (item.Price != null || item.Price != 0) && (item.RegistrationNumber != null) && (item.ExactMileage != null))
                        {
                            //var moreinfo = _carSellerMoreDetailService.GetCarSellerMoreDetailByVehicleID(item.ID);
                            //if (moreinfo != null)
                            //{
                                CarDetailsModel carDetails = new CarDetailsModel();

                                carDetails.Title = item.Title;
                                carDetails.MakeName = item.Make.Makename;
                                carDetails.ModelName = item.Model.Modelname;
                                carDetails.Price = Convert.ToDecimal(item.Price);
                                carDetails.RegistrationNo = item.RegistrationNumber;
                                carDetails.ExactMileage = item.ExactMileage;
                                carDetails.TransmissionType = item.TransmissionType.Type;
                                //carDetails.ContactNumber = item.CarSellerMoreDetails.FirstOrDefault().ContactNumber ?? "";
                                //carDetails.Email = item.CarSellerMoreDetails.FirstOrDefault().ContactEmailID ?? "";

                                List<CarSellerVehicleImage> imginfo = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(item.ID).ToList();
                                carDetails.CarImages = imginfo;

                            //    carDetails.CarImages = item.CarSellerVehicleImages.ToList();
                                string fuels = "";
                                foreach (var fuelType in item.CarSellerVehicleFuelTypes)
                                {
                                    fuels += fuelType.FuelType.Type + ",";
                                }
                                carDetails.fuelType = fuels.Trim(',');
                                carDetails.Description = item.Description;
                                carDetailsModelList.Add(carDetails);
                            //}

                        }
                    }
                }
                else
                {

                }
                var makelist = _makeService.GetAllMakes();
                if (makelist != null)
                {

                    foreach (var item1 in makelist)
                    {
                        Make obj = new Make();
                        obj.ID = item1.ID;
                        obj.Makename = item1.Makename;
                        makeModelList.Add(obj);

                    }

                }

               
                var varBodyTypeList = _bodyTypeService.GetAllBodyTypes();
                if (varBodyTypeList != null)
                {
                    foreach (var item in varBodyTypeList)
                    {
                        BodyType obj = new BodyType();
                        obj.ID = item.ID;
                        obj.Type = item.Type;
                        bodyTypeList.Add(obj);

                    }
                }

                var varCarSellerTypeList = _carSellerTyeService.GetAllCarSellerType();
                if (varCarSellerTypeList != null)
                {
                    foreach (var item in varCarSellerTypeList)
                    {
                        CarSellerType obj = new CarSellerType();
                        obj.ID = item.ID;
                        obj.Type = item.Type;
                        carSellerTypeList.Add(obj);

                    }
                }

                var varTransmissionTypeList = _transmissionTyeService.GetAllTransmissionTypes();
                if (varTransmissionTypeList != null)
                {
                    foreach (var item in varTransmissionTypeList)
                    {
                        TransmissionType obj = new TransmissionType();
                        obj.ID = item.ID;
                        obj.Type = item.Type;
                        transmissionTypeList.Add(obj);

                    }
                }

                var varFuelTypeList = _fuelTypeService.GetAllFuelTypes();
                if (varFuelTypeList != null)
                {
                    foreach (var item in varFuelTypeList)
                    {
                        FuelType obj = new FuelType();
                        obj.ID = item.ID;
                        obj.Type = item.Type;
                        fuelTypeList.Add(obj);

                    }
                }


                var varcarSellingOnList = _carSellingOnService.GetAllCarSellinOn();
                if (varcarSellingOnList != null)
                {
                    foreach (var item in varcarSellingOnList)
                    {
                        CarSellingOn obj = new CarSellingOn();
                        obj.ID = item.ID;
                        obj.Way = item.Way;
                        carSellingOnList.Add(obj);

                    }
                }


                var carModelList1 = _carModelService.GetAllCarModels();
                if (carModelList1 != null)
                {
                    foreach (var item in carModelList1)
                    {
                        CarModel obj = new CarModel();
                        obj.ID = item.ID;
                        obj.Modelname = item.Modelname;
                        obj.MakeID = item.MakeID;
                        carModelList.Add(obj);

                    }
                }


              

                objIndexHomeModel.CarDetailsList = carDetailsModelList;
                objIndexHomeModel.MakeList = makeModelList;
                objIndexHomeModel.bodyTypeList = bodyTypeList;
                objIndexHomeModel.CarSellerTypeList = carSellerTypeList;
                objIndexHomeModel.transmissionTypeList = transmissionTypeList;
                objIndexHomeModel.fuelTypeList = fuelTypeList;
                objIndexHomeModel.CarSellingOnList = carSellingOnList;
                objIndexHomeModel.ModelList = carModelList;


            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(objIndexHomeModel);

        }

      
        [HttpPost]
        public ActionResult GetModelsSearch(long makeID)
        {
            List<CarViewModel> list = new List<CarViewModel>();
            var carModelList = _carModelService.GetAllCarModels().Where<CarModel>(cm => cm.MakeID == makeID).ToList<CarModel>();
            if (carModelList != null)
            {

                foreach (CarModel item in carModelList)
                {
                    CarViewModel model = new CarViewModel();
                    model.ID = item.ID;
                    model.Modelname = item.Modelname;

                    list.Add(model);

                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetMakeName(string  name)
        {
            string makeUpper = name.ToUpper();
            var varMake = _makeService.GetMakesQueryable().Where(t => t.Makename == makeUpper).FirstOrDefault();
            if (varMake != null)
            {
                int makeID = varMake.ID;
                return Json(makeID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult GetVehicleDetails(int id)
        {
            List<CarSellerVehicleInfo> varCarVehicleDetails = _carSellerVehicleInfoService.GetCarSellerVehicleInfo().Where(t => t.MakeID == id).ToList();
            
            return Json(varCarVehicleDetails, JsonRequestBehavior.AllowGet);


        }
    }
   
}