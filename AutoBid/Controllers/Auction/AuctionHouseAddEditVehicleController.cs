using Service.AspUser;
using Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBid.Models.Auction;
using Core.Misc;
using Core.Auction;
using AutoBid.Enums;
using Service.Auction;
using System.IO;
using System.Globalization;

namespace AutoBid.Controllers.Auction
{
    [Authorize(Roles = "AuctionHouse")]
    public class AuctionHouseAddEditVehicleController : Controller
    {

        private readonly IAspNetUserService _aspNetUserService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly ICarModelService _carModelService;
        private readonly IMakeService _makeService;
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly IInteriorTrimService _interiorTrimService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly IEngineSizeService _engineSizeService;
        private readonly IAuctionHouseAddEditVehicleService _auctionHouseAddEditVehicleService;
        private readonly IAuctionHouseCarSellingVehicleImagesService _auctionHouseCarSellingVehicleImagesService;
        private readonly IAuctionHouseSaleService _auctionHouseSaleService;
        private readonly IAuctionHouseService _auctionHouseService;
        private readonly IAuctionHouseCarSellingVehicleImagesMoreService _auctionHouseCarSellingVehicleImagesMoreService;
        private readonly IServiceHistoryAuctionService _serviceHistoryAuctionService;
        private readonly ICheckStatusService _checkStatusService;



        public AuctionHouseAddEditVehicleController(
            IAuctionHouseService auctionHouseService,
            IAspNetUserService aspNetUserService,
            IBodyTypeService bodyTypeService,
            ICarModelService carModelService,
            IMakeService makeService,
            ITransmissionTypeService transmissionTypeService,
            IFuelTypeService fuelTypeService,
            IEngineSizeService engineSizeService,
            IAuctionHouseAddEditVehicleService auctionHouseAddEditVehicleService,
            IAuctionHouseCarSellingVehicleImagesService auctionHouseCarSellingVehicleImagesService,
             IAuctionHouseSaleService auctionHouseSaleService,
            IAuctionHouseCarSellingVehicleImagesMoreService auctionHouseCarSellingVehicleImagesMoreService,
            IInteriorTrimService interiorTrimService,
            IServiceHistoryAuctionService serviceHistoryAuctionService,
             ICheckStatusService checkStatusService
            )
        {
            _auctionHouseService = auctionHouseService;
            _aspNetUserService = aspNetUserService;
            _bodyTypeService = bodyTypeService;
            _carModelService = carModelService;
            _makeService = makeService;
            _transmissionTypeService = transmissionTypeService;
            _fuelTypeService = fuelTypeService;
            _engineSizeService = engineSizeService;
            _auctionHouseAddEditVehicleService = auctionHouseAddEditVehicleService;
            _auctionHouseCarSellingVehicleImagesService = auctionHouseCarSellingVehicleImagesService;
            _auctionHouseSaleService = auctionHouseSaleService;
            _auctionHouseCarSellingVehicleImagesMoreService = auctionHouseCarSellingVehicleImagesMoreService;
            _interiorTrimService = interiorTrimService;
            _serviceHistoryAuctionService = serviceHistoryAuctionService;
            _checkStatusService = checkStatusService;

        }
        //
        // GET: /AuctionHouseAddEditVehicle/
        public ActionResult Index()
        {
            AuctionHouseAddEditVehicleModel model = new AuctionHouseAddEditVehicleModel();
            var varMakeList = _makeService.GetAllMakes();
            if (varMakeList != null)
            {
                foreach (var make in varMakeList)
                {
                    model.MakeList.Add(new Make { ID = make.ID, Makename = make.Makename });
                }
            }


            var varbodyTypeList = _bodyTypeService.GetAllBodyTypes();
            if (varbodyTypeList != null)
            {
                foreach (var item in varbodyTypeList)
                {
                    model.BodyTypeList.Add(new BodyType
                    {
                        ID = item.ID,
                        Type = item.Type
                    });
                }
            }

            //var varengineSizeList = _engineSizeService.GetAllEngineSizes();
            //if (varengineSizeList != null)
            //{
            //    foreach (var item in varengineSizeList)
            //    {
            //        model.EngineSizeList.Add(new EngineSize
            //        {
            //            ID = item.ID,
            //            EngineSizeName = item.EngineSizeName
            //        });
            //    }
            //}

            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();

            long aucHouseID = AuctionHouseDetails.AuctionHouseID;

            var auctioncarsaleDate = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.SaleDate > DateTime.UtcNow && t.AuctionHouseID == aucHouseID).ToList();

            if (auctioncarsaleDate != null)
            {
                foreach (var item in auctioncarsaleDate)
                {
                    model.AuctionHouseSaleList.Add(new AuctionHouseSale
                    {
                        AuctionHouseSaleID = item.AuctionHouseSaleID,
                        Title = item.Title
                    });
                }
            }




            model.FuelTypeList = new List<CheckBoxClassFuelType>
       {
        new CheckBoxClassFuelType { Text = "Petrol",ID="1" },
        new CheckBoxClassFuelType { Text = "Diesel" ,ID="2"},
        new CheckBoxClassFuelType { Text = "Bi-Fuel",ID="3" },
         new CheckBoxClassFuelType { Text = "LPG",ID="4" }
        };


            model.TransmissionTypeList = new List<CheckBoxClassTransmission>
        {
        new CheckBoxClassTransmission { Text = "Automatic",ID="1" },
        new CheckBoxClassTransmission { Text = "Manual" ,ID="2"},
        new CheckBoxClassTransmission { Text = "Semi-Auto",ID="3" }
        };
            model.InteriorTrimList = new List<CheckBoxInteriorTrim> 
            {
               new CheckBoxInteriorTrim{Text="Textured",ID="1"},
               new CheckBoxInteriorTrim{Text="Cloth",ID="2"},
               new CheckBoxInteriorTrim{Text="Leather",ID="3"}

            };
            model.ServiceHistoryAuctionList = new List<CheckBoxService> 
            {
               new CheckBoxService{Text="Full Main Dealer",ID="1"},
               new CheckBoxService{Text="Full",ID="2"},
               new CheckBoxService{Text="Part",ID="3"}

            };

            model.ImportedList = new List<CheckBoxImported> 
            {
               new CheckBoxImported{Text="Yes",ID="1"},
               new CheckBoxImported{Text="No",ID="0"},
            };

            model.FullVSProvidedList = new List<CheckBoxFullVSProvided> 
            {
               new CheckBoxFullVSProvided{Text="Yes",ID="1"},
               new CheckBoxFullVSProvided{Text="No",ID="0"},
            };

            model.VCARregisteredList = new List<CheckBoxVCARregistered> 
            {
               new CheckBoxVCARregistered{Text="Yes",ID="1"},
               new CheckBoxVCARregistered{Text="No",ID="0"},
            };

            model.HPIClearList = new List<CheckBoxHPIClear> 
            {
               new CheckBoxHPIClear{Text="Yes",ID="1"},
               new CheckBoxHPIClear{Text="No",ID="0"},
            };



            return View(model);
        }


        public ActionResult Edit(long id)
        {
            AuctionHouseAddEditVehicleModel model = new AuctionHouseAddEditVehicleModel();
            if (id > 0)
            {
                AuctionHouseCarSelling aucHouseEditVehicle = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.AuctionHouseCarSellingID == id).FirstOrDefault();

                if (aucHouseEditVehicle != null)
                {
                    model.AuctionHouseVehicleID = aucHouseEditVehicle.AuctionHouseCarSellingID;
                    model.AuctionHouseID = Convert.ToInt64(aucHouseEditVehicle.AuctionHouseID);
                    model.SaleID = Convert.ToInt64(aucHouseEditVehicle.AuctionHouseSaleID);
                    model.Reserve = Convert.ToDecimal(aucHouseEditVehicle.Reserve);
                    model.MakeID = Convert.ToInt32(aucHouseEditVehicle.MakeID);
                    model.ModelID = Convert.ToInt32(aucHouseEditVehicle.ModelID);
                    //model.EngineSizeID = Convert.ToInt64(aucHouseEditVehicle.EngineSizeID);
                    model.ExtIntColor = aucHouseEditVehicle.ExteriorInteriorColour;
                    model.BodyTypeID = Convert.ToInt32(aucHouseEditVehicle.BodyID);
                    if (aucHouseEditVehicle.RegistrationDate != null)
                    {
                        model.RegistrationDate = Convert.ToDateTime(aucHouseEditVehicle.RegistrationDate).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        model.RegistrationDate = "";
 
                    }
                    model.VINnumber = aucHouseEditVehicle.VINNumber;
                    model.ExactMileage = aucHouseEditVehicle.ExactMileage;
                    if (aucHouseEditVehicle.MOTExpiryDate != null)
                    {
                        model.MOTExpiryDate = Convert.ToDateTime(aucHouseEditVehicle.MOTExpiryDate).ToString("dd/MM/yyyy");
                    }
                    else {
                        model.MOTExpiryDate = "";
 
                    }
                    //if (aucHouseEditVehicle.TaxExpiryDate != null)
                    //{ 
                    //model.TAXExpiryDate = Convert.ToDateTime(aucHouseEditVehicle.TaxExpiryDate).ToString("dd/MM/yyyy");
                    //}
                    //else
                    //{
                    //    model.TAXExpiryDate = "";

                    //}
                    if (aucHouseEditVehicle.DateOfFirstRegistration != null)
                    {
                        model.DateOfFirstRegistration = Convert.ToDateTime(aucHouseEditVehicle.DateOfFirstRegistration).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        model.DateOfFirstRegistration = "";
 
                    }
                    model.VSDetails = aucHouseEditVehicle.VSDetails;
                    model.VCARDetails = aucHouseEditVehicle.VCARDetails;
                    model.FormerKeepersDetails = aucHouseEditVehicle.FormerKeepersDetails;
                    model.RegistrationNo = aucHouseEditVehicle.RegistrationNo;
                    model.EngineSize = aucHouseEditVehicle.EngineSize;

                    var aucHouseVehicleSaleImages = _auctionHouseCarSellingVehicleImagesService.GetAuctionHouseCarSellingVehicleImages().Where(t => t.AuctionHouseCarSellingID == model.AuctionHouseVehicleID).ToList();
                    model.AuctionHouseCarSellingVehicleImagesList = aucHouseVehicleSaleImages;

                    var aucHouseVehicleSaleImagesMore = _auctionHouseCarSellingVehicleImagesMoreService.GetAuctionHouseCarSellingVehicleImagesMore().Where(t => t.AuctionHouseCarSellingID == model.AuctionHouseVehicleID).ToList();
                    model.AuctionHouseCarSellingVehicleImagesMoreList = aucHouseVehicleSaleImagesMore;



                    string fuelTypeIDs = aucHouseEditVehicle.FuelTypeIDs;

                    if (fuelTypeIDs != null)
                    {
                        string[] selectedfuels = fuelTypeIDs.Split(',');
                        List<string> lstVal = selectedfuels.ToList();
                        int i = 0;

                        List<FuelType> fuelTypeList = _fuelTypeService.GetAllFuelTypes().ToList();
                        List<CheckBoxClassFuelType> lst = new List<CheckBoxClassFuelType>();
                        foreach (FuelType fuel in fuelTypeList)
                        {
                            bool flag = false;
                            foreach (var fu in lstVal)
                            {
                                if (fuel.ID == Convert.ToInt32(fu))
                                {
                                    flag = true;
                                }
                            }
                            lst.Add(new CheckBoxClassFuelType
                            {
                                ID = fuel.ID.ToString(),
                                Text = fuel.Type,
                                Checked = flag
                            });
                        }
                        model.FuelTypeList = lst;
                    }
                    else
                    {
                        List<FuelType> fuelTypeList = _fuelTypeService.GetAllFuelTypes().ToList();
                        List<CheckBoxClassFuelType> lst = new List<CheckBoxClassFuelType>();
                        foreach (FuelType fuel in fuelTypeList)
                        {
                            bool flag = false;

                            lst.Add(new CheckBoxClassFuelType
                            {
                                ID = fuel.ID.ToString(),
                                Text = fuel.Type,
                                Checked = flag
                            });

                        }
                        model.FuelTypeList = lst;

                    }


                    string transTypeIDs = aucHouseEditVehicle.TransmissionTypeIDs;

                    if (transTypeIDs != null)
                    {

                        string[] selectedtrans = transTypeIDs.Split(',');
                        List<string> tranLi = selectedtrans.ToList();


                        List<TransmissionType> tranTypeList = _transmissionTypeService.GetAllTransmissionTypes().ToList();
                        List<CheckBoxClassTransmission> tranLiChk = new List<CheckBoxClassTransmission>();
                        foreach (TransmissionType tran in tranTypeList)
                        {
                            bool flag = false;
                            foreach (var tr in tranLi)
                            {
                                if (tran.ID == Convert.ToInt32(tr))
                                {
                                    flag = true;
                                }
                            }
                            tranLiChk.Add(new CheckBoxClassTransmission
                            {
                                ID = tran.ID.ToString(),
                                Text = tran.Type,
                                Checked = flag
                            });
                        }
                        model.TransmissionTypeList = tranLiChk;
                    }
                    else
                    {
                        List<TransmissionType> tranTypeList = _transmissionTypeService.GetAllTransmissionTypes().ToList();
                        List<CheckBoxClassTransmission> tranLiChk = new List<CheckBoxClassTransmission>();
                        foreach (TransmissionType tran in tranTypeList)
                        {
                            bool flag = false;
                            tranLiChk.Add(new CheckBoxClassTransmission
                            {
                                ID = tran.ID.ToString(),
                                Text = tran.Type,
                                Checked = flag
                            });


                        }
                        model.TransmissionTypeList = tranLiChk;
                    }


                    string serviceTypeIDs = aucHouseEditVehicle.ServiceHistoryAuctionIDs;

                    if (serviceTypeIDs != null)
                    {
                        string[] selectedservs = serviceTypeIDs.Split(',');
                        List<string> servLi = selectedservs.ToList();

                        List<ServiceHistoryAuction> serviceTypeList = _serviceHistoryAuctionService.GetAllServiceHistoryAuctions().ToList();
                        List<CheckBoxService> servLiChk = new List<CheckBoxService>();
                        foreach (ServiceHistoryAuction serv in serviceTypeList)
                        {
                            bool flag = false;
                            foreach (var tr in servLi)
                            {
                                if (serv.ID == Convert.ToInt32(tr))
                                {
                                    flag = true;
                                }
                            }
                            servLiChk.Add(new CheckBoxService
                            {
                                ID = serv.ID.ToString(),
                                Text = serv.Type,
                                Checked = flag
                            });
                        }
                        model.ServiceHistoryAuctionList = servLiChk;
                    }
                    else
                    {
                        List<ServiceHistoryAuction> serviceTypeList = _serviceHistoryAuctionService.GetAllServiceHistoryAuctions().ToList();
                        List<CheckBoxService> servLiChk = new List<CheckBoxService>();
                        foreach (ServiceHistoryAuction serv in serviceTypeList)
                        {
                            bool flag = false;
                            servLiChk.Add(new CheckBoxService
                            {
                                ID = serv.ID.ToString(),
                                Text = serv.Type,
                                Checked = flag
                            });
                        }
                        model.ServiceHistoryAuctionList = servLiChk;

                    }


                    string intTrimTypeIDs = aucHouseEditVehicle.InteriorTrimIDs;

                    if (intTrimTypeIDs != null)
                    {

                        string[] selectedinttrims = intTrimTypeIDs.Split(',');
                        List<string> intTrimLi = selectedinttrims.ToList();

                        List<InteriorTrim> IntTrimList = _interiorTrimService.GetAllInteriorTrims().ToList();
                        List<CheckBoxInteriorTrim> injtTrimLiChk = new List<CheckBoxInteriorTrim>();
                        foreach (InteriorTrim intTrim in IntTrimList)
                        {
                            bool flag = false;
                            foreach (var tr in intTrimLi)
                            {
                                if (intTrim.ID == Convert.ToInt32(tr))
                                {
                                    flag = true;
                                }
                            }
                            injtTrimLiChk.Add(new CheckBoxInteriorTrim
                            {
                                ID = intTrim.ID.ToString(),
                                Text = intTrim.Type,
                                Checked = flag
                            });
                        }
                        model.InteriorTrimList = injtTrimLiChk;
                    }
                    else
                    {
                        List<InteriorTrim> IntTrimList = _interiorTrimService.GetAllInteriorTrims().ToList();
                        List<CheckBoxInteriorTrim> injtTrimLiChk = new List<CheckBoxInteriorTrim>();

                        foreach (InteriorTrim intTrim in IntTrimList)
                        {
                            bool flag = false;
                            injtTrimLiChk.Add(new CheckBoxInteriorTrim
                         {
                             ID = intTrim.ID.ToString(),
                             Text = intTrim.Type,
                             Checked = flag
                         });
                        }
                        model.InteriorTrimList = injtTrimLiChk;

                    }

                    if (aucHouseEditVehicle.IsImported != null)
                    {

                        model.IsImported = Convert.ToBoolean(aucHouseEditVehicle.IsImported);
                        string[] isImported = Convert.ToString(model.IsImported).Split(',');


                        List<CheckStatus> chkImportedList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxImported> objImportedLi = new List<CheckBoxImported>();
                        foreach (CheckStatus item in chkImportedList)
                        {
                            foreach (var it in isImported)
                            {
                                if (item.Type == Convert.ToBoolean(it))
                                {
                                    objImportedLi.Add(new CheckBoxImported
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = true
                                    });
                                }

                                else
                                {
                                    objImportedLi.Add(new CheckBoxImported
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = false
                                    });

                                }
                            }

                        }

                        model.ImportedList = objImportedLi;
                    }
                    else
                    {
                        List<CheckStatus> chkImportedList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxImported> objImportedLi = new List<CheckBoxImported>();
                        foreach (CheckStatus item in chkImportedList)
                        {
                            objImportedLi.Add(new CheckBoxImported
                            {
                                ID = item.ChkID.ToString(),
                                Text = item.Text,
                                Checked = false
                            });

                        }
                        model.ImportedList = objImportedLi;


                    }

                    if (aucHouseEditVehicle.IsFullVSProvided != null)
                    {
                        model.IsFullVSProvided = Convert.ToBoolean(aucHouseEditVehicle.IsFullVSProvided);
                        string[] isFullVS = Convert.ToString(model.IsFullVSProvided).Split(',');


                        List<CheckStatus> chkFullVSList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxFullVSProvided> objFullVSLi = new List<CheckBoxFullVSProvided>();
                        foreach (CheckStatus item in chkFullVSList)
                        {
                            foreach (var it in isFullVS)
                            {
                                if (item.Type == Convert.ToBoolean(it))
                                {
                                    objFullVSLi.Add(new CheckBoxFullVSProvided
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = true
                                    });
                                }

                                else
                                {
                                    objFullVSLi.Add(new CheckBoxFullVSProvided
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = false
                                    });

                                }
                            }

                        }

                        model.FullVSProvidedList = objFullVSLi;
                    }
                    else
                    {

                        List<CheckStatus> chkFullVSList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxFullVSProvided> objFullVSLi = new List<CheckBoxFullVSProvided>();
                        foreach (CheckStatus item in chkFullVSList)
                        {
                            objFullVSLi.Add(new CheckBoxFullVSProvided
                            {
                                ID = item.ChkID.ToString(),
                                Text = item.Text,
                                Checked = false
                            });


                        }
                        model.FullVSProvidedList = objFullVSLi;

                    }

                    if (aucHouseEditVehicle.IsVCARregistered != null)
                    {
                        model.IsVCARregistered = Convert.ToBoolean(aucHouseEditVehicle.IsVCARregistered);
                        string[] isVCARRegistered = Convert.ToString(model.IsVCARregistered).Split(',');


                        List<CheckStatus> chkvcarList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxVCARregistered> objVCARLi = new List<CheckBoxVCARregistered>();
                        foreach (CheckStatus item in chkvcarList)
                        {
                            foreach (var it in isVCARRegistered)
                            {
                                if (item.Type == Convert.ToBoolean(it))
                                {
                                    objVCARLi.Add(new CheckBoxVCARregistered
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = true
                                    });
                                }

                                else
                                {
                                    objVCARLi.Add(new CheckBoxVCARregistered
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = false
                                    });

                                }
                            }

                        }

                        model.VCARregisteredList = objVCARLi;
                    }
                    else
                    {
                        List<CheckStatus> chkvcarList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxVCARregistered> objVCARLi = new List<CheckBoxVCARregistered>();

                        foreach (CheckStatus item in chkvcarList)
                        {
                            objVCARLi.Add(new CheckBoxVCARregistered
                            {
                                ID = item.ChkID.ToString(),
                                Text = item.Text,
                                Checked = false
                            });

                        }
                        model.VCARregisteredList = objVCARLi;

                    }

                    if (aucHouseEditVehicle.IsHPIClear != null)
                    {
                        model.IsHPIClear = Convert.ToBoolean(aucHouseEditVehicle.IsHPIClear);
                        string[] isHPI = Convert.ToString(model.IsHPIClear).Split(',');


                        List<CheckStatus> chkhpiList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxHPIClear> objHPILi = new List<CheckBoxHPIClear>();
                        foreach (CheckStatus item in chkhpiList)
                        {
                            foreach (var it in isHPI)
                            {
                                if (item.Type == Convert.ToBoolean(it))
                                {
                                    objHPILi.Add(new CheckBoxHPIClear
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = true
                                    });
                                }

                                else
                                {
                                    objHPILi.Add(new CheckBoxHPIClear
                                    {
                                        ID = item.ChkID.ToString(),
                                        Text = item.Text,
                                        Checked = false
                                    });

                                }
                            }

                        }

                        model.HPIClearList = objHPILi;

                    }
                    else
                    {
                        List<CheckStatus> chkhpiList = _checkStatusService.GetAllCheckStatus().ToList();
                        List<CheckBoxHPIClear> objHPILi = new List<CheckBoxHPIClear>();
                        foreach (CheckStatus item in chkhpiList)
                        {
                            objHPILi.Add(new CheckBoxHPIClear
                             {
                                 ID = item.ChkID.ToString(),
                                 Text = item.Text,
                                 Checked = false
                             });

                        }
                        model.HPIClearList = objHPILi;

                    }
                }
            }



                var varMakeList = _makeService.GetAllMakes();
                if (varMakeList != null)
                {
                    foreach (var make in varMakeList)
                    {
                        model.MakeList.Add(new Make { ID = make.ID, Makename = make.Makename });
                    }
                }
                var varbodyTypeList = _bodyTypeService.GetAllBodyTypes();
                if (varbodyTypeList != null)
                {
                    foreach (var item in varbodyTypeList)
                    {
                        model.BodyTypeList.Add(new BodyType
                        {
                            ID = item.ID,
                            Type = item.Type
                        });
                    }
                }
                //var varengineSizeList = _engineSizeService.GetAllEngineSizes();
                //if (varengineSizeList != null)
                //{
                //    foreach (var item in varengineSizeList)
                //    {
                //        model.EngineSizeList.Add(new EngineSize
                //        {
                //            ID = item.ID,
                //            EngineSizeName = item.EngineSizeName
                //        });
                //    }
                //}
                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();

                long aucHouseID = AuctionHouseDetails.AuctionHouseID;

                var auctioncarsaleDate = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.SaleDate > DateTime.UtcNow && t.AuctionHouseID == aucHouseID).ToList();
                if (auctioncarsaleDate != null)
                {
                    foreach (var item in auctioncarsaleDate)
                    {
                        model.AuctionHouseSaleList.Add(new AuctionHouseSale
                        {
                            AuctionHouseSaleID = item.AuctionHouseSaleID,
                            Title = item.Title
                        });
                    }
                }

            return View(model);
        }
            
        [HttpPost]
        public ActionResult Edit(AuctionHouseAddEditVehicleModel model)
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
            AuctionHouseCarSelling obj = new AuctionHouseCarSelling();


                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();
                obj.AuctionHouseCarSellingID = Convert.ToInt64(model.AuctionHouseVehicleID);

                var varAuctionHouseVehicleDetails = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSellingByID(obj.AuctionHouseCarSellingID);

                if (varAuctionHouseVehicleDetails != null)
                {
                    varAuctionHouseVehicleDetails.AuctionHouseID = AuctionHouseDetails.AuctionHouseID;
                    
                    varAuctionHouseVehicleDetails.RegistrationNo = model.RegistrationNo;
                    varAuctionHouseVehicleDetails.AuctionHouseSaleID = model.SaleID;
                    varAuctionHouseVehicleDetails.Reserve = model.Reserve.ToString();
                    varAuctionHouseVehicleDetails.MakeID = model.MakeID;
                    varAuctionHouseVehicleDetails.ModelID = model.ModelID;
                    varAuctionHouseVehicleDetails.BodyID = model.BodyTypeID;
                    varAuctionHouseVehicleDetails.ExteriorInteriorColour = model.ExtIntColor ?? "";
                    if (!string.IsNullOrEmpty(model.MOTExpiryDate))
                        varAuctionHouseVehicleDetails.MOTExpiryDate = DateTime.ParseExact(model.MOTExpiryDate, "dd/MM/yyyy", null);
                    //varAuctionHouseVehicleDetails.EngineSizeID = model.EngineSizeID;
                    varAuctionHouseVehicleDetails.EngineSize = model.EngineSize;
                    varAuctionHouseVehicleDetails.ExactMileage = model.ExactMileage ?? "";
                    varAuctionHouseVehicleDetails.VINNumber = model.VINnumber ?? "";
                    varAuctionHouseVehicleDetails.FormerKeepersDetails = model.FormerKeepersDetails ?? "";
                    varAuctionHouseVehicleDetails.VSDetails = model.VSDetails ?? "";
                    varAuctionHouseVehicleDetails.VCARDetails = model.VCARDetails ?? "";
                    //if (!string.IsNullOrEmpty(model.TAXExpiryDate))
                    //    varAuctionHouseVehicleDetails.TaxExpiryDate = DateTime.ParseExact(model.TAXExpiryDate, "dd/MM/yyyy", null);

                    if (!string.IsNullOrEmpty(model.RegistrationDate))
                        varAuctionHouseVehicleDetails.RegistrationDate = DateTime.ParseExact(model.RegistrationDate, "dd/MM/yyyy", null);

                    varAuctionHouseVehicleDetails.LastServiceDetails = model.LastServiceDetails ?? "";

                    foreach (var item in model.FuelTypeList)
                    {
                        if (item.Checked)
                        {
                            model.FuelTypeIDs += item.ID + ",";
                        }
                    }

                    varAuctionHouseVehicleDetails.FuelTypeIDs = model.FuelTypeIDs.Trim(',');

                    foreach (var item in model.TransmissionTypeList)
                    {
                        if (item.Checked)
                        {
                            model.TransmissionTypeIDs += item.ID + ",";
                        }
                    }
                    varAuctionHouseVehicleDetails.TransmissionTypeIDs = model.TransmissionTypeIDs.Trim(',');
                    foreach (var item in model.InteriorTrimList)
                    {
                        if (item.Checked)
                        {
                            model.interiorTrimIDs += item.ID + ",";
                        }
                    }
                    varAuctionHouseVehicleDetails.InteriorTrimIDs = model.interiorTrimIDs.Trim(',');
                    foreach (var item in model.ServiceHistoryAuctionList)
                    {
                        if (item.Checked)
                        {
                            model.serviceTypeIDs += item.ID + ",";
                        }
                    }
                    varAuctionHouseVehicleDetails.ServiceHistoryAuctionIDs = model.serviceTypeIDs.Trim(',');

                    if (!string.IsNullOrEmpty(model.DateOfFirstRegistration))
                        varAuctionHouseVehicleDetails.DateOfFirstRegistration = DateTime.ParseExact(model.DateOfFirstRegistration, "dd/MM/yyyy", null);
                    foreach (var item in model.ImportedList)
                    {
                        if (item.Checked)
                        {

                            if (item.ID == "1")
                                model.IsImported = true;
                            if (item.ID == "0")
                                model.IsImported = false;

                        }

                    }

                    foreach (var item in model.VCARregisteredList)
                    {
                        if (item.Checked)
                        {

                            if (item.ID == "1")
                                model.IsVCARregistered = true;
                            if (item.ID == "0")
                                model.IsVCARregistered = false;

                        }

                    }
                    foreach (var item in model.FullVSProvidedList)
                    {
                        if (item.Checked)
                        {

                            if (item.ID == "1")
                                model.IsFullVSProvided = true;
                            if (item.ID == "0")
                                model.IsFullVSProvided = false;

                        }

                    }

                    foreach (var item in model.HPIClearList)
                    {
                        if (item.Checked)
                        {


                            if (item.ID == "1")
                                model.IsHPIClear = true;
                            if (item.ID == "0")
                                model.IsHPIClear = false;

                        }

                    }

                    varAuctionHouseVehicleDetails.IsImported = Convert.ToBoolean(model.IsImported);
                    varAuctionHouseVehicleDetails.IsVCARregistered = model.IsVCARregistered;
                    varAuctionHouseVehicleDetails.IsFullVSProvided = model.IsFullVSProvided;
                    varAuctionHouseVehicleDetails.IsHPIClear = model.IsHPIClear;

                }


                model.ErrMsgType = "success";
                _auctionHouseAddEditVehicleService.UpdateAuctionHouseCarSelling(varAuctionHouseVehicleDetails);

                //var regDetails = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.RegistrationNo == model.RegistrationNo).FirstOrDefault();
                //if (regDetails != null)
                //{

                //    model.ErrMsg = "This Registration Number already exists...., Enter different one.";
                //    model.ErrMsgType = "duplicate";



                //}
                //else
                //{
                //    // model.ErrMsg = "This Registration Number already exists...., Enter different one.";
                //    model.ErrMsgType = "success";
                //    _auctionHouseAddEditVehicleService.UpdateAuctionHouseCarSelling(varAuctionHouseVehicleDetails);
                //    model.AuctionHouseVehicleID = obj.ID;

                //}

                Session["AuctionHouseVehicleID"] = varAuctionHouseVehicleDetails.AuctionHouseCarSellingID;
                        
            model.AuctionHouseVehicleID = obj.AuctionHouseCarSellingID;
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddEditVehicleTitleSpecific(long id)
        {

            AuctionHouseAddEditVehicleModel model = new AuctionHouseAddEditVehicleModel();
            var varMakeList = _makeService.GetAllMakes();
            if (varMakeList != null)
            {
                foreach (var make in varMakeList)
                {
                    model.MakeList.Add(new Make { ID = make.ID, Makename = make.Makename });
                }
            }


            var varbodyTypeList = _bodyTypeService.GetAllBodyTypes();
            if (varbodyTypeList != null)
            {
                foreach (var item in varbodyTypeList)
                {
                    model.BodyTypeList.Add(new BodyType
                    {
                        ID = item.ID,
                        Type = item.Type
                    });
                }
            }

            //var varengineSizeList = _engineSizeService.GetAllEngineSizes();
            //if (varengineSizeList != null)
            //{
            //    foreach (var item in varengineSizeList)
            //    {
            //        model.EngineSizeList.Add(new EngineSize
            //        {
            //            ID = item.ID,
            //            EngineSizeName = item.EngineSizeName
            //        });
            //    }
            //}
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
            var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();

            long aucHouseID = AuctionHouseDetails.AuctionHouseID;
            var auctioncarsaleDate = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.SaleDate > DateTime.UtcNow && t.AuctionHouseID == aucHouseID).ToList();
            
            if (auctioncarsaleDate != null)
            {
                foreach (var item in auctioncarsaleDate)
                {
                    model.AuctionHouseSaleList.Add(new AuctionHouseSale
                    {
                        AuctionHouseSaleID = item.AuctionHouseSaleID,
                        Title = item.Title
                    });
                }
            }


            var auctioncarsaleDateSpec = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseSaleID == id).FirstOrDefault();
            if (auctioncarsaleDateSpec != null)
            {
                model.SaleID = auctioncarsaleDateSpec.AuctionHouseSaleID;
                model.Title = auctioncarsaleDateSpec.Title;
            }


            model.FuelTypeList = new List<CheckBoxClassFuelType>
       {
        new CheckBoxClassFuelType { Text = "Petrol",ID="1" },
        new CheckBoxClassFuelType { Text = "Diesel" ,ID="2"},
        new CheckBoxClassFuelType { Text = "Bi-Fuel",ID="3" },
         new CheckBoxClassFuelType { Text = "LPG",ID="4" }
        };


            model.TransmissionTypeList = new List<CheckBoxClassTransmission>
        {
        new CheckBoxClassTransmission { Text = "Automatic",ID="1" },
        new CheckBoxClassTransmission { Text = "Manual" ,ID="2"},
        new CheckBoxClassTransmission { Text = "Semi-Auto",ID="3" }
        };
            model.InteriorTrimList = new List<CheckBoxInteriorTrim> 
            {
               new CheckBoxInteriorTrim{Text="Textured",ID="1"},
               new CheckBoxInteriorTrim{Text="Cloth",ID="2"},
               new CheckBoxInteriorTrim{Text="Leather",ID="3"}

            };
            model.ServiceHistoryAuctionList = new List<CheckBoxService> 
            {
               new CheckBoxService{Text="Full Main Dealer",ID="1"},
               new CheckBoxService{Text="Full",ID="2"},
               new CheckBoxService{Text="Part",ID="3"}

            };

            model.ImportedList = new List<CheckBoxImported> 
            {
               new CheckBoxImported{Text="Yes",ID="1"},
               new CheckBoxImported{Text="No",ID="0"},
            };

            model.FullVSProvidedList = new List<CheckBoxFullVSProvided> 
            {
               new CheckBoxFullVSProvided{Text="Yes",ID="1"},
               new CheckBoxFullVSProvided{Text="No",ID="0"},
            };

            model.VCARregisteredList = new List<CheckBoxVCARregistered> 
            {
               new CheckBoxVCARregistered{Text="Yes",ID="1"},
               new CheckBoxVCARregistered{Text="No",ID="0"},
            };

            model.HPIClearList = new List<CheckBoxHPIClear> 
            {
               new CheckBoxHPIClear{Text="Yes",ID="1"},
               new CheckBoxHPIClear{Text="No",ID="0"},
            };



            return View(model);


        }


        [HttpPost]
        public ActionResult GetModels(long makeID)
        {
            List<AuctionHouseAddEditVehicleModel> list = new List<AuctionHouseAddEditVehicleModel>();
            var carModelList = _carModelService.GetAllCarModels().Where<CarModel>(cm => cm.MakeID == makeID).ToList<CarModel>();
            if (carModelList != null)
            {

                foreach (CarModel item in carModelList)
                {
                    AuctionHouseAddEditVehicleModel model = new AuctionHouseAddEditVehicleModel();
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
        public ActionResult Index(AuctionHouseAddEditVehicleModel model)
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
            AuctionHouseCarSelling obj = new AuctionHouseCarSelling();


            if (Session["AuctionHouseVehicleID"] == null)
            {

                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();

                obj.AuctionHouseID = AuctionHouseDetails.AuctionHouseID;
                obj.AuctionHouseSaleID = model.SaleID;
                obj.Reserve = model.Reserve.ToString();
                obj.RegistrationNo = model.RegistrationNo;
                obj.MakeID = newMakeID;
                obj.ModelID = newCarModelID;
                obj.BodyID = model.BodyTypeID;
                obj.ExteriorInteriorColour = model.ExtIntColor ?? "";
                if (!string.IsNullOrEmpty(model.MOTExpiryDate))
                    obj.MOTExpiryDate = DateTime.ParseExact(model.MOTExpiryDate, "dd/MM/yyyy", null);
                //obj.EngineSizeID = model.EngineSizeID;
                obj.EngineSize = model.EngineSize;
                obj.ExactMileage = model.ExactMileage ?? "";
                obj.VINNumber = model.VINnumber ?? "";
                obj.FormerKeepersDetails = model.FormerKeepersDetails ?? "";
                obj.VSDetails = model.VSDetails ?? "";
                obj.VCARDetails = model.VCARDetails ?? "";
                //if (!string.IsNullOrEmpty(model.TAXExpiryDate))
                //    obj.TaxExpiryDate = DateTime.ParseExact(model.TAXExpiryDate, "dd/MM/yyyy", null);
                obj.LastServiceDetails = model.LastServiceDetails ?? "";

                foreach (var item in model.FuelTypeList)
                {
                    if (item.Checked)
                    {
                        model.FuelTypeIDs += item.ID + ",";
                    }
                }

                obj.FuelTypeIDs = model.FuelTypeIDs.Trim(',');

                foreach (var item in model.TransmissionTypeList)
                {
                    if (item.Checked)
                    {
                        model.TransmissionTypeIDs += item.ID + ",";
                    }
                }
                obj.TransmissionTypeIDs = model.TransmissionTypeIDs.Trim(',');
                foreach (var item in model.InteriorTrimList)
                {
                    if (item.Checked)
                    {
                        model.interiorTrimIDs += item.ID + ",";
                    }
                }
                obj.InteriorTrimIDs = model.interiorTrimIDs.Trim(',');
                foreach (var item in model.ServiceHistoryAuctionList)
                {
                    if (item.Checked)
                    {
                        model.serviceTypeIDs += item.ID + ",";
                    }
                }
                obj.ServiceHistoryAuctionIDs = model.serviceTypeIDs.Trim(',');

                if (!string.IsNullOrEmpty(model.DateOfFirstRegistration))
                    obj.DateOfFirstRegistration = DateTime.ParseExact(model.DateOfFirstRegistration, "dd/MM/yyyy", null);

                if (!string.IsNullOrEmpty(model.RegistrationDate))
                    obj.RegistrationDate = DateTime.ParseExact(model.RegistrationDate, "dd/MM/yyyy", null);

                foreach (var item in model.ImportedList)
                {
                    if (item.Checked)
                    {
                        if (item.ID == "1")
                            model.IsImported = true;
                        if (item.ID == "0")
                            model.IsImported =false;

                    }

                }

                foreach (var item in model.VCARregisteredList)
                {
                    if (item.Checked)
                    {
                        if (item.ID == "1")
                            model.IsVCARregistered = true;
                        if (item.ID == "0")
                            model.IsVCARregistered = false;

                    }

                }
                foreach (var item in model.FullVSProvidedList)
                {
                    if (item.Checked)
                    {

                        if (item.ID == "1")
                            model.IsFullVSProvided = true;
                        if (item.ID == "0")
                            model.IsFullVSProvided = false;

                    }

                }

                foreach (var item in model.HPIClearList)
                {
                    if (item.Checked)
                    {
                        if (item.ID == "1")
                            model.IsHPIClear = true;
                        if (item.ID == "0")
                            model.IsHPIClear = false;


                    }

                }

                obj.IsImported = Convert.ToBoolean(model.IsImported);
                obj.IsVCARregistered = model.IsVCARregistered;
                obj.IsFullVSProvided = model.IsFullVSProvided;
                obj.IsHPIClear = model.IsHPIClear;


                var regDetails = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.RegistrationNo == model.RegistrationNo).FirstOrDefault();
                if (regDetails != null)
                {

                    model.ErrMsg = "This Registration Number already exists...., Enter different one.";
                    model.ErrMsgType = "duplicate";



                }
                else
                {
                    // model.ErrMsg = "This Registration Number already exists...., Enter different one.";
                    model.ErrMsgType = "success";
                    _auctionHouseAddEditVehicleService.InsertAuctionHouseCarSelling(obj);
                    Session["AuctionHouseVehicleID"] = obj.AuctionHouseCarSellingID;
                    model.AuctionHouseVehicleID = obj.AuctionHouseCarSellingID;

                }
            }
            else
            {

                string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
                var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
                long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;
                var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();
                obj.AuctionHouseCarSellingID = Convert.ToInt64(model.AuctionHouseVehicleID);

                var varAuctionHouseVehicleDetails = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSellingByID(obj.AuctionHouseCarSellingID);

                if (varAuctionHouseVehicleDetails != null)
                {
                    varAuctionHouseVehicleDetails.AuctionHouseID = AuctionHouseDetails.AuctionHouseID;
                    //varAuctionHouseVehicleDetails.AuctionHouseID =Convert.ToInt64(Session["AuctionHouseVehicleID"]);
                    varAuctionHouseVehicleDetails.AuctionHouseSaleID = model.SaleID;
                    varAuctionHouseVehicleDetails.Reserve = model.Reserve.ToString();
                    varAuctionHouseVehicleDetails.RegistrationNo = model.RegistrationNo;
                    varAuctionHouseVehicleDetails.MakeID = model.MakeID;
                    varAuctionHouseVehicleDetails.ModelID = model.ModelID;
                    varAuctionHouseVehicleDetails.BodyID = model.BodyTypeID;
                    varAuctionHouseVehicleDetails.ExteriorInteriorColour = model.ExtIntColor ?? "";
                    if (!string.IsNullOrEmpty(model.MOTExpiryDate))
                        varAuctionHouseVehicleDetails.MOTExpiryDate = DateTime.ParseExact(model.MOTExpiryDate, "dd/MM/yyyy", null);
                    //varAuctionHouseVehicleDetails.EngineSizeID = model.EngineSizeID;
                    varAuctionHouseVehicleDetails.EngineSize = model.EngineSize;
                    varAuctionHouseVehicleDetails.ExactMileage = model.ExactMileage ?? "";
                    varAuctionHouseVehicleDetails.VINNumber = model.VINnumber ?? "";
                    varAuctionHouseVehicleDetails.FormerKeepersDetails = model.FormerKeepersDetails ?? "";
                    varAuctionHouseVehicleDetails.VSDetails = model.VSDetails ?? "";
                    varAuctionHouseVehicleDetails.VCARDetails = model.VCARDetails ?? "";
                    //if (!string.IsNullOrEmpty(model.TAXExpiryDate))
                    //    varAuctionHouseVehicleDetails.TaxExpiryDate = DateTime.ParseExact(model.TAXExpiryDate, "dd/MM/yyyy", null);

                    if (!string.IsNullOrEmpty(model.RegistrationDate))
                        varAuctionHouseVehicleDetails.RegistrationDate = DateTime.ParseExact(model.RegistrationDate, "dd/MM/yyyy", null);

                    varAuctionHouseVehicleDetails.LastServiceDetails = model.LastServiceDetails ?? "";

                    foreach (var item in model.FuelTypeList)
                    {
                        if (item.Checked)
                        {
                            model.FuelTypeIDs += item.ID + ",";
                        }
                    }

                    varAuctionHouseVehicleDetails.FuelTypeIDs = model.FuelTypeIDs.Trim(',');

                    foreach (var item in model.TransmissionTypeList)
                    {
                        if (item.Checked)
                        {
                            model.TransmissionTypeIDs += item.ID + ",";
                        }
                    }
                    varAuctionHouseVehicleDetails.TransmissionTypeIDs = model.TransmissionTypeIDs.Trim(',');
                    foreach (var item in model.InteriorTrimList)
                    {
                        if (item.Checked)
                        {
                            model.interiorTrimIDs += item.ID + ",";
                        }
                    }
                    varAuctionHouseVehicleDetails.InteriorTrimIDs = model.interiorTrimIDs.Trim(',');
                    foreach (var item in model.ServiceHistoryAuctionList)
                    {
                        if (item.Checked)
                        {
                            model.serviceTypeIDs += item.ID + ",";
                        }
                    }
                    varAuctionHouseVehicleDetails.ServiceHistoryAuctionIDs = model.serviceTypeIDs.Trim(',');

                    if (!string.IsNullOrEmpty(model.DateOfFirstRegistration))
                        obj.DateOfFirstRegistration = DateTime.ParseExact(model.DateOfFirstRegistration, "dd/MM/yyyy", null);
                    foreach (var item in model.ImportedList)
                    {
                        if (item.Checked)
                        {

                            if (item.ID == "1")
                                model.IsImported = true;
                            if (item.ID == "0")
                                model.IsImported = false;

                        }

                    }

                    foreach (var item in model.VCARregisteredList)
                    {
                        if (item.Checked)
                        {

                            if (item.ID == "1")
                                model.IsVCARregistered = true;
                            if (item.ID == "0")
                                model.IsVCARregistered = false;

                        }

                    }
                    foreach (var item in model.FullVSProvidedList)
                    {
                        if (item.Checked)
                        {

                            if (item.ID == "1")
                                model.IsFullVSProvided = true;
                            if (item.ID == "0")
                                model.IsFullVSProvided = false;

                        }

                    }

                    foreach (var item in model.HPIClearList)
                    {
                        if (item.Checked)
                        {


                            if (item.ID == "1")
                                model.IsHPIClear = true;
                            if (item.ID == "0")
                                model.IsHPIClear = false;

                        }

                    }

                    obj.IsImported = Convert.ToBoolean(model.IsImported);
                    obj.IsVCARregistered = model.IsVCARregistered;
                    obj.IsFullVSProvided = model.IsFullVSProvided;
                    obj.IsHPIClear = model.IsHPIClear;

                }
                model.ErrMsgType = "success";
                _auctionHouseAddEditVehicleService.UpdateAuctionHouseCarSelling(varAuctionHouseVehicleDetails);

                //var regDetails = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSelling().Where(t => t.RegistrationNo == model.RegistrationNo).FirstOrDefault();
                //if (regDetails != null)
                //{

                //    model.ErrMsg = "This Registration Number already exists...., Enter different one.";
                //    model.ErrMsgType = "duplicate";



                //}
                //else
                //{
                //    // model.ErrMsg = "This Registration Number already exists...., Enter different one.";
                //    model.ErrMsgType = "success";
                //    _auctionHouseAddEditVehicleService.UpdateAuctionHouseCarSelling(varAuctionHouseVehicleDetails);
                //    model.AuctionHouseVehicleID = obj.ID;

                //}






            }
            model.AuctionHouseVehicleID = obj.AuctionHouseCarSellingID;
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UploadVehicleImage(string ctrlID, long AuctionHouseVehicleID)
        {
            if (Session["AuctionHouseVehicleID"] != null)
            {
                long ID = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);
                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseSaleVehicleImages/"), fName);
                        Idfile.SaveAs(path);
                        AuctionHouseCarSellingVehicleImages img = new AuctionHouseCarSellingVehicleImages();
                        img.AuctionHouseCarSellingID = ID;

                        img.Filename = fName;
                        img.Size = 0;
                        img.Foldername = "~/Content/Assets/AuctionHouseSaleVehicleImages/";

                        _auctionHouseCarSellingVehicleImagesService.InsertAuctionHouseCarSellingVehicleImage(img);

                        return Json(fName, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UploadVehicleImageEdit(string ctrlID, long AuctionHouseVehicleID)
        {
            if (Session["AuctionHouseVehicleID"] != null)
            {
                long ID = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);
                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseSaleVehicleImages/"), fName);
                        Idfile.SaveAs(path);
                        AuctionHouseCarSellingVehicleImages img = new AuctionHouseCarSellingVehicleImages();
                        img.AuctionHouseCarSellingID = ID;

                        img.Filename = fName;
                        img.Size = 0;
                        img.Foldername = "~/Content/Assets/AuctionHouseSaleVehicleImages/";

                        _auctionHouseCarSellingVehicleImagesService.InsertAuctionHouseCarSellingVehicleImage(img);

                        return Json(fName, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult RemoveVehicleImage(string VehicleImage, long AuctionHouseVehicleID)
        {
            bool flag = false;
            if (Session["AuctionHouseVehicleID"] != null)
            {
                long ID = AuctionHouseVehicleID;
                string[] image = VehicleImage.Split('/');
                var Lastindex = image.Last();
                var getcarImageDetails = _auctionHouseCarSellingVehicleImagesService.GetAuctionHouseCarSellingVehicleImages().Where(t => t.AuctionHouseCarSellingID == ID && t.Filename == Lastindex).FirstOrDefault();
                if (getcarImageDetails != null)
                {

                    if (ID > 0)
                    {
                        var path = Server.MapPath(VehicleImage);
                        FileInfo info1 = new FileInfo(path);
                        if (info1.Exists)
                        {
                            info1.Delete();
                            _auctionHouseCarSellingVehicleImagesService.DeleteAuctionHouseCarSellingVehicleImage(getcarImageDetails);
                            flag = true;
                        }


                    }

                }

            }

            return Json(flag, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Finish()
        {
            if (Session["AuctionHouseVehicleID"] != null)
            {
                long id = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
                Session["AuctionHouseVehicleID"] = null;

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //return RedirectToAction("Index", "Home");
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult RegNoCheck(string regno)
        {
            bool flag = false;
            if (Session["AuctionHouseVehicleID"] != null)
            {
                var regDetails = _auctionHouseAddEditVehicleService.GetAllAuctionHouseCarSelling();
                if (regDetails != null)
                {
                    foreach (var item in regDetails)
                    {
                        if (item.RegistrationNo == regno)
                        {
                            flag = true;
                            break;

                        }
                    }
                }
                return Json(flag, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //return RedirectToAction("Index", "Home");
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveImages(List<object> arr)
        {
            //AuctionHouseCarSelling obj = new AuctionHouseCarSelling();
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

            long id = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
            var AuctionHouseDetails = _auctionHouseAddEditVehicleService.GetAuctionHouseCarSellingByID(id);

            //AuctionHouseAddEditVehicleModel model = new AuctionHouseAddEditVehicleModel();
            //if (AuctionHouseDetails != null)
            //{
            //    model.Reserve = Convert.ToDecimal(AuctionHouseDetails.Reserve);
            //    model.RegistrationNo = AuctionHouseDetails.RegistrationNo;
            //    model.MakeID = Convert.ToInt32(AuctionHouseDetails.MakeID);
            //    model.ModelID = Convert.ToInt32(AuctionHouseDetails.ModelID);
            //    model.BodyTypeID = Convert.ToInt32(AuctionHouseDetails.BodyID);
            //    //model.EngineSizeID =Convert.ToInt32(AuctionHouseDetails.EngineSizeID);


            //}


            //model.AuctionHouseCarSelling = AuctionHouseDetails;

            AddVehicle obj = new AddVehicle();
            obj.Reserve = AuctionHouseDetails.Reserve;
            obj.RegistrationNo = AuctionHouseDetails.RegistrationNo;


            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddNewAuctionHouse(AuctionHouseAddEditVehicleModel model)
        {
            AuctionHouseSale obj = new AuctionHouseSale();

            if (!string.IsNullOrEmpty(model.NewSaleDate))
                obj.SaleDate = DateTime.ParseExact(model.NewSaleDate, "dd/MM/yyyy", null).ToUniversalTime();

            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long userid = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

            var AuctionHouseDetails = _auctionHouseService.GetAllAuctionDetails().Where(t => t.UserID == userid).FirstOrDefault();

            obj.AuctionHouseID = AuctionHouseDetails.AuctionHouseID;

            obj.Title = model.Title;

            PopulateSaleDate objSale = new PopulateSaleDate();
            var varSaleTitle = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.Title == model.Title).ToList();
            if (varSaleTitle.Count==0)
            {
                _auctionHouseSaleService.InsertAuctionHouseSale(obj);

                objSale.AuctionHouseSaleID = obj.AuctionHouseSaleID;
                objSale.Title = obj.Title;
                objSale.msg = "success";
            }
            else {
                objSale.msg = "duplicate Title!Enter different Title";

            }
            
            
            return Json(objSale, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadImage(AuctionHouseAddEditVehicleModel model)
        {
            List<AuctionHouseCarSellingVehicleImagesMore> imgList = new List<AuctionHouseCarSellingVehicleImagesMore>();
            AuctionHouseCarSellingVehicleImagesMore img = new AuctionHouseCarSellingVehicleImagesMore();
            long AuctionHouseVehicleID = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
            if (AuctionHouseVehicleID != 0)
            {
                long ID = AuctionHouseVehicleID;
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var Idfile = Request.Files[i];
                        if (Idfile != null && Idfile.ContentLength > 0)
                        {
                            var filename = Path.GetFileName(Idfile.FileName);
                            string extension = Path.GetExtension(Idfile.FileName);
                            string fName = DateTime.Now.ToString("yyyyMMdd_hhssfff") + extension;
                            var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseSaleImagesMore/"), fName);
                            Idfile.SaveAs(path);

                            img.AuctionHouseCarSellingID = ID;

                            img.Filename = fName;
                            img.Size = 0;
                            img.Foldername = "~/Content/Assets/AuctionHouseSaleImagesMore/";

                            _auctionHouseCarSellingVehicleImagesMoreService.InsertAuctionHouseCarSellingVehicleImage(img);



                        }
                    }

                }
            }
            return Json(img, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult RemoveImage(string AuctionHouseCarSellingVehicleImagesMoreID)
        {
            bool flag = false;
            long id = Convert.ToInt64(AuctionHouseCarSellingVehicleImagesMoreID);


            var getcarImageDetails = _auctionHouseCarSellingVehicleImagesMoreService.GetAuctionHouseCarSellingVehicleImagesMore().Where(t => t.AuctionHouseCarSellingVehicleImagesMoreID == id).FirstOrDefault();
            if (getcarImageDetails != null)
            {


                var path = Server.MapPath(getcarImageDetails.Foldername + getcarImageDetails.Filename);
                FileInfo info1 = new FileInfo(path);
                if (info1.Exists)
                {
                    info1.Delete();
                    _auctionHouseCarSellingVehicleImagesMoreService.DeleteAuctionHouseCarSellingVehicleImage(getcarImageDetails);
                    flag = true;
                }


            }




            return Json(flag, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetVehicleImage(string AuctionHouseVehicleID)
        {
            if (Session["AuctionHouseVehicleID"] != null)
            {
                long ID = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);
                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseSaleVehicleImages/"), fName);
                        Idfile.SaveAs(path);
                        AuctionHouseCarSellingVehicleImages model = new AuctionHouseCarSellingVehicleImages();
                        model.AuctionHouseCarSellingID = ID;
                        model.Filename = "";
                        model.Filename = fName;
                        model.Size = 0;
                        model.Foldername = "~/Content/Assets/AuctionHouseSaleVehicleImages/";

                        IList<AuctionHouseCarSellingVehicleImages> vehicleImages = _auctionHouseCarSellingVehicleImagesService.GetAuctionHouseCarSellingVehicleImages().Where(t => t.AuctionHouseCarSellingID == ID).ToList();

                        return Json(vehicleImages, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetVehicleImageMore(string AuctionHouseVehicleID)
        {
            if (Session["AuctionHouseVehicleID"] != null)
            {
                long ID = Convert.ToInt64(Session["AuctionHouseVehicleID"]);
                if (Request.Files.Count > 0)
                {
                    var Idfile = Request.Files[0];
                    if (Idfile != null && Idfile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Idfile.FileName);
                        string extension = Path.GetExtension(Idfile.FileName);
                        string fName = DateTime.Now.ToString("yyyyMMdd_hhss") + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Assets/AuctionHouseSaleImagesMore/"), fName);
                        Idfile.SaveAs(path);
                        AuctionHouseCarSellingVehicleImagesMore model = new AuctionHouseCarSellingVehicleImagesMore();
                        model.AuctionHouseCarSellingID = ID;
                        model.Filename = "";
                        model.Filename = fName;
                        model.Size = 0;
                        model.Foldername = "~/Content/Assets/AuctionHouseSaleImagesMore/";

                        IList<AuctionHouseCarSellingVehicleImagesMore> vehicleImages = _auctionHouseCarSellingVehicleImagesMoreService.GetAuctionHouseCarSellingVehicleImagesMore().Where(t => t.AuctionHouseCarSellingID == ID).ToList();

                        return Json(vehicleImages, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

    }
    public class PopulateSaleDate
    {
        public long AuctionHouseSaleID { get; set; }
        public string Title { get; set; }
        public string msg;
    }

    public class AddVehicle
    {
        public string Reserve { get; set; }
        public string RegistrationNo { get; set; }
       
    }

}
