using Core.Misc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Cities");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
        }
    }
}
