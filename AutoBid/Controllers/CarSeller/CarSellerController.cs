using Service.Misc;
using Service.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoBid.Models.CarSeller;
using Core.CarSeller;
using Core.Misc;
using System.Globalization;
using System.IO;
using System.Text;
using Service.AspUser;

namespace AutoBid.Controllers.Seller
{
    [Authorize]
    public class CarSellerController : Controller
    {
        //
        // GET: /Seller/
        private readonly IAspNetUserService _aspNetUserService;
        private readonly ICarSellerTypeService _carSellerTypeService;
        private readonly ICarSellingOnService _carSellingOnService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly ICarModelService _carModelService;
        private readonly IMakeService _makeService;
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly ICarSellerVehicleInfoService _carSellerVehicleInfoService;
        private readonly ICarSellerMoreDetailService _carSellerMoreDetailService;
        private readonly ICarSellerVehicleImagesService _carSellerVehicleImagesService;
        private readonly ICarSellerInfoService _carSellerInfoService;
        private readonly ICarSellerVehicleFuelTypeService _carSellerVehicleFuelTypeService;
        private readonly IEngineSizeService _engineSizeService;

        public CarSellerController(
        IAspNetUserService aspNetUserService,
        IBodyTypeService bodyTypeService,
        ICarSellerTypeService carSellerTypeService,
        ICarSellingOnService carSellingOnService,
        ICarSellerInfoService carSellerInfoService,
        ICarModelService carModelService,
        IMakeService makeService,
        ITransmissionTypeService transmissionTypeService,
        IFuelTypeService fuelTypeService,
        ICarSellerVehicleInfoService carSellerVehicleInfoService,
        ICarSellerMoreDetailService carSellerMoreDetailService,
        ICarSellerVehicleImagesService carSellerVehicleImagesService,
            ICarSellerVehicleFuelTypeService carSellerVehicleFuelTypeService,
            IEngineSizeService engineSizeService
    )
        {
            _aspNetUserService = aspNetUserService;
            _carSellerTypeService = carSellerTypeService;
            _carSellingOnService = carSellingOnService;
            _bodyTypeService = bodyTypeService;
            _carModelService = carModelService;
            _makeService = makeService;
            _transmissionTypeService = transmissionTypeService;
            _fuelTypeService = fuelTypeService;
            _carSellerVehicleInfoService = carSellerVehicleInfoService;
            _carSellerMoreDetailService = carSellerMoreDetailService;
            _carSellerVehicleImagesService = carSellerVehicleImagesService;
            _carSellerInfoService = carSellerInfoService;
            _carSellerVehicleFuelTypeService = carSellerVehicleFuelTypeService;
            _engineSizeService = engineSizeService;
        }

        public ActionResult Index()
        {
            CarSellerMainModel model = new CarSellerMainModel();
            var carSellerTypeData = _carSellerTypeService.GetAllCarSellerType();
            var carSellingOnData = _carSellingOnService.GetAllCarSellinOn();

            if (carSellerTypeData != null)
            {
                int i = 0;
                foreach (var item in carSellerTypeData)
                {
                    if (i == 0)
                    {
                        model.CarSellerTypeList.Add(new SelectListItem
                        {
                            Value = item.ID.ToString(),
                            Text = item.Type,
                            Selected = true
                        });
                    }
                    else
                    {
                        model.CarSellerTypeList.Add(new SelectListItem
                        {
                            Value = item.ID.ToString(),
                            Text = item.Type,
                            Selected = false
                        });
                    }
                    i++;
                }
            }

            if (carSellingOnData != null)
            {
                int i = 0;
                foreach (var item in carSellingOnData)
                {

                    if (i == 0)
                    {
                        model.CarSellingOnList.Add(new SelectListItem
                        {
                            Value = item.ID.ToString(),
                            Text = item.Way,
                            Selected = true
                        });
                    }
                    else
                    {
                        model.CarSellingOnList.Add(new SelectListItem
                        {
                            Value = item.ID.ToString(),
                            Text = item.Way,
                            Selected = false
                        });
                    }
                    i++;
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CarSellerMainModel model)
        {

            TempData["regis"] = model.RegistrationNumber;
            TempData["milage"] = model.Milage;
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

            CarSellerInfo objCarSellerInfo = new CarSellerInfo();
            objCarSellerInfo.UserID = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            //objCarSellerInfo.SellerTypeID = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().SellerTypeID;
            objCarSellerInfo.SellerTypeID = Convert.ToInt32(model.CarSellerType);
            objCarSellerInfo.WayOfSelling = Convert.ToInt32(model.CarSellingOnType);

                _carSellerInfoService.InsertCarSellerInfo(objCarSellerInfo);
                if (objCarSellerInfo.ID > 0)
                {
                    Session["CarSellerInfoID"] = objCarSellerInfo.ID;
                    if (model.CarSellerType == "1")
                    {
                        

                        return RedirectToAction("PrivateSellerVehicleInfo", "CarSeller");
                    }
                    else
                    {
                        
                        return RedirectToAction("TradeSellerVehicleInfo", "CarSeller");
                    }
                    
                }
                else
                {
                   
                    return RedirectToAction("Index", "CarSeller");
                }
            
            
        }
        public ActionResult EditDetails(long Id)
        {
            var carSellerVehiclesDetails = _carSellerVehicleInfoService.GetCarSellerVehicleInfoByID(Id);
            if (carSellerVehiclesDetails.CarSellerInfo.SellerTypeID == 1)
            {
                return RedirectToAction("PrivateSellerVehicleInfo", "CarSeller", new { @id = Id });
            }
            else
            {
                return RedirectToAction("TradeSellerVehicleInfo", "CarSeller", new { @id = Id });
            }

        }

        //public ActionResult PrivateSellerVehicleInfo()
        //{
        //    CarSellerVehicleInfoModel model = new CarSellerVehicleInfoModel();
        //    if (TempData["regis"] != null)
        //        model.RegistrationNumber = TempData["regis"].ToString();
        //    if (TempData["milage"] != null)
        //        model.ExactMileage = TempData["milage"].ToString();

        //    var bodyTypeList = _bodyTypeService.GetAllBodyTypes();

        //    if (bodyTypeList != null)
        //    {
        //        foreach (var item in bodyTypeList)
        //        {
        //            model.BodyTypeList.Add(new BodyType
        //            {
        //                ID = item.ID,
        //                Type = item.Type
        //            });
        //        }
        //    }

        //    var makeList = _makeService.GetAllMakes();
        //    if (makeList != null)
        //    {
        //        foreach (var item in makeList)
        //        {
        //            model.MakeList.Add(new Make
        //            {
        //                ID = item.ID,
        //                Makename = item.Makename
        //            });
        //        }
        //    }

        //    var transmissionTypeList = _transmissionTypeService.GetAllTransmissionTypes();
        //    if (transmissionTypeList != null)
        //    {
        //        foreach (var item in transmissionTypeList)
        //        {
        //            model.TransmissionTypeList.Add(new TransmissionType
        //            {
        //                ID = item.ID,
        //                Type = item.Type
        //            });
        //        }
        //    }

        //    var fuelTypeList = _fuelTypeService.GetAllFuelTypes();
        //    if (fuelTypeList != null)
        //    {

        //        foreach (var item in fuelTypeList)
        //        {

        //            model.FuelTypeList.Add(new CheckBoxClass
        //            {
        //                ID = Convert.ToString(item.ID),
        //                Name = item.Type,
        //                IsChecked = false


        //            });



        //        }
        //    }

        //    return View(model);
        //}
        [HttpGet]
        public ActionResult PrivateSellerVehicleInfo(long Id = 0)
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;


            CarSellerVehicleInfoModel model = new CarSellerVehicleInfoModel();
            var MyCarList = _carSellerVehicleInfoService.GetAllCarSellerVehicleInfo().Where(vi => vi.CarSellerInfo.UserID == id).OrderByDescending(m => m.AddedDate).Take(2).ToList();
            model.CarSellerVehicleInfoList = MyCarList;
            if (Id != 0)
            {
                Session["VehicleID"] = Id;

                var carSellerVehiclesDetails = _carSellerVehicleInfoService.GetCarSellerVehicleInfoByID(Id);
                if (carSellerVehiclesDetails != null)
                {
                    Session["CarSellerInfoID"] = carSellerVehiclesDetails.CarSellerInfoID;
                    model.RegistrationNumber = carSellerVehiclesDetails.RegistrationNumber;
                    model.Title = carSellerVehiclesDetails.Title;
                    model.ExactMileage = carSellerVehiclesDetails.ExactMileage;
                    model.BodyTypeID = Convert.ToInt32(carSellerVehiclesDetails.BodyTypeID);
                    model.MakeID = Convert.ToInt32(carSellerVehiclesDetails.MakeID);
                    model.ModelID = Convert.ToInt32(carSellerVehiclesDetails.ModelID);
                    model.TransmissionTypeID = Convert.ToInt32(carSellerVehiclesDetails.TransmissionTypeID);
                    model.Color = carSellerVehiclesDetails.Color;
                    model.EngineSize = carSellerVehiclesDetails.EngineSize;
                    model.Price = carSellerVehiclesDetails.Price.ToString();
                    model.DateOfFirstRegistration = Convert.ToDateTime(carSellerVehiclesDetails.DateOfFirstRegistration).ToString("dd/MM/yyyy");
                    model.EngineSize = carSellerVehiclesDetails.EngineSize;
                    model.CarSellerVehicleImageList = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(Id);
                    var fuelTypeList = _fuelTypeService.GetAllFuelTypes();
                    if (fuelTypeList != null)
                    {


                        foreach (var item in fuelTypeList)
                        {

                            if (carSellerVehiclesDetails.CarSellerVehicleFuelTypes.Where(a => a.FuelTypeID == item.ID).Count() > 0)
                            {
                                model.FuelTypeList.Add(new CheckBoxClass
                                {
                                    ID = Convert.ToString(item.ID),
                                    Name = item.Type,
                                    IsChecked = true


                                });
                            }
                            else
                            {
                                model.FuelTypeList.Add(new CheckBoxClass
                                {
                                    ID = Convert.ToString(item.ID),
                                    Name = item.Type,
                                    IsChecked = false


                                });
                            }
                        }

                    }
                }
            }
            else
            {
                if (TempData["regis"] != null)
                    model.RegistrationNumber = TempData["regis"].ToString();
                if (TempData["milage"] != null)
                    model.ExactMileage = TempData["milage"].ToString();
                var fuelTypeList = _fuelTypeService.GetAllFuelTypes();
                if (fuelTypeList != null)
                {

                    foreach (var item in fuelTypeList)
                    {

                        model.FuelTypeList.Add(new CheckBoxClass
                        {
                            ID = Convert.ToString(item.ID),
                            Name = item.Type,
                            IsChecked = false


                        });



                    }
                }
            }
            var bodyTypeList = _bodyTypeService.GetAllBodyTypes();
            if (bodyTypeList != null)
            {
                foreach (var item in bodyTypeList)
                {
                    model.BodyTypeList.Add(new BodyType
                    {
                        ID = item.ID,
                        Type = item.Type
                    });
                }
            }

            var makeList = _makeService.GetAllMakes();

            if (makeList != null)
            {
                foreach (var item in makeList)
                {
                    model.MakeList.Add(new Make
                    {
                        ID = item.ID,
                        Makename = item.Makename
                    });
                }
            }




            var transmissionTypeList = _transmissionTypeService.GetAllTransmissionTypes();
            if (transmissionTypeList != null)
            {
                foreach (var item in transmissionTypeList)
                {
                    model.TransmissionTypeList.Add(new TransmissionType
                    {
                        ID = item.ID,
                        Type = item.Type
                    });
                }
            }


            return View(model);


        }


        public ActionResult TradeSellerVehicleInfo(long Id = 0)
        {
            try
            {
                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;


                CarSellerVehicleInfoModel model = new CarSellerVehicleInfoModel();
                var MyCarList = _carSellerVehicleInfoService.GetAllCarSellerVehicleInfo().Where(vi => vi.CarSellerInfo.UserID == id).Take(2).OrderByDescending(m => m.AddedDate).ToList();
                model.CarSellerVehicleInfoList = MyCarList;
                if (Id != 0)
                {
                    Session["VehicleID"] = Id;

                    var carSellerVehiclesDetails = _carSellerVehicleInfoService.GetCarSellerVehicleInfoByID(Id);
                    if (carSellerVehiclesDetails != null)
                    {
                        Session["CarSellerInfoID"] = carSellerVehiclesDetails.CarSellerInfoID;
                        model.RegistrationNumber = carSellerVehiclesDetails.RegistrationNumber;
                        model.Title = carSellerVehiclesDetails.Title;
                        model.ExactMileage = carSellerVehiclesDetails.ExactMileage;
                        model.BodyTypeID = Convert.ToInt32(carSellerVehiclesDetails.BodyTypeID);
                        model.MakeID = Convert.ToInt32(carSellerVehiclesDetails.MakeID);
                        model.ModelID = Convert.ToInt32(carSellerVehiclesDetails.ModelID);
                        model.TransmissionTypeID = Convert.ToInt32(carSellerVehiclesDetails.TransmissionTypeID);
                        model.Color = carSellerVehiclesDetails.Color;
                        model.EngineSize = carSellerVehiclesDetails.EngineSize;
                        model.Price = carSellerVehiclesDetails.Price.ToString();
                        model.DateOfFirstRegistration = Convert.ToDateTime(carSellerVehiclesDetails.DateOfFirstRegistration).ToString("dd/MM/yyyy");
                        model.CarSellerVehicleImageList = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(Id);
                        model.MOTExpiryDate = Convert.ToDateTime(carSellerVehiclesDetails.MOTExpiryDate).ToString("dd/MM/yyyy");
                        model.InteriorColor = carSellerVehiclesDetails.InteriorColor;
                        model.Trim = carSellerVehiclesDetails.Trim;
                        model.TAXExpiryDate = Convert.ToDateTime(carSellerVehiclesDetails.TAXExpiryDate).ToString("dd/MM/yyyy");
                        model.ServiceHistory = carSellerVehiclesDetails.ServiceHistory;
                        model.Description = carSellerVehiclesDetails.Description;
                        if (carSellerVehiclesDetails.CarSellerMoreDetails != null)
                        {
                            model.CarLocation = carSellerVehiclesDetails.CarSellerMoreDetails.FirstOrDefault().CarLocation;
                            model.ContactEmailID = carSellerVehiclesDetails.CarSellerMoreDetails.FirstOrDefault().ContactEmailID;
                            model.ContactNumberOnAdvert = carSellerVehiclesDetails.CarSellerMoreDetails.FirstOrDefault().ContactNumberOnAdvert;
                            model.ContactNumber = carSellerVehiclesDetails.CarSellerMoreDetails.FirstOrDefault().ContactNumber;


                        }
                        var fuelTypeList = _fuelTypeService.GetAllFuelTypes();
                        if (fuelTypeList != null)
                        {


                            foreach (var item in fuelTypeList)
                            {

                                if (carSellerVehiclesDetails.CarSellerVehicleFuelTypes.Where(a => a.FuelTypeID == item.ID).Count() > 0)
                                {
                                    model.FuelTypeList.Add(new CheckBoxClass
                                    {
                                        ID = Convert.ToString(item.ID),
                                        Name = item.Type,
                                        IsChecked = true


                                    });
                                }
                                else
                                {
                                    model.FuelTypeList.Add(new CheckBoxClass
                                    {
                                        ID = Convert.ToString(item.ID),
                                        Name = item.Type,
                                        IsChecked = false


                                    });
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (TempData["regis"] != null)
                        model.RegistrationNumber = TempData["regis"].ToString();
                    if (TempData["milage"] != null)
                        model.ExactMileage = TempData["milage"].ToString();
                    var fuelTypeList = _fuelTypeService.GetAllFuelTypes();
                    if (fuelTypeList != null)
                    {

                        foreach (var item in fuelTypeList)
                        {

                            model.FuelTypeList.Add(new CheckBoxClass
                            {
                                ID = Convert.ToString(item.ID),
                                Name = item.Type,
                                IsChecked = false


                            });



                        }
                    }
                }
                var bodyTypeList = _bodyTypeService.GetAllBodyTypes();
                if (bodyTypeList != null)
                {
                    foreach (var item in bodyTypeList)
                    {
                        model.BodyTypeList.Add(new BodyType
                        {
                            ID = item.ID,
                            Type = item.Type
                        });
                    }
                }

                var makeList = _makeService.GetAllMakes();
                if (makeList != null)
                {
                    foreach (var item in makeList)
                    {
                        model.MakeList.Add(new Make
                        {
                            ID = item.ID,
                            Makename = item.Makename
                        });
                    }
                }

                var transmissionTypeList = _transmissionTypeService.GetAllTransmissionTypes();
                if (transmissionTypeList != null)
                {
                    foreach (var item in transmissionTypeList)
                    {
                        model.TransmissionTypeList.Add(new TransmissionType
                        {
                            ID = item.ID,
                            Type = item.Type
                        });
                    }
                }


                return View(model);
            }
            catch (Exception ex)
            {
               return RedirectToAction("Index", "Home");
 
            }

            return RedirectToAction("Index", "Home");
        }
        //[HttpGet]
        //public ActionResult TradeSellerVehicleInfo()
        //{
        //    CarSellerVehicleInfoModel model = new CarSellerVehicleInfoModel();
        //    if (TempData["regis"] != null)
        //        model.RegistrationNumber = TempData["regis"].ToString();
        //    else
        //        RedirectToAction("Index", "CarSeller");
        //    if (TempData["milage"] != null)
        //        model.ExactMileage = TempData["milage"].ToString();
        //    else
        //        RedirectToAction("Index", "CarSeller");

        //    var bodyTypeList = _bodyTypeService.GetAllBodyTypes();
        //    if (bodyTypeList != null)
        //    {
        //        foreach (var item in bodyTypeList)
        //        {
        //            model.BodyTypeList.Add(new BodyType
        //            {
        //                ID = item.ID,
        //                Type = item.Type
        //            });
        //        }
        //    }

        //    var makeList = _makeService.GetAllMakes();
        //    if (makeList != null)
        //    {
        //        foreach (var item in makeList)
        //        {
        //            model.MakeList.Add(new Make
        //            {
        //                ID = item.ID,
        //                Makename = item.Makename
        //            });
        //        }
        //    }

        //    var transmissionTypeList = _transmissionTypeService.GetAllTransmissionTypes();
        //    if (transmissionTypeList != null)
        //    {
        //        foreach (var item in transmissionTypeList)
        //        {
        //            model.TransmissionTypeList.Add(new TransmissionType
        //            {
        //                ID = item.ID,
        //                Type = item.Type
        //            });
        //        }
        //    }

        //    var fuelTypeList = _fuelTypeService.GetAllFuelTypes();
        //    if (fuelTypeList != null)
        //    {
        //        foreach (var item in fuelTypeList)
        //        {
        //            model.FuelTypeList.Add(new CheckBoxClass
        //            {
        //                ID = item.ID.ToString(),
        //                Name = item.Type,
        //                IsChecked = false
        //            });
        //        }
        //    }



        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult TradeSellerVehicleInfo(CarSellerMainModel model)
        //{
        //    var a = model.RegistrationNumber;
        //    return View();
        //}

        [HttpPost]
        public ActionResult GetModels(long makeID)
        {
            List<CarSellerVehicleInfoModel> list = new List<CarSellerVehicleInfoModel>();
            var carModelList = _carModelService.GetAllCarModels().Where<CarModel>(cm => cm.MakeID == makeID).ToList<CarModel>();
            if (carModelList != null)
            {

                foreach (CarModel item in carModelList)
                {
                    CarSellerVehicleInfoModel model = new CarSellerVehicleInfoModel();
                    model.ModelID = item.ID;
                    model.ModelName = item.Modelname;

                    list.Add(model);

                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CarSellingRegistration(CarSellerVehicleInfoModel model)
        {

            if (Session["CarSellerInfoID"] != null)
            {
                int newMakeID = 0;
                int newCarModelID = 0;

                var getMakeDetails = _makeService.GetMakeByName(model.NewCarMakeName);
                if (getMakeDetails == null)
                {
                    Make objMake = new Make();
                    objMake.Makename = model.NewCarMakeName;
                    objMake.IsRemoved = false;
                    _makeService.InsertMake(objMake);
                    if (objMake.ID > 0)
                        newMakeID = objMake.ID;
                }
                else
                {
                    newMakeID = getMakeDetails.ID;
                }

                var getModelDetails = _carModelService.GetCarModelByName(model.NewCarModelName);
                if (getModelDetails == null)
                {
                    CarModel objCarModel = new CarModel();
                    objCarModel.Modelname = model.NewCarModelName;
                    objCarModel.MakeID = newMakeID;
                    _carModelService.InsertCarModel(objCarModel);
                    if (objCarModel.ID > 0)
                        newCarModelID = objCarModel.ID;
                }
                else
                {
                    newCarModelID = getModelDetails.ID;
                }


                if (Session["VehicleID"] == null)
                {
                    CarSellerVehicleInfo obj = new CarSellerVehicleInfo();
                    obj.CarSellerInfoID = Convert.ToInt32(Session["CarSellerInfoID"]);
                    obj.RegistrationNumber = model.RegistrationNumber;
                    obj.Title = model.Title;
                    obj.MakeID = newMakeID;
                    obj.ModelID = newCarModelID;
                    obj.BodyTypeID = model.BodyTypeID;
                    obj.Color = model.Color;
                    obj.EngineSize = model.EngineSize;
                    if (!string.IsNullOrEmpty(model.MOTExpiryDate))
                        obj.MOTExpiryDate = DateTime.ParseExact(model.MOTExpiryDate, "dd/MM/yyyy", null);
                    obj.TransmissionTypeID = model.TransmissionTypeID;
                    obj.ExactMileage = model.ExactMileage;
                    obj.InteriorColor = model.InteriorColor;
                    obj.Trim = model.Trim;
                    if (!string.IsNullOrEmpty(model.TAXExpiryDate))
                        obj.TAXExpiryDate = DateTime.ParseExact(model.TAXExpiryDate, "dd/MM/yyyy", null);
                    obj.ServiceHistory = model.ServiceHistory;
                    obj.Description = model.Description;
                    if (!string.IsNullOrEmpty(model.DateOfFirstRegistration))
                        obj.DateOfFirstRegistration = DateTime.ParseExact(model.DateOfFirstRegistration, "dd/MM/yyyy", null);
                    obj.AddedDate = DateTime.Now;
                    _carSellerVehicleInfoService.InsertCarSellerVehicleInfo(obj);
                    Session["VehicleID"] = obj.ID;
                    model.ID = Convert.ToInt32(Session["VehicleID"]);

                    //model.ID = obj.ID;
                }
                else
                {

                    CarSellerVehicleInfo objCarSellerVehicleInfo = _carSellerVehicleInfoService.GetCarSellerVehicleInfoByID(Convert.ToInt32(Session["VehicleID"]));
                    if (objCarSellerVehicleInfo != null)
                    {
                        objCarSellerVehicleInfo.CarSellerInfoID = Convert.ToInt32(Session["CarSellerInfoID"]);
                        objCarSellerVehicleInfo.RegistrationNumber = model.RegistrationNumber;
                        objCarSellerVehicleInfo.Title = model.Title;
                        objCarSellerVehicleInfo.MakeID = newMakeID;
                        objCarSellerVehicleInfo.ModelID = newCarModelID;
                        objCarSellerVehicleInfo.BodyTypeID = model.BodyTypeID;
                        objCarSellerVehicleInfo.Color = model.Color;
                        objCarSellerVehicleInfo.EngineSize = model.EngineSize;
                        if (!string.IsNullOrEmpty(model.MOTExpiryDate))
                            objCarSellerVehicleInfo.MOTExpiryDate = DateTime.ParseExact(model.MOTExpiryDate, "dd/MM/yyyy", null);
                        objCarSellerVehicleInfo.TransmissionTypeID = model.TransmissionTypeID;
                        objCarSellerVehicleInfo.ExactMileage = model.ExactMileage;
                        objCarSellerVehicleInfo.InteriorColor = model.InteriorColor;
                        objCarSellerVehicleInfo.Trim = model.Trim;
                        if (!string.IsNullOrEmpty(model.TAXExpiryDate))
                            objCarSellerVehicleInfo.TAXExpiryDate = DateTime.ParseExact(model.TAXExpiryDate, "dd/MM/yyyy", null);
                        objCarSellerVehicleInfo.ServiceHistory = model.ServiceHistory;
                        objCarSellerVehicleInfo.Description = model.Description;
                        if (!string.IsNullOrEmpty(model.DateOfFirstRegistration))
                            objCarSellerVehicleInfo.DateOfFirstRegistration = DateTime.ParseExact(model.DateOfFirstRegistration, "dd/MM/yyyy", null);
                        _carSellerVehicleInfoService.UpdateCarSellerVehicleInfo(objCarSellerVehicleInfo);

                        model.ID = Convert.ToInt32(Session["VehicleID"]);

                        //model.ID = objCarSellerVehicleInfo.ID;

                        List<CarSellerVehicleFuelType> carSellerVehicleFuelType = _carSellerVehicleFuelTypeService.CarSellerVehicleFuelTypeByVehicleID(Convert.ToInt32(Session["VehicleID"]));
                        _carSellerVehicleFuelTypeService.DeleteCarSellerVehicleFuelType(carSellerVehicleFuelType);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }


                }
                if (Convert.ToInt32(Session["VehicleID"]) > 0)
                {
                    foreach (var item in model.FuelTypeList)
                    {
                        if (item.IsChecked)
                        {
                            CarSellerVehicleFuelType objCarSellerVehicleFuelType = new CarSellerVehicleFuelType();
                            objCarSellerVehicleFuelType.VehicleID = Convert.ToInt32(Session["VehicleID"]);
                            objCarSellerVehicleFuelType.FuelTypeID = Convert.ToInt32(item.ID);
                            _carSellerVehicleFuelTypeService.InsertCarSellerVehicleFuelType(objCarSellerVehicleFuelType);

                        }
                    }
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else

                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CarSellingRegistrationDetails(CarSellerVehicleInfoModel model)
        {

            if (Session["VehicleID"] != null)
            {
                long ID = Convert.ToInt64(Session["VehicleID"]);
                if (ID > 0)
                {
                    var carSellerVehicleInfoDetails = _carSellerVehicleInfoService.GetCarSellerVehicleInfoByID(ID);
                    if (carSellerVehicleInfoDetails != null)
                    {


                        decimal? price = (decimal)Decimal.Parse(model.Price.Replace("£", "").Replace(",", ""), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                        carSellerVehicleInfoDetails.Price = price;
                        _carSellerVehicleInfoService.UpdateCarSellerVehicleInfo(carSellerVehicleInfoDetails);
                        int? carSellerType = _carSellerInfoService.GetCarSellerInfoByCarSellerInfoID(carSellerVehicleInfoDetails.CarSellerInfoID).SellerTypeID;
                        if (carSellerType != null)
                        {
                            if (carSellerType != 1)
                            {
                                CarSellerMoreDetail objCarSellerMoreDetail = new CarSellerMoreDetail();
                                objCarSellerMoreDetail.VehicleID = Convert.ToInt32(ID);


                                var CarSellerMoreDetails = _carSellerMoreDetailService.GetCarSellerMoreDetailByVehicleID(ID);
                                if (CarSellerMoreDetails != null)
                                {

                                    CarSellerMoreDetails.CarLocation = model.CarLocation;
                                    CarSellerMoreDetails.ContactEmailID = model.ContactEmailID;
                                    CarSellerMoreDetails.ContactNumber = model.ContactNumber;
                                    CarSellerMoreDetails.ContactNumberOnAdvert = model.ContactNumberOnAdvert;
                                    CarSellerMoreDetails.SelectedPackageID = 1;
                                    _carSellerMoreDetailService.UpdateCarSellerMoreDetail(CarSellerMoreDetails);
                                }
                                else
                                {
                                    objCarSellerMoreDetail.CarLocation = model.CarLocation;
                                    objCarSellerMoreDetail.ContactEmailID = model.ContactEmailID;
                                    objCarSellerMoreDetail.ContactNumber = model.ContactNumber;
                                    objCarSellerMoreDetail.ContactNumberOnAdvert = model.ContactNumberOnAdvert;
                                    objCarSellerMoreDetail.SelectedPackageID = 1;
                                    _carSellerMoreDetailService.InsertCarSellerMoreDetail(objCarSellerMoreDetail);
                                }
                                if (objCarSellerMoreDetail.ID > 0)
                                {
                                    return Json(true, JsonRequestBehavior.AllowGet);
                                }
                                else
                                    return Json(false, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                //Session["VehicleID"] = null;
                                return Json(true, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }

                    }
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult UploadVehicleImage(string ctrlID)
        {
            if (Session["VehicleID"] != null)
            {
                int ID = Convert.ToInt32(Session["VehicleID"]);
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);
                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhssfff") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/CarSellerImages/"), fName);
                        Idfile.SaveAs(path);
                        CarSellerVehicleImage model = new CarSellerVehicleImage();
                        model.VehicleID = ID;
                        model.OriginalFilename = "";
                        model.Filename = fName;
                        model.Size = 0;
                        model.Foldername = "~/Content/Assets/CarSellerImages/";
                        model.SectionFromImageUploaded = "Sell";
                        _carSellerVehicleImagesService.InsertCarSellerVehicleImage(model);

                        return Json(fName, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult RemoveVehicleImage(string VehicleImage)
        {
            bool flag = false;
            if (Session["VehicleID"] != null)
            {
                int ID = Convert.ToInt32(Session["VehicleID"]);
                string[] image = VehicleImage.Split('/');
                var Lastindex = image.Last();
                var getcarImageDetails = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(Convert.ToInt64(ID)).Where(t => t.Filename == Lastindex).FirstOrDefault();
                if (getcarImageDetails != null)
                {

                    if (ID > 0)
                    {
                        var path = Server.MapPath(VehicleImage);
                        FileInfo info1 = new FileInfo(path);
                        if (info1.Exists)
                        {
                            info1.Delete();
                            _carSellerVehicleImagesService.DeleteCarSellerVehicleImage(getcarImageDetails);
                            flag = true;
                        }


                    }

                }

            }

            return Json(flag, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SaveImages(List<object> arr)
        {
            //if (Session["VehicleID"] != null)
            //{
            //    int ID = Convert.ToInt32(Session["VehicleID"]);

            //    if (ID > 0)
            //    {
            //        var getcarImageDetails = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(Convert.ToInt64(ID));
            //        if (getcarImageDetails != null)
            //        {
            //            foreach (CarSellerVehicleImage item in getcarImageDetails)
            //            {
            //                var path = Server.MapPath("~/Content/Assets/CarSellerImages/" + item.Filename);
            //                FileInfo info1 = new FileInfo(path);
            //                if (info1.Exists)
            //                {
            //                    info1.Delete();

            //                }
            //                _carSellerVehicleImagesService.DeleteCarSellerVehicleImage(item);

            //            }
            //        }
            //        if (arr.Count > 0)
            //        {
            //            for (int i = 0; i < arr.Count; i++)
            //            {
            //                //CarSellerVehicleImage model = new CarSellerVehicleImage();
            //                //model.VehicleID = ID;
            //                //model.OriginalFilename = "";
            //                //model.Filename = arr[i].ToString();
            //                //model.Size = 0;
            //                //model.Foldername = "~/Content/Assets/CarSellerImages/";
            //                //model.SectionFromImageUploaded = "Sell";
            //                //_carSellerVehicleImagesService.InsertCarSellerVehicleImage(model);
            //            }
            //            return Json(true, JsonRequestBehavior.AllowGet);
            //        }
            //        else
            //        {
            //            return Json(false, JsonRequestBehavior.AllowGet);
            //        }

            //    }
            //    else
            //    {
            //        return Json(false, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //else
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadPreview()
        {
            if (Session["VehicleID"] != null)
            {
                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

                int ID = Convert.ToInt32(Session["VehicleID"]);
                StringBuilder sbSingleImage = new StringBuilder();
                StringBuilder sbMultiImage = new StringBuilder();
                string Header = "";
                string AllimageDetails = "";
                string resultHTML = "";
                string main = @"<div class='col-md-12'>
                            <div class='row singlecarpg'>
                                
                                <div class='col-md-10'>
                                    <h2>{0}</h2>
                                </div>
                            </div>
                            <div class='row mb20'>
                                <div class='alert alert-info'><strong>Tips:</strong> Make sure you've entered a good price</div>
                                <div class='col-md-5'><button class='btn btn-primary' type='button' onclick='EditPhotos();'>Edit Photos</button></div>
                                <div class='col-md-7'><button class='btn btn-primary' type='button' onclick='EditAdvert();'>EditAdvert</button></div>
                            </div>
                            <div class='row'>
                                {1}
                            </div>
                        </div>";

                if (ID > 0)
                {
                    IList<CarSellerVehicleImage> VehicleImageDetails = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(ID);
                    if (VehicleImageDetails != null)
                    {
                        int count = 1;
                        string MainImage = "";
                        string multiImage = "";
                        sbSingleImage.Append("<div class='col-md-5'><div class='singlecar_galleryimg'>");
                        sbSingleImage.Append("<img width='320' height='240' src='/Content/Assets/CarSellerImages/{0}'>");
                        sbSingleImage.Append("<div class='singlecar_galleryimg_container'></div><div class='singlecar_galleryimg_header'><h3>Front View</h3></div>");
                        sbSingleImage.Append("</div>");
                        sbSingleImage.Append("{1}");
                        sbMultiImage.Append("<ul class='list-inline singlecar_gallery'>{0}</ul></div>");
                        foreach (CarSellerVehicleImage imgDetails in VehicleImageDetails)
                        {
                            if (count == 1)
                            {
                                MainImage = imgDetails.Filename.ToString();
                            }
                            else
                            {
                                multiImage += "<li class='active'><img width='78' height='59' src='/Content/Assets/CarSellerImages/" + imgDetails.Filename.ToString() + "'></li>";
                            }
                            count++;
                        }
                        string imageDetails = string.Format(sbMultiImage.ToString(), multiImage);
                        AllimageDetails = string.Format(sbSingleImage.ToString(), MainImage, imageDetails);
                    }
                    CarSellerVehicleInfo CarSellerVehicleInfoDetails = _carSellerVehicleInfoService.GetCarSellerVehicleInfoByID(Convert.ToInt64(ID));
                    if (CarSellerVehicleInfoDetails != null)
                    {
                        Header = CarSellerVehicleInfoDetails.Title;
                        string strFuelTypes = "";
                        var fuelTypesList = CarSellerVehicleInfoDetails.CarSellerVehicleFuelTypes.ToList<CarSellerVehicleFuelType>();
                        if (fuelTypesList != null)
                        {
                            foreach (CarSellerVehicleFuelType fuelType in fuelTypesList)
                            {
                                strFuelTypes += fuelType.FuelType.Type + ",";
                            }
                        }
                        else
                            strFuelTypes = "-";
                        string mainHTML = @"<div class='col-md-7'>
                                       <table width='100%' cellspacing='0' cellpadding='0' border='0' class='table table-bordered table-striped'>
                                        <tbody>
                                            <tr>
                                                <th>Lot Number</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>Registration</th>
                                                <td><span class='regno'>{0}</span></td>
                                            </tr>
                                            <tr>
                                                <th>Sale</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>Vendor</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>Make</th>
                                                <td>{1}</td>
                                            </tr>
                                            <tr>
                                                <th>Model</th>
                                                <td>{2}</td>
                                            </tr>
                                            <tr>
                                                <th>Colour</th>
                                                <td>{3}</td>
                                            </tr>
                                            <tr>
                                                <th>Description</th>
                                                <td>{4}</td>
                                            </tr>
                                            <tr>
                                                <th>Doors</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>Fuel Type</th>
                                                <td>{5}</td>
                                            </tr>
                                            <tr>
                                                <th>Transmission</th>
                                                <td>{6}</td>
                                            </tr>
                                            <tr>
                                                <th>Milleage</th>
                                                <td>{7}</td>
                                            </tr>
                                            <tr>
                                                <th>Former Keepers</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>Taxed To</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>MOT To</th>
                                                <td>{8}</td>
                                            </tr>
                                            <tr>
                                                <th>Service History</th>
                                                <td>{9}</td>
                                            </tr>
                                            <tr>
                                                <th>Remarks</th>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <th>Other Details</th>
                                                <td><button class='btn btn-success' type='button'>V5</button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>";
                        resultHTML = string.Format(mainHTML,
                            CarSellerVehicleInfoDetails.RegistrationNumber,
                            CarSellerVehicleInfoDetails.Make.Makename,
                            CarSellerVehicleInfoDetails.Model.Modelname,
                            CarSellerVehicleInfoDetails.Color,
                            CarSellerVehicleInfoDetails.Description,
                            strFuelTypes.Trim(','),
                            CarSellerVehicleInfoDetails.TransmissionType.Type,
                            CarSellerVehicleInfoDetails.ExactMileage,
                           Convert.ToDateTime(CarSellerVehicleInfoDetails.MOTExpiryDate).ToString("dd/MM/yyyy"),
                            CarSellerVehicleInfoDetails.ServiceHistory,
                            UserName
                            );
                    }
                }

                string previewHTML = string.Format(main, Header, AllimageDetails + resultHTML);
                return Json(previewHTML, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult GetVehicleImage(string VehicleID)
        {
            if (Session["VehicleID"] != null)
            {
                int ID = Convert.ToInt32(Session["VehicleID"]);
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);
                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/CarSellerImages/"), fName);
                        Idfile.SaveAs(path);
                        CarSellerVehicleImage model = new CarSellerVehicleImage();
                        model.VehicleID = ID;
                        model.OriginalFilename = "";
                        model.Filename = fName;
                        model.Size = 0;
                        model.Foldername = "~/Content/Assets/CarSellerImages/";
                        model.SectionFromImageUploaded = "Sell";
                        IList<CarSellerVehicleImage> vehicleImages = _carSellerVehicleImagesService.GetCarSellerVehicleImageByVehicleID(ID);

                        return Json(vehicleImages, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Finish()
        {
            if (Session["VehicleID"] != null)
            {
                Session["VehicleID"] = null;
                Session["CarSellerInfoID"] = null;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
                //return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult FinishPrivateSession()
        {

            if (Session["VehicleID"] != null)
            {
                Session["VehicleID"] = null;
                Session["CarSellerInfoID"] = null;
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return RedirectToAction("Index", "Home");
                //return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


    }
}