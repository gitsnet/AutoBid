using AutoBid.Helper;
using AutoBid.Models.CarBuyer;
using Core.CarBuyer;
using Core.CarSeller;
using Service.AspUser;
using Service.CarBuyer;
using Service.CarSeller;
using Service.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Auction;
using Service.Auction;
using AutoBid.Models.Auction;

namespace AutoBid.Controllers.Buyer
{
    [Authorize]
    public class BuyerController : Controller
    {
        private readonly ICarBuyerInfoService _buyerService;
        private readonly ICarSellerVehicleInfoService _carsellervehicleinfoService;
        private readonly ICarSellerVehicleImagesService _carsellervehicleimageService;
        private readonly IAspNetUserService _aspNetUserService;
        private readonly ICarSellerInfoService _carsellerinfoService;
        private readonly ISellerPersonalInfoService _sellerPersonalInfoService;
        private readonly IAuctionHouseService _auctionHouseService;
        private readonly IAuctionHouseSaleService _auctionHouseSaleService;
        private readonly IAuctionHouseAddEditVehicleService _auctionHouseAddEditVehicleService;
        private readonly IAuctionHouseCarSellingVehicleImagesService _auctionHouseCarSellingVehicleImagesService;
        private readonly ICarSellerVehicleFuelTypeService _carSellerVehicleFuelTypeService;



        public BuyerController(ICarBuyerInfoService buyerService,
            ICarSellerVehicleInfoService carsellervehicleinfoService,
            ICarSellerVehicleImagesService carsellervehicleimageService, IAspNetUserService aspNetUserService, ICarSellerInfoService carsellerinfoService, ISellerPersonalInfoService sellerPersonalInfoService, IAuctionHouseService auctionHouseService, IAuctionHouseSaleService auctionHouseSaleService, IAuctionHouseAddEditVehicleService auctionHouseAddEditVehicleService, ICarSellerVehicleFuelTypeService carSellerVehicleFuelTypeService, IAuctionHouseCarSellingVehicleImagesService auctionHouseCarSellingVehicleImagesService)
        {
            _buyerService = buyerService;
            _carsellervehicleinfoService = carsellervehicleinfoService;
            _carsellervehicleimageService = carsellervehicleimageService;
            _aspNetUserService = aspNetUserService;
            _carsellerinfoService = carsellerinfoService;
            _sellerPersonalInfoService = sellerPersonalInfoService;
            _auctionHouseService = auctionHouseService;
            _auctionHouseSaleService = auctionHouseSaleService;
            _auctionHouseAddEditVehicleService = auctionHouseAddEditVehicleService;
            _carSellerVehicleFuelTypeService = carSellerVehicleFuelTypeService;
            _auctionHouseCarSellingVehicleImagesService = auctionHouseCarSellingVehicleImagesService;
        }
        //
        // GET: /Buyer/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VehiclesIBought()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            if (UserDetails != null)
            {
                long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                List<CarBuyerInfoModel> modelList = new List<CarBuyerInfoModel>();
                List<CarBuyerInfo> carbuyer = _buyerService.GetAllCarBuyerQueryable().Where<CarBuyerInfo>(u => u.IsBrought == true && u.UserID == id).ToList<CarBuyerInfo>();
                if (carbuyer != null)
                {
                    foreach (var item in carbuyer)
                    {
                        CarBuyerInfoModel model = new CarBuyerInfoModel();
                        model.Title = item.CarSellerVehicleInfo.Model.Modelname + " " + item.CarSellerVehicleInfo.Make.Makename + " " + item.CarSellerVehicleInfo.RegistrationNumber;
                        var image = _carsellervehicleimageService.GetCarSellerVehicleImageByVehicleID(item.CarSellerVehicleInfo.ID).FirstOrDefault().Filename;
                        if (image != null)
                            model.BuyerImage = "/Content/Assets/CarSellerImages/" + image;
                        else
                            model.BuyerImage = "/Content/images/noimage.jpg";
                        model.BuyDate = item.BuyDate.ToString("dd/MM/yyyy");
                        model.BuyingPrice = item.BuyingPrice.ToString();
                        modelList.Add(model);
                    }
                }
                return View(modelList);
            }
            else 
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult VehiclesIAmSelling()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            if (UserDetails != null)
            {
                long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                List<CarBuyerInfoModel> modelList = new List<CarBuyerInfoModel>();
                List<CarSellerInfo> CarSeller = _carsellerinfoService.GetAllCarSellerInfo().Where<CarSellerInfo>(s => s.UserID == id).ToList<CarSellerInfo>();
                if (CarSeller.Count > 0)
                {
                    foreach (var sell in CarSeller)
                    {
                        List<CarSellerVehicleInfo> carbuyer = _carsellervehicleinfoService.GetAllCarSellerVehicleInfo().Where<CarSellerVehicleInfo>(v => v.CarSellerInfoID == sell.ID).OrderByDescending(a => a.ID).ToList<CarSellerVehicleInfo>();
                        if (carbuyer != null)
                        {
                            foreach (var item in carbuyer)
                            {
                                CarBuyerInfoModel model = new CarBuyerInfoModel();
                                model.WayOfSellingID = Convert.ToInt32(sell.WayOfSelling);
                                model.WayOfSelling = sell.CarSellingOn.Way;
                                model.VehicleID = item.ID;
                                model.Title = item.Model.Modelname + " " + item.Make.Makename + " " + item.RegistrationNumber;
                                model.BuyerImages = _carsellervehicleimageService.GetCarSellerVehicleImageByVehicleID(item.ID);
                                var image = _carsellervehicleimageService.GetCarSellerVehicleImageByVehicleID(item.ID).FirstOrDefault();
                                if (image != null)
                                    model.BuyerImage = "/Content/Assets/CarSellerImages/" + image.Filename;
                                else
                                    model.BuyerImage = "/Content/images/noimage.jpg";
                                // model.BuyDate = item.a.ToString("dd/MM/yyyy");
                                model.BuyingPrice = item.Price.ToString();
                                model.IsSendToAuction = item.IsSendToAuction;
                                modelList.Add(model);
                            }
                        }
                    }
                    return View(modelList);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }
        public ActionResult VehiclesShortlisted()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            List<CarBuyerInfoModel> modelList = new List<CarBuyerInfoModel>();
            List<CarBuyerInfo> carbuyer = _buyerService.GetAllCarBuyerQueryable().Where<CarBuyerInfo>(u => u.IsShortlisted == true && u.UserID == id).ToList<CarBuyerInfo>();
            if (carbuyer != null)
            {
                foreach (var item in carbuyer)
                {
                    CarBuyerInfoModel model = new CarBuyerInfoModel();
                    model.Title = item.CarSellerVehicleInfo.Model.Modelname + " " + item.CarSellerVehicleInfo.Make.Makename + " " + item.CarSellerVehicleInfo.RegistrationNumber;
                    model.VehicleID = item.VehicleID;
                    model.EncodedVehicleID = CommonHelper.Base64Encode(item.VehicleID.ToString());
                    model.WayOfSelling = item.CarSellerVehicleInfo.CarSellerInfo.CarSellingOn.Way;
                    model.WayOfSellingID = Convert.ToInt32(item.CarSellerVehicleInfo.CarSellerInfo.WayOfSelling);

                    var image = _carsellervehicleimageService.GetCarSellerVehicleImageByVehicleID(item.CarSellerVehicleInfo.ID).FirstOrDefault().Filename;
                    if (image != null)
                        model.BuyerImage = "/Content/Assets/CarSellerImages/" + image;
                    else
                        model.BuyerImage = "/Content/images/noimage.jpg";
                    model.BuyDate = item.BuyDate.ToString("dd/MM/yyyy");
                    model.BuyingPrice = item.BuyingPrice.ToString();
                    modelList.Add(model);
                }
            }
            return View(modelList);
        }
        public ActionResult VehiclesOffersMade()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            List<CarBuyerInfoModel> modelList = new List<CarBuyerInfoModel>();
            List<CarBuyerInfo> carbuyer = _buyerService.GetAllCarBuyerQueryable().Where<CarBuyerInfo>(u => u.IsOfferMade == true && u.UserID == id).ToList<CarBuyerInfo>();
            if (carbuyer != null)
            {
                foreach (var item in carbuyer)
                {
                    CarBuyerInfoModel model = new CarBuyerInfoModel();
                    model.WayOfSellingID = Convert.ToInt32(item.CarSellerVehicleInfo.CarSellerInfo.WayOfSelling);
                    model.WayOfSelling = item.CarSellerVehicleInfo.CarSellerInfo.CarSellingOn.Way;
                    model.Title = item.CarSellerVehicleInfo.Model.Modelname + " " + item.CarSellerVehicleInfo.Make.Makename + " " + item.CarSellerVehicleInfo.RegistrationNumber;
                    var image = _carsellervehicleimageService.GetCarSellerVehicleImageByVehicleID(item.CarSellerVehicleInfo.ID).FirstOrDefault().Filename;
                    if (image != null)
                        model.BuyerImage = "/Content/Assets/CarSellerImages/" + image;
                    else
                        model.BuyerImage = "/Content/images/noimage.jpg";
                    model.BuyDate = item.BuyDate.ToString("d/M/yy");
                    model.BuyingPrice = item.BuyingPrice.ToString();
                    modelList.Add(model);
                }
            }
            return View(modelList);
        }
        public ActionResult BuyerAccount()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);

            if (UserDetails != null)
            {
                long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                int UserID = Convert.ToInt32(id);
                CarBuyerPersonalInfoModel obj = new CarBuyerPersonalInfoModel();
                var varCarBuyerPersonalInfo = _sellerPersonalInfoService.GetPersonalInformationByUserID(UserID);
                obj.Title = varCarBuyerPersonalInfo.Title??"";
                obj.ID = varCarBuyerPersonalInfo.ID;
                obj.UserID = Convert.ToInt32(varCarBuyerPersonalInfo.UserID);
                obj.FirstName = varCarBuyerPersonalInfo.FirstName;
                obj.LastName = varCarBuyerPersonalInfo.LastName;
                obj.Address = varCarBuyerPersonalInfo.Address;
                obj.ContactNo = varCarBuyerPersonalInfo.ContactNo;
                obj.Email = varCarBuyerPersonalInfo.Email;
                obj.PostalCode = varCarBuyerPersonalInfo.PostalCode;
                return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult SendToAuction()
        {
            List<AuctionHouse> aucHouseLi = _auctionHouseService.GetAllAuctionDetails().ToList();
            List<AuctionHouseModel> objlist = new List<AuctionHouseModel>();
            if (aucHouseLi.Count > 0)
            {
                foreach (var item in aucHouseLi)
                {
                    AuctionHouseModel model = new AuctionHouseModel();
                    model.AuctionHouseName = item.AuctionHouseName;
                    model.AuctionHouseID = item.AuctionHouseID;

                    objlist.Add(model);
                }
                return Json(objlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(objlist, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult FindAuctionSale(long id)
        {
            List<AuctionHouseSale> aucHouseSaleLi = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseID == id && t.SaleDate > DateTime.UtcNow).ToList();
            AuctionHouseModel obj = new AuctionHouseModel();

            List<AuctionHouseModelSaleDate> list = new List<AuctionHouseModelSaleDate>();
            if (aucHouseSaleLi.Count > 0)
            {
                obj.AuctionHouseSaleList = aucHouseSaleLi;
                if (aucHouseSaleLi != null)
                {
                    foreach (var item in obj.AuctionHouseSaleList)
                    {
                        AuctionHouseModelSaleDate objsale = new AuctionHouseModelSaleDate();
                        objsale.AuctionHouseSaleID = item.AuctionHouseSaleID;
                        objsale.SaleDate = Convert.ToDateTime(item.SaleDate).ToString("dd/MM/yyyy");
                        list.Add(objsale);
                    }
                }
                //obj.AuctionHouseSaleList = aucHouseSaleLi;
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(list, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult AddToAuction(AddToAuction addToAuction)
        {
            int _id = Convert.ToInt32(addToAuction.VehicleID);
            var varCarDetails = _carsellervehicleinfoService.GetCarSellerVehicleInfo().Where(t => t.ID == _id).FirstOrDefault();

            AuctionHouseCarSelling objAuctionHouseCarSelling = new AuctionHouseCarSelling();
            if (varCarDetails != null)
            {

                objAuctionHouseCarSelling.MakeID = varCarDetails.MakeID;
                objAuctionHouseCarSelling.ModelID = varCarDetails.ModelID;
                objAuctionHouseCarSelling.RegistrationNo = varCarDetails.RegistrationNumber;
                objAuctionHouseCarSelling.Reserve = varCarDetails.Price.ToString();
                objAuctionHouseCarSelling.AuctionHouseID = Convert.ToInt64(addToAuction.AuctionHouseID);
                objAuctionHouseCarSelling.AuctionHouseSaleID = Convert.ToInt64(addToAuction.AuctionHouseSaleID);
                objAuctionHouseCarSelling.VehicleID = varCarDetails.ID;
                objAuctionHouseCarSelling.BodyID = varCarDetails.BodyTypeID;
                objAuctionHouseCarSelling.EngineSize = varCarDetails.EngineSize;
                objAuctionHouseCarSelling.ExactMileage = varCarDetails.ExactMileage;
                objAuctionHouseCarSelling.ExteriorInteriorColour = varCarDetails.Color;
                objAuctionHouseCarSelling.TransmissionTypeIDs = varCarDetails.TransmissionTypeID.ToString();
                objAuctionHouseCarSelling.MOTExpiryDate = varCarDetails.MOTExpiryDate;
                objAuctionHouseCarSelling.TaxExpiryDate = varCarDetails.TAXExpiryDate;
                objAuctionHouseCarSelling.RegistrationDate = varCarDetails.DateOfFirstRegistration;
                objAuctionHouseCarSelling.LastServiceDetails = varCarDetails.ServiceHistory;

                var CarSellerFuelTypes = _carSellerVehicleFuelTypeService.CarSellerVehicleFuelTypeByVehicleID(varCarDetails.ID);

                string strFuelType = "";
                if (CarSellerFuelTypes.Count > 0)
                {
                    foreach (var item in CarSellerFuelTypes)
                    {
                        strFuelType += item.FuelTypeID.ToString()+",";
                    }
                    objAuctionHouseCarSelling.FuelTypeIDs = strFuelType.Trim(',');

                }

                var CarSellerImages = _carsellervehicleimageService.GetCarSellerVehicleImageByVehicleID(varCarDetails.ID).ToList();
                           

                _auctionHouseAddEditVehicleService.InsertAuctionHouseCarSelling(objAuctionHouseCarSelling);

                 CarBuyerInfoModel model = new CarBuyerInfoModel();
                    model.AuctionHouseCarSellingID = objAuctionHouseCarSelling.AuctionHouseCarSellingID;
                if (objAuctionHouseCarSelling.AuctionHouseCarSellingID > 0)
                {
                    if (CarSellerImages != null)
                    {
                        var aucHouseVehicleImage = _auctionHouseCarSellingVehicleImagesService.GetAuctionHouseCarSellingVehicleImages().Where(t => t.AuctionHouseCarSellingID == objAuctionHouseCarSelling.AuctionHouseCarSellingID).ToList();
                        foreach (var img in CarSellerImages)
                        {
                            
                            if (aucHouseVehicleImage.Count==0)
                            {
                                model.AuctionHouseCarSellingID = objAuctionHouseCarSelling.AuctionHouseCarSellingID;
                                model.Filename = img.Filename;
                                model.Foldername = img.Foldername;
                                model.Size = Convert.ToInt32(img.Size);

                                if (model.AuctionHouseCarSellingID != 0 && model.Filename!=null && model.Foldername!=null)
                                {
                                    AuctionHouseCarSellingVehicleImages objAuctionHouseCarSellingVehicleImage = new AuctionHouseCarSellingVehicleImages();

                                    objAuctionHouseCarSellingVehicleImage.AuctionHouseCarSellingID = model.AuctionHouseCarSellingID;
                                    objAuctionHouseCarSellingVehicleImage.Filename = model.Filename;
                                    objAuctionHouseCarSellingVehicleImage.Foldername = "~/Content/Assets/AuctionHouseSaleVehicleImages/";
                                    objAuctionHouseCarSellingVehicleImage.Size = model.Size;
                                    _auctionHouseCarSellingVehicleImagesService.InsertAuctionHouseCarSellingVehicleImage(objAuctionHouseCarSellingVehicleImage);
                                }
                                
                            }
                            
                        }
 
                    }
                   


                    CarSellerVehicleInfo objCarSellerVehicleInfo = new CarSellerVehicleInfo();

                    objCarSellerVehicleInfo.ID = varCarDetails.ID;
                    objCarSellerVehicleInfo.IsSendToAuction = true;
                    _carsellervehicleinfoService.UpdateCarSellerVehicleInfo(objCarSellerVehicleInfo);

                }

            }
            return Json(objAuctionHouseCarSelling, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteFromAuction(DeleteFromAuction deleteFromAuction)
        {
            AuctionHouseCarSelling varAuctionHouseCarSelling = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.AuctionHouseCarSellingID == deleteFromAuction.AuctionHouseCarSellingID).FirstOrDefault();

            AuctionHouseCarSelling obj = new AuctionHouseCarSelling();
            if (varAuctionHouseCarSelling != null)
            {
                obj.AuctionHouseCarSellingID = varAuctionHouseCarSelling.AuctionHouseCarSellingID;
                if (obj.AuctionHouseCarSellingID > 0)
                {
                  

                    var varAuctionHouseCarSellingVehicleImages = _auctionHouseCarSellingVehicleImagesService.GetAuctionHouseCarSellingVehicleImages().Where(t => t.AuctionHouseCarSellingID == varAuctionHouseCarSelling.AuctionHouseCarSellingID).ToList();

                    foreach (var item in varAuctionHouseCarSellingVehicleImages)
                    {
                        _auctionHouseCarSellingVehicleImagesService.DeleteAuctionHouseCarSellingVehicleImage(item);
                         
                    }
                    _auctionHouseAddEditVehicleService.DeleteAuctionHouseCarSelling(obj);


                    CarSellerVehicleInfo objCarSellerVehicleInfo = new CarSellerVehicleInfo();

                    objCarSellerVehicleInfo.ID = deleteFromAuction.VehicleID;
                    objCarSellerVehicleInfo.IsSendToAuction = false;
                    _carsellervehicleinfoService.UpdateCarSellerVehicleInfo(objCarSellerVehicleInfo);

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
        public ActionResult GetFromAuction(int id)
        {
            AuctionHouseCarSelling varAuctionHouseCarSelling = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.VehicleID == id).FirstOrDefault();

            CarBuyerInfoModel model = new CarBuyerInfoModel();
            if (varAuctionHouseCarSelling != null)
            {
                model.AuctionHouseCarSelling = varAuctionHouseCarSelling;
                model.AuctionHouseCarSelling.AuctionHouseCarSellingID = varAuctionHouseCarSelling.AuctionHouseCarSellingID;

                return Json(model.AuctionHouseCarSelling.AuctionHouseCarSellingID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(model.AuctionHouseCarSelling.AuctionHouseCarSellingID, JsonRequestBehavior.AllowGet);
            }

        }

    }
    public class AddToAuction
    {
        public int VehicleID { get; set; }
        public long AuctionHouseID { get; set; }
        public long AuctionHouseSaleID { get; set; }

    }
    public class DeleteFromAuction
    {
        public int VehicleID { get; set; }
        public long AuctionHouseCarSellingID { get; set; }


    }
}