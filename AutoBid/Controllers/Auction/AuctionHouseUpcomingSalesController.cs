using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBid.Models.Auction;
using Service.Auction;
using Core.Auction;
using Service.Misc;
using Service.AspUser;

namespace AutoBid.Controllers.Auction
{
    [Authorize(Roles = "AuctionHouse")]
    public class AuctionHouseUpcomingSalesController : Controller
    {
        private readonly IAuctionHouseAddEditVehicleService _auctionHouseAddEditVehicleService;
        private readonly IAuctionHouseSaleService _auctionHouseSaleService;
        private readonly IAuctionHouseService _auctionHouseService;
        private static IMakeService _makeService;
        private static ICarModelService _carModelService;
        private static IAspNetUserService _aspNetUserService;

        public AuctionHouseUpcomingSalesController(
             IAuctionHouseAddEditVehicleService auctionHouseAddEditVehicleService,
             IAuctionHouseSaleService auctionHouseSaleService,
             IAuctionHouseService auctionHouseService,
             IMakeService makeService,
             ICarModelService carModelService,
            IAspNetUserService aspNetUserService
             )
        {

            _auctionHouseAddEditVehicleService = auctionHouseAddEditVehicleService;
            _auctionHouseSaleService = auctionHouseSaleService;
            _auctionHouseService = auctionHouseService;
            _makeService = makeService;
            _carModelService = carModelService;
            _aspNetUserService = aspNetUserService;


        }

        
    }
}