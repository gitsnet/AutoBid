using Core.Misc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CarModelMap : EntityTypeConfiguration<CarModel>
    {
        public CarModelMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Modelname)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Models");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MakeID).HasColumnName("MakeID");
            this.Property(t => t.Modelname).HasColumnName("Modelname");
        }
    }
}
