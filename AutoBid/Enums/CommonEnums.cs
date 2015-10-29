using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBid.Enums
{
    public enum SalutationList
    {
        [Description("Mr.")]
        Mr = 0,
        [Description("Mrs.")]
        Mrs = 1,
    }
    public enum FuelTypeList
    {
        [Description("Petrol")]
        Petrol = 0,
        [Description("Diesel")]
        Diesel = 1,
        [Description("Bi-Fuel")]
        BiFuel = 2,
        [Description("LPG")]
        LPG = 3,
    }

    public enum TransmissionTypeList
    {

        [Description("Automatic")]
        Automatic = 0,
        [Description("Manual")]
        Manual = 1,
        [Description("Semi-Auto")]
        SemiAuto = 2,

    }
    [Flags]
    public enum InteriorTrimList
    {
        [Description("Textured")]
        Textured = 0,
        [Description("Cloth")]
        Cloth = 1,
        [Description("Leather")]
        Leather = 2,
    }
    [Flags]
    public enum ServiceHistoryAuctionList
    {
        [Display(Name="Full Main Dealer")]
        Full_Main_Dealer = 0,
        [Display(Name = "Full")]
        Full = 1,
        [Display(Name = "Part")]
        Part = 2,
    }
}