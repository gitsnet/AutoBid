using Core.CarSeller;
using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class MIMEType : BaseEntity
    {
        public MIMEType()
        {
            this.CarSellerDocuments = new List<CarSellerDocument>();
        }

        public int ID { get; set; }
        public string MIME { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CarSellerDocument> CarSellerDocuments { get; set; }
    }
}
