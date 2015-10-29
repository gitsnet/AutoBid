using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Auction;
using Core.Auction;
using AutoBid.Models.Auction;
//using AutoBid.Models.AuctionHouse;
using AutoBid.Helper;
using PagedList;
using System.IO;
using Microsoft.AspNet.Identity;
using Service.AspUser;
using AutoBid.Models;
using System.Threading.Tasks;
using Core.User;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Service.Misc;
using System.Globalization;
namespace AutoBid.Controllers.Auction
{

    public class AuctionHouseController : Controller
    {
        private readonly IAuctionHouseService _auctionHouseService;
        private readonly IAspNetUsersAdditionalInfoService _aspNetUsersAdditionalInfoService;
        private readonly IAspNetUserRolesService _aspNetUserRoleService;
        private readonly IAspNetUserService _aspNetUserService;
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public IAuctionHouseSaleService _auctionHouseSaleService { get; set; }
        public IAuctionHouseAddEditVehicleService _auctionHouseAddEditVehicleService { get; set; }
        private static IMakeService _makeService;
        private static ICarModelService _carModelService;

        public AuctionHouseController(IAuctionHouseService auctionHouseService,
            IAspNetUsersAdditionalInfoService aspNetUsersAdditionalInfoService,
           UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager,
             IMakeService makeService,
             ICarModelService carModelService,
            IAspNetUserRolesService aspNetUserRoleService, IAspNetUserService aspNetUserService,
            IAuctionHouseSaleService auctionHouseSaleService,
            IAuctionHouseAddEditVehicleService auctionHouseAddEditVehicleService
            )
        {
            UserManager = userManager;
            RoleManager = roleManager;
            _auctionHouseService = auctionHouseService;
            _aspNetUsersAdditionalInfoService = aspNetUsersAdditionalInfoService;
            _aspNetUserRoleService = aspNetUserRoleService;
            _aspNetUserService = aspNetUserService;
            _auctionHouseSaleService = auctionHouseSaleService;
            _makeService = makeService;
            _carModelService = carModelService;
            _auctionHouseAddEditVehicleService = auctionHouseAddEditVehicleService;

        }



        public ActionResult InsertAuctionHouseDetails(AuctionHouseModel model)
        {
            //List<AuctionHouseModel> auctionHouseModelList = new List<AuctionHouseModel>();
            //var auctionHouseList = _auctionHouseService.GetAllAuctionDetails().ToList<AuctionHouse>();
            //if (auctionHouseList != null)
            //{
            //    foreach (var item in auctionHouseList)
            //    {
            //        AuctionHouseModel obj = new AuctionHouseModel();
            //        obj.AuctionHouseName = item.AuctionHouseName;
            //        obj.Logo = item.Logo;
            //        obj.WebSite = item.WebSite;
            //        obj.ContactNo = item.ContactNo;
            //        obj.Email = item.Email;
            //        obj.About = item.About;
            //        obj.TermsCondition = item.TermsCondition;
            //        auctionHouseModelList.Add(obj);
            //    }
            //}
            //return View(auctionHouseModelList);
            return View();
        }

        public ActionResult Index(AuctionHouseModel auctionHouseDetails)
        {
            //AuctionHouseModel model = new AuctionHouseModel();

            //model.AuctionHouseName = auctionHouseDetails.AuctionHouseName;
            //model.AuctionHouseID = auctionHouseDetails.AuctionHouseID;
            //model.Address = auctionHouseDetails.Address;
            //model.PostalCode = auctionHouseDetails.PostalCode;
            //return Json(true, JsonRequestBehavior.AllowGet);
            return View();
        }
        //public ActionResult LiveAuction()
        //{

        //    return (View);
        //}

        [HttpPost]
        public ActionResult InsertAuctionHouse(AuctionHouse auctionHouseDetails)
        {
            AjaxReturnModel objMsg = new AjaxReturnModel();
            try
            {
                AuctionHouseModel model = new AuctionHouseModel();
                if (Session["AuctionHouseID"] == null)
                {

                    model.AuctionHouseName = auctionHouseDetails.AuctionHouseName;
                    model.Logo = auctionHouseDetails.Logo;
                    model.Address = auctionHouseDetails.Address;
                    model.PostalCode = auctionHouseDetails.PostalCode;
                    model.Buyer_Fees = auctionHouseDetails.Buyer_Fees;
                    model.About = auctionHouseDetails.About;

                    _auctionHouseService.InsertAuctionHouseDetails(auctionHouseDetails);
                    if (auctionHouseDetails.AuctionHouseID > 0)
                    {
                        objMsg.msg = "Success";
                        objMsg.type = true;
                        Session["AuctionHouseID"] = auctionHouseDetails.AuctionHouseID;
                        long aucid = Convert.ToInt64(Session["AuctionHouseID"]);
                        return Json(auctionHouseDetails, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objMsg.msg = "Fail";
                        objMsg.type = false;
                        return Json(objMsg, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    AuctionHouse aucNext = _auctionHouseService.GetAuctionByAuctionID(Convert.ToInt64(Session["AuctionHouseID"]));
                    if (aucNext.AuctionHouseID > 0)
                    {
                        aucNext.About = auctionHouseDetails.About;
                        aucNext.Buyer_Fees = auctionHouseDetails.Buyer_Fees;
                        aucNext.Logo = auctionHouseDetails.Logo;
                        aucNext.AuctionHouseName = auctionHouseDetails.AuctionHouseName;
                        aucNext.PostalCode = auctionHouseDetails.PostalCode;
                        aucNext.Address = auctionHouseDetails.Address;
                        _auctionHouseService.UpdateAuctionHouseDetails(aucNext);

                        objMsg.msg = "sucessfully updated";
                        objMsg.type = true;
                        return Json(auctionHouseDetails, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objMsg.msg = "fail";
                        objMsg.type = false;
                        return Json(objMsg, JsonRequestBehavior.AllowGet);
                    }
                }

            }
            catch (Exception ex)
            {
                objMsg.msg = ex.Message;
                objMsg.type = false;
                return Json(objMsg, JsonRequestBehavior.AllowGet);

            }

            //return View(model);
        }
        //[HttpPost]
        //public ActionResult InsertAuctionHouseNext(long id)
        //{
        //    id = Convert.ToInt64(Session["AuctionHouseID"]);
        //    AjaxReturnModel objMsg = new AjaxReturnModel();
        //    try
        //    {
        //        AuctionHouse aucNext = _auctionHouseService.GetAuctionByAuctionID(id);
        //        AuctionHouseModel model = new AuctionHouseModel();
        //        model.About = aucNext.About;
        //        model.Buyer_Fees = aucNext.Buyer_Fees;
        //        _auctionHouseService.UpdateAuctionHouseDetails(aucNext);
        //        if (aucNext.AuctionHouseID > 0)
        //        {
        //            objMsg.msg = "sucessfully updated";
        //            objMsg.type = true;
        //        }
        //        else
        //        {
        //            objMsg.msg = "fail";
        //            objMsg.type = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objMsg.msg = ex.Message;
        //        objMsg.type = false;
        //    }
        //    return Json(objMsg, JsonRequestBehavior.AllowGet);
        //}

        [Authorize(Roles = "AuctionHouse")]
        public ActionResult AuctionHouseDashboard()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

            if (id > 0)
            {
                long Id = Convert.ToInt64(id);
                AuctionHouseModel auctionHouseModel = new AuctionHouseModel();
                var VarauctionHouse = _auctionHouseService.GetAuctionByAuctionID(Id);
                auctionHouseModel.AuctionHouseName = VarauctionHouse.AuctionHouseName ?? "";
                auctionHouseModel.Address = VarauctionHouse.Address ?? "";
                auctionHouseModel.Logo = VarauctionHouse.Logo ?? "";
                auctionHouseModel.WebSite = VarauctionHouse.WebSite ?? "";
                auctionHouseModel.ContactNo = VarauctionHouse.ContactNo ?? "";
                auctionHouseModel.Email = VarauctionHouse.Email ?? "";
                auctionHouseModel.About = VarauctionHouse.About ?? "";
                auctionHouseModel.AuctionHouseID = VarauctionHouse.AuctionHouseID;

                auctionHouseModel.Buyer_Fees = VarauctionHouse.Buyer_Fees;
                auctionHouseModel.TermsCondition = VarauctionHouse.TermsCondition ?? "";
                List<AuctionHouseSale> AuctionHouseSaleList = _auctionHouseSaleService.GetAuctionHouseSale().Where(a => a.AuctionHouseID == VarauctionHouse.AuctionHouseID && a.SaleDate > DateTime.UtcNow).OrderByDescending(d => d.SaleDate).Take(5).ToList();
                auctionHouseModel.AuctionHouseSaleList = AuctionHouseSaleList;


                return View(auctionHouseModel);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult SearchAuctionHouse(string postalcode, string sortOrder, string currentFilter, string searchString, int? page)
        {
            int totalcarcount = 0;
            List<AuctionHouseModel> auctionHouseModelList = new List<AuctionHouseModel>();
            List<AuctionHouse> auctionhouselist = null;
            List<AuctionHouseCarSelling> AuctionHouseCarSellingList = new List<AuctionHouseCarSelling>();
            if (postalcode != null && postalcode != "")
            {
                auctionhouselist = _auctionHouseService.GetAllQueryableAuctionDetails().Where<AuctionHouse>(t => t.PostalCode == postalcode).ToList<AuctionHouse>();
            }
            else
            {
                auctionhouselist = _auctionHouseService.GetAllQueryableAuctionDetails().ToList<AuctionHouse>();
            }
            if (auctionhouselist != null && auctionhouselist.Count > 0)
            {
                foreach (var item in auctionhouselist)
                {
                    AuctionHouseModel obj = new AuctionHouseModel();
                    obj.AuctionHouseID = item.AuctionHouseID;
                    obj.AuctionHouseName = item.AuctionHouseName;
                    obj.Logo = item.Logo;
                    obj.AuctionHouseSaleList = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseID == obj.AuctionHouseID).ToList();
                    foreach (var item1 in obj.AuctionHouseSaleList)
                    {
                        obj.AuctionHouseCarSellingList = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(p => p.AuctionHouseSaleID == item1.AuctionHouseSaleID).ToList();
                        int carcount = obj.AuctionHouseCarSellingList.Count;
                        totalcarcount += carcount;
                    }
                    obj.CarCount = totalcarcount;
                    auctionHouseModelList.Add(obj);
                }
                
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(auctionHouseModelList.ToPagedList(pageNumber, pageSize));
        }

       

        [Authorize(Roles = "AuctionHouse")]
        [HttpPost]
        public ActionResult UploadAuctionHouseImg()
        {
            AjaxReturnModel objMsg = new AjaxReturnModel();
            try
            {
                var a = Request.Files.Count;
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);



                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseImages/"), fName);
                        Idfile.SaveAs(path);


                        if (Session["filename"] == null)
                            Session["filename"] = path;
                        else
                        {
                            System.IO.File.Delete(Session["filename"].ToString());
                            Session["filename"] = path;
                        }
                        objMsg.msg = fName;
                        objMsg.type = true;
                        return Json(objMsg, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objMsg.msg = "File is corrupted.";
                        objMsg.type = false;
                        return Json(objMsg, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    objMsg.msg = "No File Found!!!!!";
                    objMsg.type = false;
                    return Json(objMsg, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                objMsg.msg = ex.Message;
                objMsg.type = false;
                return Json(objMsg, JsonRequestBehavior.AllowGet);

            }



        }

        [HttpPost]
        public ActionResult ClearAuctionSession()
        {
            AjaxReturnModel objMsg = new AjaxReturnModel();
            objMsg.msg = "success";
            objMsg.type = true;
            Session["AuctionHouseID"] = null;
            Session["filename"] = null;
            //return Json(true, JsonRequestBehavior.AllowGet);
            return Json(objMsg, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(AuctionHouseModel model)
        {
            AuctionHouse objAuctionHouseResult = new AuctionHouse();
            //if (ModelState.IsValid)
            //{
            try
            {

                var user = new ApplicationUser() { UserName = model.UserName };
                string userrolename = "AuctionHouse";
                if (!RoleManager.RoleExists(userrolename))
                {

                    var roleresult = RoleManager.Create(new IdentityRole(userrolename));

                }
                var uid = 0;
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var result2 = UserManager.AddToRole(user.Id, userrolename);
                    if (user != null)
                    {
                        AspNetUsersAdditionalInfo objAspNetUsersAdditionalInfo = new AspNetUsersAdditionalInfo();
                        objAspNetUsersAdditionalInfo.UserKey = user.Id;
                        objAspNetUsersAdditionalInfo.CreatedOn = DateTime.Now;
                        objAspNetUsersAdditionalInfo.IsRemoved = false;
                        objAspNetUsersAdditionalInfo.CreatedFromIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        objAspNetUsersAdditionalInfo.SellerTypeID = 0;
                        _aspNetUsersAdditionalInfoService.InsertAspNetUsersAdditionalInfo(objAspNetUsersAdditionalInfo);

                        if (objAspNetUsersAdditionalInfo.ID > 0)
                        {


                            //AspNetUserRoles objAspNetUserRole = new AspNetUserRoles();
                            AuctionHouse objAuctionHouse = new AuctionHouse();


                            //objAspNetUserRole.UserId = objAspNetUsersAdditionalInfo.ID.ToString();
                            //objAspNetUserRole.RoleId = "1";
                            //_aspNetUserRoleService.InsertAspNetUserRole(objAspNetUserRole);

                            objAuctionHouse.UserID = objAspNetUsersAdditionalInfo.ID;
                            objAuctionHouse.AuctionHouseName = model.AuctionHouseName;
                            objAuctionHouse.Address = model.Address;
                            objAuctionHouse.PostalCode = model.PostalCode;
                            objAuctionHouse.Logo = model.Logo;
                            objAuctionHouse.About = model.About;
                            objAuctionHouse.Buyer_Fees = model.Buyer_Fees;
                            _auctionHouseService.InsertAuctionHouseDetails(objAuctionHouse);

                            if (objAuctionHouse.AuctionHouseID > 0)
                            {
                                objAuctionHouseResult = _auctionHouseService.GetAuctionByAuctionID(Convert.ToInt64(objAuctionHouse.UserID));

                            }

                            else
                            {
                                return null;
                            }
                        }

                    }
                    else
                    {
                        return null;
                    }


                }
                else
                {
                    return null;
                }
                return Json(objAuctionHouseResult, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        //  public ActionResult ActionHouseLogin(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [HttpPost]

        [AllowAnonymous]

        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> AuctionHouseLogin(AuctionHouseModel model)
        {
            //if (ModelState.IsValid)
            //{
            var user = await UserManager.FindAsync(model.UserName, model.Password);
            if (user != null)
            {
                var role = user.Roles.FirstOrDefault().Role.Name;
                if (role.ToLower() == "auctionhouse")
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToAction("AuctionHouseDashboard", "AuctionHouse");
                }
                else
                {
                    ModelState.AddModelError("", "You are not an AuctionHouse User");
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");

            }


            return View(model);

        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "AuctionHouse")]
        public ActionResult AuctionHouseSales()
        {
            try
            {
                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                var AuctionHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(p => p.UserID == id).FirstOrDefault();
                List<AuctionHouseUpcomingSalesModel> AuctionHouseUpcomingSalesModelList = new List<AuctionHouseUpcomingSalesModel>();
                if (AuctionHouseDetails != null)
                {
                    IList<AuctionHouseSale> varAucSellDetails = null;

                    ViewBag.Title = "Upcoming Sales";
                    varAucSellDetails = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseID == AuctionHouseDetails.AuctionHouseID && t.SaleDate >= DateTime.UtcNow).ToList();



                    if (varAucSellDetails.Count > 0)
                    {
                        foreach (var item in varAucSellDetails)
                        {
                            AuctionHouseUpcomingSalesModel model = new AuctionHouseUpcomingSalesModel();
                            model.aucHouseSale = item;

                            AuctionHouseUpcomingSalesModelList.Add(model);

                        }

                    }
                }

                return View(AuctionHouseUpcomingSalesModelList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult PreviousSales()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            var AuctionHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(p => p.UserID == id).FirstOrDefault();
            List<AuctionHouseUpcomingSalesModel> AuctionHouseUpcomingSalesModelList = new List<AuctionHouseUpcomingSalesModel>();
            if (AuctionHouseDetails != null)
            {
                IList<AuctionHouseSale> varAucSellDetails = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseID == AuctionHouseDetails.AuctionHouseID && t.SaleDate <= DateTime.Now).ToList();


                if (varAucSellDetails.Count > 0)
                {
                    foreach (var item in varAucSellDetails)
                    {
                        AuctionHouseUpcomingSalesModel model = new AuctionHouseUpcomingSalesModel();
                        model.aucHouseSale = item;

                        AuctionHouseUpcomingSalesModelList.Add(model);

                    }

                }
            }

            return View(AuctionHouseUpcomingSalesModelList);
        }
        [HttpPost]
        public ActionResult ChangeSaleDate(long id)
        {
            AuctionHouseUpcomingSalesModel objModel = new AuctionHouseUpcomingSalesModel();
            var varSaleDt = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseSaleID == id).FirstOrDefault();

            if (varSaleDt != null)
            {
                objModel.SaleDate = Convert.ToDateTime(varSaleDt.SaleDate).ToString("dd/MM/yyyy");
            }
            //Session["aucSale"] = objModel.aucHouseSale.AuctionHouseSaleID;
            return Json(objModel.SaleDate, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult ChangeDate(AjaxReturnSaleDate saleChange)
        {



            AuctionHouseSale aucSale = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseSaleID == saleChange.SaleID).FirstOrDefault();
            DateTime dt = DateTime.ParseExact(saleChange.SaleDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (aucSale != null)
            {
                aucSale.SaleDate = dt;
                aucSale.AuctionHouseSaleID = saleChange.SaleID;

                _auctionHouseSaleService.UpdateAuctionHouseSale(aucSale);
                AjaxReturnSaleDate obj = new AjaxReturnSaleDate();
                obj.SaleID = saleChange.SaleID;
                obj.SaleDate = Convert.ToDateTime(aucSale.SaleDate).ToString("dd/MM/yyyy");

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult HouseInfo()
        {
            AuctionHouseModel model = new AuctionHouseModel();

            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

            var AuctionHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(p => p.UserID == id).FirstOrDefault();
            if (AuctionHouseDetails != null)
            {

                model.AuctionHouseID = AuctionHouseDetails.AuctionHouseID;
                model.AuctionHouseName = AuctionHouseDetails.AuctionHouseName;
                model.Logo = AuctionHouseDetails.Logo;
                model.WebSite = AuctionHouseDetails.WebSite;
                model.ContactNo = AuctionHouseDetails.ContactNo;
                model.Address = AuctionHouseDetails.Address;
                model.PostalCode = AuctionHouseDetails.PostalCode;
                model.About = AuctionHouseDetails.About;
                model.Buyer_Fees = AuctionHouseDetails.Buyer_Fees;
                model.SalesCommission = AuctionHouseDetails.SalesCommission;
                model.Email = AuctionHouseDetails.Email;
            }


            return View(model);

        }

        public static string GetMakeName(int MakeID)
        {
            return _makeService.GetAllMakes().Where(t => t.ID == MakeID).FirstOrDefault().Makename;
        }

        public static string GetModelName(int MakeID)
        {
            return _carModelService.GetAllCarModels().Where(t => t.MakeID == MakeID).FirstOrDefault().Modelname;
        }

        [HttpPost]
        public ActionResult UpdateAucHouseName(UpdateAucHouseName updateAucHouseName)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseName.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseName.AuctionHouseID;
                varAucHouseDetails.AuctionHouseName = updateAucHouseName.AuctionHouseName;


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.AuctionHouseName = varAucHouseDetails.AuctionHouseName;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseName, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateAucHouseBuyerFee(UpdateAucHouseBuyerFee updateAucHouseBuyerFee)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseBuyerFee.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseBuyerFee.AuctionHouseID;
                if (!string.IsNullOrEmpty(updateAucHouseBuyerFee.Buyer_Fees))
                {
                    varAucHouseDetails.Buyer_Fees = updateAucHouseBuyerFee.Buyer_Fees;
                }
                else
                {
                    varAucHouseDetails.Buyer_Fees = "0";
                }


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.Buyer_Fees = varAucHouseDetails.Buyer_Fees;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseBuyerFee, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateAucHouseDescrip(UpdateAucHouseDescrip updateAucHouseDescrip)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseDescrip.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseDescrip.AuctionHouseID;
                varAucHouseDetails.About = updateAucHouseDescrip.About;


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.About = varAucHouseDetails.About;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseDescrip, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult UpdateAucHouseAddress(UpdateAucHouseAddress updateAucHouseAddress)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseAddress.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseAddress.AuctionHouseID;
                varAucHouseDetails.Address = updateAucHouseAddress.Address;


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.Address = varAucHouseDetails.Address;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseAddress, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateAucHouseContactNo(UpdateAucHouseContactNo updateAucHouseContactNo)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseContactNo.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseContactNo.AuctionHouseID;
                varAucHouseDetails.ContactNo = updateAucHouseContactNo.ContactNo;


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.ContactNo = varAucHouseDetails.ContactNo;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseContactNo, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult UpdateAucHouseEmail(UpdateAucHouseEmail UpdateAucHouseEmail)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == UpdateAucHouseEmail.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = UpdateAucHouseEmail.AuctionHouseID;
                varAucHouseDetails.Email = UpdateAucHouseEmail.Email;


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.Email = varAucHouseDetails.Email;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(UpdateAucHouseEmail, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public ActionResult UpdateAucHouseSaleDate(UpdateAucHouseSaleDate UpdateAucHouseSaleDate)
        {
            try
            {
                if (UpdateAucHouseSaleDate != null)
                {
                    AuctionHouseSale obj = new AuctionHouseSale();

                    obj.AuctionHouseID = UpdateAucHouseSaleDate.AuctionHouseID;
                    obj.SaleDate = DateTime.ParseExact(UpdateAucHouseSaleDate.SaleDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    obj.Title = UpdateAucHouseSaleDate.Title;

                    _auctionHouseSaleService.InsertAuctionHouseSale(obj);



                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }



        public ActionResult UpdateAucHouseWebSite(UpdateAucHouseWebSite updateAucHouseWebSite)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseWebSite.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseWebSite.AuctionHouseID;
                varAucHouseDetails.WebSite = updateAucHouseWebSite.WebSite;


                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.WebSite = varAucHouseDetails.WebSite;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseWebSite, JsonRequestBehavior.AllowGet);

        }


        public ActionResult UpdateAucHouseSalesCommission(UpdateAucHouseSalesCommission updateAucHouseSalesCommission)
        {
            var varAucHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == updateAucHouseSalesCommission.AuctionHouseID).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();

            if (varAucHouseDetails != null)
            {
                varAucHouseDetails.AuctionHouseID = updateAucHouseSalesCommission.AuctionHouseID;
                varAucHouseDetails.SalesCommission = updateAucHouseSalesCommission.SalesCommission;
                obj.AuctionHouseID = varAucHouseDetails.AuctionHouseID;
                obj.SalesCommission = varAucHouseDetails.SalesCommission;
                _auctionHouseService.UpdateAuctionHouseDetails(obj);


            }

            return Json(updateAucHouseSalesCommission, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UploadVehicleImage(long id)
        {

            AuctionHouse img = new AuctionHouse();

            if (Request.Files.Count > 0)
            {
                var Idfile = Request.Files[0];
                if (Idfile != null && Idfile.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Idfile.FileName);
                    string extension = Path.GetExtension(Idfile.FileName);
                    string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                    var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseImages/"), fName);
                    Idfile.SaveAs(path);



                    var varAucImg = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == id).FirstOrDefault();

                    if (varAucImg != null)
                    {
                        varAucImg.AuctionHouseID = id;
                        varAucImg.Logo = fName;

                        img.AuctionHouseID = varAucImg.AuctionHouseID;
                        img.Logo = varAucImg.Logo;

                        _auctionHouseService.UpdateAuctionHouseDetails(img);


                    }


                }
            }
            return Json(img, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAuctionHouse(long id)
        {
            var varAucHouse = _auctionHouseService.GetAllQueryableAuctionDetails().Where(t => t.AuctionHouseID == id).FirstOrDefault();

            AuctionHouse obj = new AuctionHouse();
            if (varAucHouse != null)
            {
                obj.AuctionHouseName = varAucHouse.AuctionHouseName;
                obj.About = varAucHouse.About;
                obj.Buyer_Fees = varAucHouse.Buyer_Fees;
                obj.Address = varAucHouse.Address;
                obj.ContactNo = varAucHouse.ContactNo;
                obj.WebSite = varAucHouse.WebSite;
                obj.SalesCommission = varAucHouse.SalesCommission;
                obj.Email = varAucHouse.Email;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAuctionHouseSale(long id)
        {
            var varAucHouseSale = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseSaleID == id).FirstOrDefault();

            AuctionHouseSale obj = new AuctionHouseSale();
            if (varAucHouseSale != null)
            {
                obj.AuctionHouseSaleID = varAucHouseSale.AuctionHouseSaleID;
                obj.AuctionHouseID = varAucHouseSale.AuctionHouseID;
                obj.SaleDate = varAucHouseSale.SaleDate;
                obj.Title = varAucHouseSale.Title;

            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EnterSalesRoom()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            var AuctionHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(p => p.UserID == id).FirstOrDefault();
            List<AuctionHouseUpcomingSalesModel> AuctionHouseUpcomingSalesModelList = new List<AuctionHouseUpcomingSalesModel>();
            if (AuctionHouseDetails != null)
            {
                IList<AuctionHouseSale> varAucSellDetails = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseID == AuctionHouseDetails.AuctionHouseID && t.SaleDate > DateTime.Now).ToList();


                if (varAucSellDetails.Count > 0)
                {
                    foreach (var item in varAucSellDetails)
                    {
                        if (item.AuctionHouseCarSellingList.Count > 0)
                        {
                            AuctionHouseUpcomingSalesModel model = new AuctionHouseUpcomingSalesModel();
                            model.aucHouseSale = item;

                            AuctionHouseUpcomingSalesModelList.Add(model);
                        }

                    }

                }
            }
            return View(AuctionHouseUpcomingSalesModelList);
        }


        //public ActionResult ClassifiedAds()
        //{
        //    try
        //    {
        //        string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
        //        var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
        //        long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
        //        var AuctionHouseDetails = _auctionHouseService.GetAllQueryableAuctionDetails().Where(p => p.UserID == id).FirstOrDefault();

        //        AuctionHouseClassifiedAdModel model = new AuctionHouseClassifiedAdModel();
        //        IList<AuctionHouseCarSelling> varAuctionHouseCarDetailsList = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.AuctionHouse.AuctionHouseID == AuctionHouseDetails.AuctionHouseID && t.AuctionHouseSale.SaleDate >= DateTime.UtcNow).ToList();
               
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }

        //}


    }


    public class AjaxReturnModel
    {
        public string msg { get; set; }
        public bool type { get; set; }
    }

    public class AjaxReturnSaleDate
    {
        public string SaleDate { get; set; }
        public long SaleID { get; set; }
    }
    public class UpdateAucHouseName
    {
        public string AuctionHouseName { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseDescrip
    {
        public string About { get; set; }
        public long AuctionHouseID { get; set; }
    }



    public class UpdateAucHouseAddress
    {
        public string Address { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseContactNo
    {
        public string ContactNo { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseWebSite
    {
        public string WebSite { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseSalesCommission
    {
        public string SalesCommission { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseBuyerFee
    {
        public string Buyer_Fees { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseEmail
    {
        public string Email { get; set; }
        public long AuctionHouseID { get; set; }
    }

    public class UpdateAucHouseSaleDate
    {
        public string SaleDate { get; set; }
        public long AuctionHouseID { get; set; }
        public string Title { get; set; }
    }

}