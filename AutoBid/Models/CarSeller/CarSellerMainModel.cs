using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoBid.Models.CarSeller
{
    public class CarSellerMainModel
    {
        public List<SelectListItem> CarSellerTypeList { get; set; }
        public List<SelectListItem> CarSellingOnList { get; set; }
        public CarSellerMainModel()
        {
            CarSellerTypeList = new List<SelectListItem>();
            CarSellingOnList = new List<SelectListItem>();
        }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
         [Range(0, int.MaxValue, ErrorMessage = "Can only be between 0 .. 200")]
        public int? Milage { get; set; }
       
        public string CarSellerType { get; set; }
        public string CarSellingOnType { get; set; }

    }
}