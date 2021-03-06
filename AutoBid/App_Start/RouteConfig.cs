﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoBid
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "AuctionHouse",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
              name: "AuctionHouseAddEditVehicle",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
           // routes.MapRoute(
           //    name: "Default1",
           //    url: "{controller}/{action}/{type}/{id}",
           //    defaults: new { controller = "Home", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional }
           //);

            routes.MapRoute(
               name: "CarDetails",
               url: "{controller}/{action}/{type}/{id}",
               defaults: new { controller = "Home", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
