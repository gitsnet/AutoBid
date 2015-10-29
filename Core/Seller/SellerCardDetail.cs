using Core.User;
using System;
using System.Collections.Generic;

namespace Core.Seller
{
    public partial class SellerCardDetail : BaseEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string PostalCode { get; set; }
        public string CardNumber { get; set; }
        public string BillingAddress { get; set; }
        public Nullable<bool> LikeToReceiveMarketingProducts { get; set; }
        public virtual AspNetUsersAdditionalInfo AspNetUsersAdditionalInfo { get; set; }
    }
}
