using AutoBid.Enums;
using Core.Misc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoBid.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public List<Country> CountryList { get; set; }
        public List<SelectListItem> CarSellerTypeList { get; set; }
        public List<SelectListItem> CompanyTypeList { get; set; }
        public RegisterViewModel()
        {
            CountryList = new List<Country>();
            CarSellerTypeList = new List<SelectListItem>();
            CompanyTypeList = new List<SelectListItem>();
        }
        [Required]
        [Display(Name = "Car Seller Type")]
        public string CarSellerTypeID { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Title")]
        public SalutationList Salutation { get; set; }
        
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Contact No")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }


        [Required]
        [Display(Name = "Company Type")]
        public string CompanyTypeID { get; set; }

       
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

       
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }

        
        public string CountryName { get; set; }

        [Required]
        [Display(Name = "Company Postal Code")]
        public string CompanyPostalCode { get; set; }

         [Required]
         [Display(Name = "Country")]
         public string CountryID { get; set; }

        
         [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Contact Number is Required")]
         public string CompanyContact { get; set; }

         [Display(Name = "2nd Number")]
         public string CompanyContact2 { get; set; }

         [Display(Name = "3rd Number")]
         public string CompanyContact3 { get; set; }


         [Required]
         [Display(Name = "Company Number")]
         [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
         public string CompanyNumber { get; set; }

        
         [Display(Name = "VAT Number")]
         [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
         [Required(ErrorMessage = "VAT Number is Required")]
         public string VATNumber { get; set; }

        [Display(Name = "Year of Foundation")]
        public string YearofFoundation { get; set; }

        
        public string CompanyLogo { get; set; }
        

        [Display(Name = "No of Employee")]
        public string NoOfEmployee { get; set; }

        [Display(Name = "Turn Over")]
        public string TurnOver { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Receive Email Notification")]
        public bool ReceiveEmailNotification { get; set; }
    }
}
