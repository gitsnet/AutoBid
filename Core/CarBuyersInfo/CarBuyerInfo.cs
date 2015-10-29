using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarBuyer
{
    public partial class CarBuyerInfo : BaseEntity
    {
        public CarBuyerInfo()
        {

        }
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int VehicleID { get; set; }
        public virtual DateTime BuyDate { get; set; }
        public virtual decimal BuyingPrice { get; set; }
        public virtual bool IsBrought { get; set; }
        public virtual bool IsShortlisted { get; set; }
        public virtual bool IsOfferMade { get; set; }
        public virtual decimal OfferMadePrice { get; set; }
        public virtual int ActionID { get; set; }
        public virtual CarSellerVehicleInfo CarSellerVehicleInfo { get; set; }
       
        //public virtual CarSellerInfo CarSellerInfo { get; set; }
    }
}
