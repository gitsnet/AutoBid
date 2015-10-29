using System;
using System.Collections.Generic;

namespace Core.CarSeller
{
    public partial class CarSellerType : BaseEntity
    {
        public CarSellerType()
        {
            this.CarSellerInfoes = new List<CarSellerInfo>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CarSellerInfo> CarSellerInfoes { get; set; }
    }
}
