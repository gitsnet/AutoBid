using System;
using System.Collections.Generic;

namespace Core.CarSeller
{
    public partial class CarSellingOn : BaseEntity
    {
        public CarSellingOn()
        {
            this.CarSellerInfoes = new List<CarSellerInfo>();
        }

        public int ID { get; set; }
        public string Way { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CarSellerInfo> CarSellerInfoes { get; set; }
    }
}
