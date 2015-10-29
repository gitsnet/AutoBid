using Core.CarSeller;
using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class FuelType : BaseEntity
    {
        public FuelType()
        {
            this.CarSellerVehicleFuelTypes = new List<CarSellerVehicleFuelType>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CarSellerVehicleFuelType> CarSellerVehicleFuelTypes { get; set; }
    }
}
