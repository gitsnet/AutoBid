using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.AspUser;
using Service.Auction;
using AutoBid.Models.Auction;

namespace AutoBid.Controllers.Auction
{
    public class AuctionHouseSalesController : Controller
    {
        private readonly IAspNetUserService _aspNetUserService;
        private readonly IAuctionHouseSaleService _auctionHouseSaleService;
        private readonly IAuctionHouseService _auctionHouseService;

        public AuctionHouseSalesController
            (
            IAspNetUserService aspNetUserService,
            IAuctionHouseSaleService auctionHouseSaleService,
            IAuctionHouseService auctionHouseService
            )
        {

            _aspNetUserService = aspNetUserService;
            _auctionHouseSaleService = auctionHouseSaleService;
            _auctionHouseService = auctionHouseService;

        }


        public ActionResult Index()
        {
            string UserName = Request.RequestContext.HttpContext.User.Identity.Name;
            var UserDetails = _aspNetUserService.GetAspNetUserByUserName(UserName);
            long id = UserDetails.AspNetUsersAdditionalInfoes.FirstOrDefault().ID;

            var aucHouseDetail = _auctionHouseService.GetAuctionByAuctionID(id);
            long aucid = aucHouseDetail.AuctionHouseID;

            var aucHouseSaleDetails = _auctionHouseSaleService.GetAuctionHouseSale().Where(t => t.AuctionHouseID == aucid && t.SaleDate<DateTime.UtcNow).ToList();

            AuctionHouseModel model = new AuctionHouseModel();
            if (aucHouseSaleDetails != null)
            {
                model.AuctionHouseSaleList = aucHouseSaleDetails; 
            }
           
            return View(model);
        }
    }
}