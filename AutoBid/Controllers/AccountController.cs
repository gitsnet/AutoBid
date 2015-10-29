using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using AutoBid.Models;
using Data;
using Service.Misc;
using Core.Misc;
using Service.CarSeller;
using Service.AspUser;
using Core.User;
using Service.Seller;
using Core.Seller;
using Service.Company;
using Core.Company;
using System.IO;
using System.Globalization;

namespace AutoBid.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ICarSellerTypeService _carSellerTypeService;
        private readonly IAspNetUsersAdditionalInfoService _aspNetUsersAdditionalInfoService;
        private readonly ISellerPersonalInfoService _sellerPersonalInfoService;
        private readonly ICompanyTypeService _companyTypeService;
        private readonly ISellerCompanyInfoService _sellerCompanyInfoService;
        private readonly ISellerCompanyLogoService _sellerCompanyLogoService;


        //public AccountController()
        //    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ObjectContext())))
        //{


        //}

        public AccountController(ICountryService countryService,
            UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager,
             ICarSellerTypeService carSellerTypeService,
            IAspNetUsersAdditionalInfoService aspNetUsersAdditionalInfoService,
            ISellerPersonalInfoService sellerPersonalInfoService,
            ICompanyTypeService companyTypeService,
            ISellerCompanyInfoService sellerCompanyInfoService,
            ISellerCompanyLogoService sellerCompanyLogoService
            )
        {

            UserManager = userManager;
            RoleManager = roleManager;
            _countryService = countryService;
            _carSellerTypeService = carSellerTypeService;
            _aspNetUsersAdditionalInfoService = aspNetUsersAdditionalInfoService;
            _sellerPersonalInfoService = sellerPersonalInfoService;
            _companyTypeService = companyTypeService;
            _sellerCompanyInfoService = sellerCompanyInfoService;
            _sellerCompanyLogoService = sellerCompanyLogoService;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    var role = user.Roles.FirstOrDefault().Role.Name;
                    if (role.ToLower() == "users")
                    {
                        await SignInAsync(user, model.RememberMe);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid user role.");
                    }

                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        //
        // GET: /Account/Index
        [AllowAnonymous]
        public ActionResult Index()
        {
            RegisterViewModel model = new RegisterViewModel();
            var carSellerTypeList = _carSellerTypeService.GetAllCarSellerType();
            if (carSellerTypeList != null)
            {
                foreach (var item in carSellerTypeList)
                {
                    model.CarSellerTypeList.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Type.ToString()
                    });

                }
            }
            return View(model);

        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                long usertypeID = Convert.ToInt32(Id);
                RegisterViewModel model = new RegisterViewModel();
                var countryList = _countryService.GetAllCountry();
                if (countryList != null)
                {
                    foreach (var item in countryList)
                    {
                        model.CountryList.Add(new Country
                        {
                            CountryName = item.CountryName,
                            ID = item.ID
                        });

                    }
                }
                var companyTypeList = _companyTypeService.GetAllCompanyType();
                if (companyTypeList != null)
                {
                    foreach (var item in companyTypeList)
                    {
                        model.CompanyTypeList.Add(new SelectListItem
                        {
                            Text = item.CompanyType1,
                            Value = item.ID.ToString()
                        });
                    }
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            //if (ModelState.IsValid)
            //{
            try
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                string userrolename = "Users";
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
                        objAspNetUsersAdditionalInfo.SellerTypeID = Convert.ToInt32(this.RouteData.Values["Id"]);
                        _aspNetUsersAdditionalInfoService.InsertAspNetUsersAdditionalInfo(objAspNetUsersAdditionalInfo);
                        if (objAspNetUsersAdditionalInfo.ID > 0)
                        {
                            SellerPersonalInfo objSellerPersonalInfo = new SellerPersonalInfo();
                            objSellerPersonalInfo.UserID = objAspNetUsersAdditionalInfo.ID;
                            objSellerPersonalInfo.Title = model.Salutation.ToString();
                            objSellerPersonalInfo.FirstName = model.FirstName.ToString();
                            objSellerPersonalInfo.LastName = model.LastName.ToString();
                            objSellerPersonalInfo.Address = model.Address.ToString();
                            objSellerPersonalInfo.Email = model.Email.ToString();
                            objSellerPersonalInfo.ContactNo = model.Phone.ToString();
                            objSellerPersonalInfo.PostalCode = model.PostalCode.ToString();
                            _sellerPersonalInfoService.InsertSellerPersonalInfo(objSellerPersonalInfo);
                            if (objSellerPersonalInfo.ID > 0)
                            {
                                if (Convert.ToInt32(this.RouteData.Values["Id"]) == 2)
                                {
                                    SellerCompanyInfo objSellerCompanyInfo = new SellerCompanyInfo();
                                    objSellerCompanyInfo.UserID = objAspNetUsersAdditionalInfo.ID;
                                    objSellerCompanyInfo.CompanyTypeID = Convert.ToInt32(model.CompanyTypeID);
                                    objSellerCompanyInfo.CompanyName = model.CompanyName;
                                    objSellerCompanyInfo.Address001 = model.Address;
                                    objSellerCompanyInfo.CityID = 1;
                                    objSellerCompanyInfo.CountryID = Convert.ToInt32(model.CountryID);
                                    objSellerCompanyInfo.PostalCode = model.CompanyPostalCode;
                                    objSellerCompanyInfo.ContactNumbers = model.CompanyContact + "," + model.CompanyContact2 + "," + model.CompanyContact3;
                                    objSellerCompanyInfo.CompanyNumber = model.CompanyNumber;
                                    if (objSellerCompanyInfo.VatNumber != null)
                                        objSellerCompanyInfo.VatNumber = model.VATNumber;
                                    if (objSellerCompanyInfo.YearOfFoundation != null)
                                        objSellerCompanyInfo.YearOfFoundation = Convert.ToInt32(model.YearofFoundation);
                                    if (objSellerCompanyInfo.NoOfEmployees != null)
                                        objSellerCompanyInfo.NoOfEmployees = Convert.ToInt32(model.NoOfEmployee);
                                    if (objSellerCompanyInfo.TurnOver != null)
                                        objSellerCompanyInfo.TurnOver = (decimal)Decimal.Parse(model.TurnOver, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                                    objSellerCompanyInfo.CategoryID = 1;
                                    _sellerCompanyInfoService.InsertSellerCompanyInfo(objSellerCompanyInfo);
                                    if (objSellerCompanyInfo.ID > 0)
                                    {
                                        if (!string.IsNullOrEmpty(model.CompanyLogo))
                                        {
                                            SellerCompanyLogo objSellerCompanyLogo = new SellerCompanyLogo();
                                            objSellerCompanyLogo.CompanyID = objSellerCompanyInfo.ID;
                                            objSellerCompanyLogo.Filename = model.CompanyLogo;
                                            objSellerCompanyLogo.FolderPath = "~/Content/Assets/CompanyLogos";
                                            objSellerCompanyLogo.OriginalFilename = model.CompanyLogo;
                                            objSellerCompanyLogo.UploadedOn = DateTime.Now;
                                            objSellerCompanyLogo.ImageSizeID = 1;
                                            _sellerCompanyLogoService.InsertSellerCompanyLogo(objSellerCompanyLogo);
                                        }
                                    }
                                }
                                await SignInAsync(user, isPersistent: false);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Registration is not done, please register after sometime later.");
                                return View();

                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Registration is not done, please register after sometime later.");
                            return View();

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Registration is not done, please register after sometime later.");
                        return View();

                    }

                }
                else
                {
                    AddErrors(result);
                    
                    var countryList = _countryService.GetAllCountry();
                    if (countryList != null)
                    {
                        foreach (var item in countryList)
                        {
                            model.CountryList.Add(new Country
                            {
                                CountryName = item.CountryName,
                                ID = item.ID
                            });

                        }
                    }
                    var companyTypeList = _companyTypeService.GetAllCompanyType();
                    if (companyTypeList != null)
                    {
                        foreach (var item in companyTypeList)
                        {
                            model.CompanyTypeList.Add(new SelectListItem
                            {
                                Text = item.CompanyType1,
                                Value = item.ID.ToString()
                            });
                        }
                    }
                

                }
               
            }
            catch (Exception ex)
            { }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UploadSellerCompanyLogo()
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
                    var path = Path.Combine(Server.MapPath("~/Content/Assets/CompanyLogos/"), fName);
                    Idfile.SaveAs(path);
                    return Json(fName, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}