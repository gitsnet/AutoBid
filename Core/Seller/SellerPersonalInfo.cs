using Core.User;
using System;
using System.Collections.Generic;

namespace Core.Seller
{
    public partial class SellerPersonalInfo : BaseEntity
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }       
        public string ContactNo { get; set; }
        public string PostalCode { get; set; }
        public virtual AspNetUsersAdditionalInfo AspNetUsersAdditionalInfo { get; set; }
    }
}
