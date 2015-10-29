using Core.CarSeller;
using Core.Misc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoBid.Models.CarDetails
{
    public class CarDetailsSearchModel
    {
        public string MakeName { get; set; }
        public decimal Price { get; set; }
        public string ModelName { get; set; }
        public string CarSellerTypeName { get; set; }
        public string BodyTypeName { get; set; }
        public string TransmissionName { get; set; }
        public string FuelTypeName { get; set; }
        public string SearchText { get; set; }
    }
}