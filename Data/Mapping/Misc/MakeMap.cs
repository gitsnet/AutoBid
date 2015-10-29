using Core.Misc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class MakeMap : EntityTypeConfiguration<Make>
    {
        public MakeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Makename)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Makes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Makename).HasColumnName("Makename");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
        }
    }
}
