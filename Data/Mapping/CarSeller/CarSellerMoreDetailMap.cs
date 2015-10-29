using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellerMoreDetailMap : EntityTypeConfiguration<CarSellerMoreDetail>
    {
        public CarSellerMoreDetailMap()
        {
            
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CarLocation)
                .HasMaxLength(50);

            this.Property(t => t.ContactNumberOnAdvert)
                .HasMaxLength(50);

            this.Property(t => t.ContactNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CarSellerMoreDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.CarLocation).HasColumnName("CarLocation");
            this.Property(t => t.ContactEmailID).HasColumnName("ContactEmailID");
            this.Property(t => t.ContactNumberOnAdvert).HasColumnName("ContactNumberOnAdvert");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.SelectedPackageID).HasColumnName("SelectedPackageID");

            // Relationships
            this.HasOptional(t => t.CarSellerPackage)
                .WithMany(t => t.CarSellerMoreDetails)
                .HasForeignKey(d => d.SelectedPackageID);
            this.HasOptional(t => t.CarSellerVehicleInfo)
                .WithMany(t => t.CarSellerMoreDetails)
                .HasForeignKey(d => d.VehicleID);

        }
    }
}
