using Core.Auction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AutoBid.Models.Auction
{
    public class AuctionHouseModel
    {
        public long AuctionHouseID { get; set; }

        [Required(ErrorMessage = "Auction House Name is required.")]
        public string AuctionHouseName { get; set; }

         [Required(ErrorMessage = "Logo is required.")]
        public string Logo { get; set; }

       
        public string WebSite { get; set; }

        
        public string Email { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required (ErrorMessage = "Postal Code is required.")]
        public string PostalCode { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        [Required (ErrorMessage = "Description is required.")]
        public string About { get; set; }

        [Required(ErrorMessage = "Buyer Fees is required.")]
       //[Range(1, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        public string Buyer_Fees { get; set; }

        public string TermsCondition { get; set; }

        public string SalesCommission { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Sale Date is required.")]
        [RegularExpression(@"(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Use dd/mm/yyyy format please")]
        public string SaleDate { get; set; }
        public int CarCount { get; set; }

        public List<AuctionHouseSale> AuctionHouseSaleList { get; set; }
        public List<AuctionHouseCarSelling> AuctionHouseCarSellingList { get; set; }
    }

    public class AuctionHouseModelSaleDate
    {
        public string SaleDate { get; set; }
        public long AuctionHouseSaleID { get; set; }
    }
} 