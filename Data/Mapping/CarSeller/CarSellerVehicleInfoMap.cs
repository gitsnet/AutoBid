using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellerVehicleInfoMap : EntityTypeConfiguration<CarSellerVehicleInfo>
    {
        public CarSellerVehicleInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Color)
                .HasMaxLength(50);

            this.Property(t => t.ExactMileage)
                .HasMaxLength(50);

            this.Property(t => t.InteriorColor)
                .HasMaxLength(50);

            this.Property(t => t.Trim)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CarSellerVehicleInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CarSellerInfoID).HasColumnName("CarSellerInfoID");
            this.Property(t => t.RegistrationNumber).HasColumnName("RegistrationNumber");
            this.Property(t => t.MakeID).HasColumnName("MakeID");
            this.Property(t => t.ModelID).HasColumnName("ModelID");
            this.Property(t => t.BodyTypeID).HasColumnName("BodyTypeID");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.MOTExpiryDate).HasColumnName("MOTExpiryDate");
            this.Property(t => t.TransmissionTypeID).HasColumnName("TransmissionTypeID");
            this.Property(t => t.ExactMileage).HasColumnName("ExactMileage");
            this.Property(t => t.InteriorColor).HasColumnName("InteriorColor");
            this.Property(t => t.Trim).HasColumnName("Trim");
            this.Property(t => t.TAXExpiryDate).HasColumnName("TAXExpiryDate");
            this.Property(t => t.ServiceHistory).HasColumnName("ServiceHistory");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.DateOfFirstRegistration).HasColumnName("DateOfFirstRegistration");
            this.Property(t => t.EngineSize).HasColumnName("EngineSize");

            this.Property(t => t.IsSendToAuction).HasColumnName("IsSendToAuction");

            // Relationships
            this.HasOptional(t => t.BodyType)
                .WithMany(t => t.CarSellerVehicleInfoes)
                .HasForeignKey(d => d.BodyTypeID);
            this.HasRequired(t => t.CarSellerInfo)
                .WithMany(t => t.CarSellerVehicleInfoes)
                .HasForeignKey(d => d.CarSellerInfoID);
            this.HasOptional(t => t.TransmissionType)
                .WithMany(t => t.CarSellerVehicleInfoes)
                .HasForeignKey(d => d.TransmissionTypeID);

        }
    }
}
