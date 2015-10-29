using System;
using System.Collections.Generic;

namespace Core.Auction
{
    public partial class AuctionHouse:BaseEntity
    {
        public AuctionHouse()
        {
            this.AuctionHouseCarSellings = new List<AuctionHouseCarSelling>();
            this.AuctionHouseSales = new List<AuctionHouseSale>();
        }

        public long AuctionHouseID { get; set; }
        public Nullable<long> UserID { get; set; }
        public string AuctionHouseName { get; set; }
        public string Logo { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string About { get; set; }
        public string Buyer_Fees { get; set; }
        public string TermsCondition { get; set; }
        public string SalesCommission { get; set; }
        public virtual ICollection<AuctionHouseCarSelling> AuctionHouseCarSellings { get; set; }
        public virtual ICollection<AuctionHouseSale> AuctionHouseSales { get; set; }
    }
}
