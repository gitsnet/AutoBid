using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellerPackageMap : EntityTypeConfiguration<CarSellerPackage>
    {
        public CarSellerPackageMap()
        {
           
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Package)
                .IsRequired();

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CarSellerPackages");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Package).HasColumnName("Package");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
