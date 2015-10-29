using Core.CarSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarSellingOnMap : EntityTypeConfiguration<CarSellingOn>
    {
        public CarSellingOnMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Way)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CarSellingOn");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Way).HasColumnName("Way");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
