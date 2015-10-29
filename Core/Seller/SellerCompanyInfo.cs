using Core.User;
using System;
using System.Collections.Generic;

namespace Core.Seller
{
    public partial class SellerCompanyInfo : BaseEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CompanyTypeID { get; set; }
        public string CompanyName { get; set; }
        public string Address001 { get; set; }
        public string Address002 { get; set; }
        public string Address003 { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string PostalCode { get; set; }
        public string ContactNumbers { get; set; }
        public string CompanyNumber { get; set; }
        public string VatNumber { get; set; }
        public Nullable<int> YearOfFoundation { get; set; }
        public Nullable<int> NoOfEmployees { get; set; }
        public Nullable<decimal> TurnOver { get; set; }
        public int CategoryID { get; set; }
        public virtual AspNetUsersAdditionalInfo AspNetUsersAdditionalInfo { get; set; }
    }
}
