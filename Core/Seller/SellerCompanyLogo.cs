using System;
using System.Collections.Generic;

namespace Core.Seller
{
    public partial class SellerCompanyLogo : BaseEntity
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> ImageSizeID { get; set; }
        public string OriginalFilename { get; set; }
        public string Filename { get; set; }
        public string FolderPath { get; set; }
        public string TempID { get; set; }
        public Nullable<System.DateTime> UploadedOn { get; set; }
    }
}
