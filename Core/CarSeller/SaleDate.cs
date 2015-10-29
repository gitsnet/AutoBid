using System;
using System.Collections.Generic;

namespace Core.CoreSeller
{
    public partial class SaleDate : BaseEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public System.DateTime VehicleSaleDate { get; set; }
        public string Description { get; set; }
    }
}
