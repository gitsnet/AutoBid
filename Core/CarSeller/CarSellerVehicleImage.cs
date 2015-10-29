using System;
using System.Collections.Generic;

namespace Core.CarSeller
{
    public partial class CarSellerVehicleImage : BaseEntity
    {
        public int ID { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public Nullable<int> ImageSizeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OriginalFilename { get; set; }
        public string Filename { get; set; }
        public string Foldername { get; set; }
        public Nullable<int> Size { get; set; }
        public Nullable<System.DateTime> UploadedOn { get; set; }
        public string UploadedFromIP { get; set; }
        public Nullable<int> UploadedByUserID { get; set; }
        public string TempID { get; set; }
        public string SectionFromImageUploaded { get; set; }
        public Nullable<int> PositionID { get; set; }
        public virtual CarSellerVehicleInfo CarSellerVehicleInfo { get; set; }
    }
}
