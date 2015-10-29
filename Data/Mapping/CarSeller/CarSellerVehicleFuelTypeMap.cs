using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellerVehicleFuelTypeMap : EntityTypeConfiguration<CarSellerVehicleFuelType>
    {
        public CarSellerVehicleFuelTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CarSellerVehicleFuelTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.FuelTypeID).HasColumnName("FuelTypeID");

            // Relationships
            this.HasOptional(t => t.FuelType)
                .WithMany(t => t.CarSellerVehicleFuelTypes)
                .HasForeignKey(d => d.FuelTypeID);

            this.HasOptional(t => t.CarSellerVehicleInfo)
               .WithMany(t => t.CarSellerVehicleFuelTypes)
               .HasForeignKey(d => d.VehicleID);
          

        }
    }
}
