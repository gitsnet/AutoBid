using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellerVehicleImageMap : EntityTypeConfiguration<CarSellerVehicleImage>
    {
        public CarSellerVehicleImageMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(100);

            this.Property(t => t.UploadedFromIP)
                .HasMaxLength(50);

            this.Property(t => t.TempID)
                .HasMaxLength(100);

            this.Property(t => t.SectionFromImageUploaded)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CarSellerVehicleImages");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.ImageSizeID).HasColumnName("ImageSizeID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.OriginalFilename).HasColumnName("OriginalFilename");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Foldername).HasColumnName("Foldername");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.UploadedOn).HasColumnName("UploadedOn");
            this.Property(t => t.UploadedFromIP).HasColumnName("UploadedFromIP");
            this.Property(t => t.UploadedByUserID).HasColumnName("UploadedByUserID");
            this.Property(t => t.TempID).HasColumnName("TempID");
            this.Property(t => t.SectionFromImageUploaded).HasColumnName("SectionFromImageUploaded");
            this.Property(t => t.PositionID).HasColumnName("PositionID");
            this.HasOptional(t => t.CarSellerVehicleInfo)
               .WithMany(t => t.CarSellerVehicleImages)
                .HasForeignKey(d => d.VehicleID);
        }
    }
}
