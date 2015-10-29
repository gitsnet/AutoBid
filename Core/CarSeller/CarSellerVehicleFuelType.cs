using Core.Misc;
using System;
using System.Collections.Generic;

namespace Core.CarSeller
{
    public partial class CarSellerVehicleFuelType : BaseEntity
    {
       
        public int ID { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public Nullable<int> FuelTypeID { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual CarSellerVehicleInfo CarSellerVehicleInfo { get; set; }
    }
}
