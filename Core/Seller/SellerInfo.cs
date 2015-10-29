using System;
using System.Collections.Generic;

namespace Core.Seller
{
    public partial class SellerInfo : BaseEntity
    {
        public int ID { get; set; }
        public string UserKey { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address001 { get; set; }
        public string Address002 { get; set; }
        public string Address003 { get; set; }
        public string ContactNo { get; set; }
        public string PostalCode { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedFromIP { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
        public Nullable<int> SellerTypeID { get; set; }
    }
}
