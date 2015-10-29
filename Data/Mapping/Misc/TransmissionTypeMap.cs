using Core.Misc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class TransmissionTypeMap : EntityTypeConfiguration<TransmissionType>
    {
        public TransmissionTypeMap()
        {
           
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TransmissionTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
        }
    }
}
