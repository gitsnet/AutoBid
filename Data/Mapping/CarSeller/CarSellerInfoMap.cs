using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellerInfoMap : EntityTypeConfiguration<CarSellerInfo>
    {
        public CarSellerInfoMap()
        {
            
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CarSellerInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.SellerTypeID).HasColumnName("SellerTypeID");
            this.Property(t => t.WayOfSelling).HasColumnName("WayOfSelling");

            // Relationships
            this.HasRequired(t => t.AspNetUsersAdditionalInfo)
                .WithMany(t => t.CarSellerInfoes)
                .HasForeignKey(d => d.UserID);
            this.HasOptional(t => t.CarSellerType)
                .WithMany(t => t.CarSellerInfoes)
                .HasForeignKey(d => d.SellerTypeID);
            this.HasOptional(t => t.CarSellingOn)
                .WithMany(t => t.CarSellerInfoes)
                .HasForeignKey(d => d.WayOfSelling);

        }
    }
}
