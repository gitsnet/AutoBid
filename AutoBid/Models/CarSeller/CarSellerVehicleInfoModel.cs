using Core.CarSeller;
using Core.Misc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoBid.Models.CarSeller
{
    public class CarSellerVehicleInfoModel
    {
        public List<Make> MakeList { get; set; }
        public List<CarModel> CarModelList { get; set; }
        public List<BodyType> BodyTypeList { get; set; }
        public List<TransmissionType> TransmissionTypeList { get; set; }
        public List<CheckBoxClass> FuelTypeList { get; set; }
        public List<FuelType> FuelTypeSelected { get; set; }
        public IList<CarSellerVehicleImage> CarSellerVehicleImageList { get; set; }
        public List<CarSellerVehicleInfo> CarSellerVehicleInfoList { get; set; }
       
        public CarSellerVehicleInfoModel()
        {
            MakeList = new List<Make>();
            CarModelList = new List<CarModel>();
            BodyTypeList = new List<BodyType>();
            TransmissionTypeList = new List<TransmissionType>();
            FuelTypeList = new List<CheckBoxClass>();
            FuelTypeSelected = new List<FuelType>();
            CarSellerVehicleInfoList = new List<CarSellerVehicleInfo>();
           // CarSellerVehicleImageList = new IList<CarSellerVehicleImage>();
           
        }
        public int ID { get; set; }
        [Required]
        public int CarSellerInfoID { get; set; }

        [DisplayName("Registration number")]
        [Required(ErrorMessage = "Registration Number is required.")]
        public string RegistrationNumber { get; set; }


        [DisplayName("Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }


        [DisplayName("EngineSize")]
        [Required(ErrorMessage = "EngineSize is required.")]
        public string EngineSize { get; set; }

        [DisplayName("Make")]
        [Required(ErrorMessage = "Car Make is Required")]
        public int MakeID { get; set; }

        [DisplayName("Model")]
        public int ModelID { get; set; }
        [DisplayName("Model")]
        public string ModelName { get; set; }

        [DisplayName("Body")]
        [Required(ErrorMessage = "Body Type is Required")]
        public int BodyTypeID { get; set; }


        [DisplayName("Color")]
        [Required(ErrorMessage = "Color is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Color { get; set; }

        [DisplayName("MOT Expiry Date")]
        [Required(ErrorMessage = "MOT Expiry Date is Required")]
        public string MOTExpiryDate { get; set; }

        [DisplayName("Transmission Type")]
        public int TransmissionTypeID { get; set; }

        [DisplayName("Exact Mileage")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        [Required(ErrorMessage = "Mileage is Required")]
        public string ExactMileage { get; set; }

        [DisplayName("Interior Color & Trim")]
        [Required(ErrorMessage = "Interior Color is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string InteriorColor { get; set; }

       
        public string Trim { get; set; }

        [DisplayName("Tax Expiry Date")]
        [Required(ErrorMessage = "Tax Expiry Date is Required")]
        public string TAXExpiryDate { get; set; }

        [DisplayName("Service History")]
        public string ServiceHistory { get; set; }

        [DisplayName("Fuel Type")]
        public int FuelTypeID { get; set; }

        [DisplayName("Description")]
         public string Description { get; set; }

        [Required]
        [DisplayName("Price")]
        public string Price { get; set; }

        [DisplayName("Date of First Registration")]
        [Required(ErrorMessage = "Date of First Registration is Required")]
        public string DateOfFirstRegistration { get; set; }

        public string NewCarModelName { get; set; }

        public string NewCarMakeName { get; set; }


        public int VehicleID { get; set; }


        [DisplayName("Where is the car located?")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Car Location is Required")]
        public string CarLocation { get; set; }

        [DisplayName("Contact Email")]
        [Required(ErrorMessage = "Contact Email is Required")]
        [EmailAddress]
        public string ContactEmailID { get; set; }

        [DisplayName("Contact Number on Advert")]
        [Required(ErrorMessage = "Contact Number on Advert is Required")]
        public string ContactNumberOnAdvert { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Contact Number is Required")]
        public string ContactNumber { get; set; }
        public int SelectedPackageID { get; set; }



       
        public int CarSellerVehicleImagesID { get; set; }
        public string OriginalFilename { get; set; }
        public string Filename { get; set; }
        public string Foldername { get; set; }
        public long Size { get; set; }
        public string UploadedOn { get; set; }
        public string UploadedFromIP { get; set; }
        public string SectionFromImageUploaded { get; set; }
        public string TempID { get; set; }




    }
    public class CheckBoxClass {
        public string Name { get; set; }
        public string ID { get; set; }
        public bool IsChecked { get; set; }
    }
}