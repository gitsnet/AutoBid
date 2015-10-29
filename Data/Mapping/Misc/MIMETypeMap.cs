using Core.Misc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class MIMETypeMap : EntityTypeConfiguration<MIMEType>
    {
        public MIMETypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.MIME)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("MIMETypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MIME).HasColumnName("MIME");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
