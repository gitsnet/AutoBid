using Core.CoreSeller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class SaleDateMap : EntityTypeConfiguration<SaleDate>
    {
        public SaleDateMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SaleDates");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.VehicleSaleDate).HasColumnName("VehicleSaleDate");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
