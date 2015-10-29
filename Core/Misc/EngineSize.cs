using Core.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Misc
{
   public partial class EngineSize:BaseEntity
    {
        public long ID { get; set; }
        public string EngineSizeName { get; set; }
        public virtual ICollection<AuctionHouseCarSelling> AuctionHouseCarSellings { get; set; }
    }
}
