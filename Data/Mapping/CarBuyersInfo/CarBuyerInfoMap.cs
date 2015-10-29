using Core.CarBuyer;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping.CarBuyersInfo
{
    public partial class CarBuyerInfoMap : EntityTypeConfiguration<CarBuyerInfo>
    {
        public CarBuyerInfoMap()
        {
            this.ToTable("CarBuyerInfo");


            this.HasKey(c => c.ID);


            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.BuyDate).HasColumnName("BuyDate");
            this.Property(t => t.BuyingPrice).HasColumnName("BuyingPrice");
            this.Property(t => t.IsBrought).HasColumnName("IsBrought");
            this.Property(t => t.IsShortlisted).HasColumnName("IsShortlisted");
            this.Property(t => t.IsOfferMade).HasColumnName("IsOfferMade");
            this.Property(t => t.OfferMadePrice).HasColumnName("OfferMadePrice");
            this.Property(t => t.ActionID).HasColumnName("ActionID");

            // Relationships
            this.HasRequired(t => t.CarSellerVehicleInfo)
                .WithMany(t => t.CarBuyerInfo)
                .HasForeignKey(d => d.VehicleID);



            //this.HasOptional(t => t.CarSellerInfo)
            //    .WithMany(t => t.CarBuyerInfo)
            //    .HasForeignKey(d => d.UserID);
        }
    }
}
