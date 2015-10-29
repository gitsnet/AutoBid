﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Models.CarBuyer
{
    public class CarBuyerPersonalInfoModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string PostalCode { get; set; }
    }
}