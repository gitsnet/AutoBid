using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auction
{
   public partial class AuctionHouseCarSellingVehicleImages:BaseEntity
    {
       public long AuctionHouseCarSellingVehicleImagesID { get; set; }
        public Nullable<long> AuctionHouseCarSellingID { get; set; }
        
        
        public string Filename { get; set; }
        public string Foldername { get; set; }
        public Nullable<int> Size { get; set; }
        public virtual AuctionHouseCarSelling AuctionHouseCarSelling { get; set; }
       
        
    }
}
