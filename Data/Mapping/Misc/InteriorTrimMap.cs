using Core.Misc;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Misc
{
    public class InteriorTrimMap : EntityTypeConfiguration<InteriorTrim>
    {
        public InteriorTrimMap()
        {
            this.ToTable("InteriorTrim");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
