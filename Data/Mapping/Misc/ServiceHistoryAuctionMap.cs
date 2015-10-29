using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Misc
{
    public class ServiceHistoryAuctionMap : EntityTypeConfiguration<ServiceHistoryAuction>
    {
        public ServiceHistoryAuctionMap()
        {
            this.ToTable("ServiceHistoryAuction");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
