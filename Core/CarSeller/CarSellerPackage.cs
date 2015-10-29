using System;
using System.Collections.Generic;

namespace Core.CarSeller
{
    public partial class CarSellerPackage : BaseEntity
    {
        public CarSellerPackage()
        {
            this.CarSellerMoreDetails = new List<CarSellerMoreDetail>();
        }

        public int ID { get; set; }
        public string Package { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CarSellerMoreDetail> CarSellerMoreDetails { get; set; }
    }
}
