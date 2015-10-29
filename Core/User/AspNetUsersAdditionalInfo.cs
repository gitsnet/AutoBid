using Core.CarSeller;
using Core.Seller;
using System;
using System.Collections.Generic;

namespace Core.User
{
    public partial class AspNetUsersAdditionalInfo : BaseEntity
    {
        public AspNetUsersAdditionalInfo()
        {
            this.AspNetUsersANDUserTypesMappings = new List<AspNetUsersANDUserTypesMapping>();
            this.CarSellerInfoes = new List<CarSellerInfo>();
            this.SellerCompanyInfoes = new List<SellerCompanyInfo>();
            this.SellerPersonalInfoes = new List<SellerPersonalInfo>();
            this.SellerCardDetails = new List<SellerCardDetail>();
        }

        public int ID { get; set; }
        public string UserKey { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedFromIP { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
        public Nullable<int> SellerTypeID { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<AspNetUsersANDUserTypesMapping> AspNetUsersANDUserTypesMappings { get; set; }
        public virtual ICollection<CarSellerInfo> CarSellerInfoes { get; set; }
        public virtual ICollection<SellerCompanyInfo> SellerCompanyInfoes { get; set; }
        public virtual ICollection<SellerPersonalInfo> SellerPersonalInfoes { get; set; }
        public virtual ICollection<SellerCardDetail> SellerCardDetails { get; set; }
    }
}
