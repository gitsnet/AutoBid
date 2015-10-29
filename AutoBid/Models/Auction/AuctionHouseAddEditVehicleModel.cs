using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Misc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoBid.Enums;
using Core.Auction;

namespace AutoBid.Models.Auction
{
    public class AuctionHouseAddEditVehicleModel
    {
        public List<Make> MakeList { get; set; }
        public List<CarModel> CarModelList { get; set; }
        public List<BodyType> BodyTypeList { get; set; }
        //public List<TransmissionType> TransmissionTypeList { get; set; }
        public List<CheckBoxClassFuelType> FuelTypeList { get; set; }

        
        
        //public List<EngineSize> EngineSizeList { get; set; }
        public List<CheckBoxClassTransmission> TransmissionTypeList { get; set; }
       

        public List<CheckBoxService> ServiceHistoryAuctionList { get; set; }
       

        public List<CheckBoxInteriorTrim> InteriorTrimList { get; set; }
       

        public List<CheckBoxImported> ImportedList { get; set; }
        

        public List<CheckBoxFullVSProvided> FullVSProvidedList { get; set; }
       

        public List<CheckBoxVCARregistered> VCARregisteredList { get; set; }
       

        public List<CheckBoxHPIClear> HPIClearList { get; set; }
      

        public IList<AuctionHouseCarSellingVehicleImages> AuctionHouseCarSellingVehicleImagesList { get; set; }
        public IList<AuctionHouseCarSellingVehicleImagesMore> AuctionHouseCarSellingVehicleImagesMoreList { get; set; }
        public IList<AuctionHouseCarSelling> AuctionHouseCarSellingList { get; set; }
        public AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
        public List<AuctionHouseSale> AuctionHouseSaleList { get; set; }
        

        public AuctionHouseAddEditVehicleModel()
        {
           
            MakeList = new List<Make>();
            CarModelList = new List<CarModel>();
            BodyTypeList = new List<BodyType>();
            AuctionHouseSaleList = new List<AuctionHouseSale>();
            //TransmissionTypeList = new List<TransmissionType>();
            //FuelTypeList = new List<CheckBoxClassFuelType>();
            //FuelTypeSelected = new List<FuelType>();
            //EngineSizeList = new List<EngineSize>();
            AuctionHouseCarSellingVehicleImagesMoreList = new List<AuctionHouseCarSellingVehicleImagesMore>();
            //TransmissionTypeList = new List<CheckBoxClassTransmission>();
            //ServiceHistoryAuctionList = new List<CheckBoxService>();  
        }
        [DisplayName("Sale Date")]
        [Required(ErrorMessage = "Sale Date is Required")]
        public string SaleDate { get; set; }
        
        public long SaleID { get; set; }

        public long AuctionHouseID { get; set; }

        [DisplayName("Reserve")]
        [Required(ErrorMessage = "Reserve is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        public decimal Reserve { get; set; }


        [DisplayName("Registration Number")]
        [Required(ErrorMessage = "Registration Number is required.")]

        public string RegistrationNo { get; set; }

        [DisplayName("Make")]
        [Required(ErrorMessage = "Car Make is Required")]
        public int MakeID { get; set; }

        [Required(ErrorMessage = "Car Model is Required")]
        [DisplayName("Model")]
         public int ModelID { get; set; }

        [DisplayName("Model")]
        public string ModelName { get; set; }

        //[DisplayName("Engine Size")]
        //[Required(ErrorMessage = "Engine Size is Required")]
        //public long EngineSizeID { get; set; }



        [Required(ErrorMessage = "EngineSize is required.")]

        public string EngineSize { get; set; }


        [DisplayName("Exterior/InteriorColour")]
        [Required(ErrorMessage = "Exterior/InteriorColour is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ExtIntColor { get; set; }

        [DisplayName("Body Style")]
        [Required(ErrorMessage = "Body Style is Required")]
        public int BodyTypeID { get; set; }

        [DisplayName("Registration Date")]
        [Required(ErrorMessage = "RegistrationDate is Required")]
        [RegularExpression(@"(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Use dd/mm/yyyy format please")]
        public string RegistrationDate { get; set; }


        [Required(ErrorMessage = "VINnumber is Required")]
        public string VINnumber { get; set; }

        [Required(ErrorMessage = "VSDetails is Required")]
        public string VSDetails { get; set; }

        [Required(ErrorMessage = "VCARDetails is Required")]
        public string VCARDetails { get; set; }

       
        [DisplayName("Exact Mileage")]
        [Required(ErrorMessage = "Exact Mileage")]
        public string ExactMileage { get; set; }

        [DisplayName("Former Keepers Details")]
        public string FormerKeepersDetails { get; set; }

        [DisplayName("Last Service Details")]
        public string LastServiceDetails { get; set; }

        [DisplayName("MOT Expiry Date")]
        [Required(ErrorMessage = "MOT Expiry Date is Required")]
        public string MOTExpiryDate { get; set; }

        //[DisplayName("Tax Expiry Date")]
        //[Required(ErrorMessage = "Tax Expiry Date is Required")]
        //public string TAXExpiryDate { get; set; }

        [DisplayName("Transmission Type")]
        public int TransmissionTypeID { get; set; }

        [DisplayName("Fuel Type")]
        public int FuelTypeID { get; set; }

        public int ServiceTypeID { get; set; }
        public int InteriorTrimID { get; set; }

        [DisplayName("Date of First Registration")]
        [Required(ErrorMessage = "Date of First Registration is Required")]
        public string DateOfFirstRegistration { get; set; }

        public string NewCarModelName { get; set; }

        public string NewCarMakeName { get; set; }

        public string interiorTrimIDs { get; set; }

        public string FuelTypeIDs { get; set; }
        public string TransmissionTypeIDs { get; set; }
        public string serviceTypeIDs { get; set; }

        public bool IsImported { get; set; }
        public bool IsFullVSProvided { get; set; }
        public bool IsHPIClear { get; set; }
        public bool IsVCARregistered { get; set; }

        public long AuctionHouseVehicleID { get; set; }

        public string Filename { get; set; }
        public string Foldername { get; set; }
        public long Size { get; set; }

        [Required(ErrorMessage = "Sale Date is Required")]
        public string NewSaleDate { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        public string ErrMsg { get; set; }
        public string ErrMsgType { get; set; }



    }
    public class CheckBoxClassFuelType
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }

    public class CheckBoxClassTransmission
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }
    public class CheckBoxService
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }

    public class CheckBoxInteriorTrim
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }

    public class CheckBoxImported
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }
    public class CheckBoxFullVSProvided
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }
    public class CheckBoxVCARregistered
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }

    public class CheckBoxHPIClear
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public bool Checked { get; set; }
    }
}