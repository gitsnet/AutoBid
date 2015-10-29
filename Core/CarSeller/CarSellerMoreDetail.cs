using System;
using System.Collections.Generic;

namespace Core.CarSeller
{
    public partial class CarSellerMoreDetail : BaseEntity
    {
        public int ID { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public virtual string CarLocation { get; set; }
        public string ContactEmailID { get; set; }
        public string ContactNumberOnAdvert { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<int> SelectedPackageID { get; set; }
        public virtual CarSellerPackage CarSellerPackage { get; set; }
        public virtual CarSellerVehicleInfo CarSellerVehicleInfo { get; set; }
    }
}
