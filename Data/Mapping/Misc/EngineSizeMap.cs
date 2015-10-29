using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Misc
{
    class EngineSizeMap : EntityTypeConfiguration<EngineSize>
    {
        public EngineSizeMap()
        {
            this.ToTable("EngineSize");
            this.Property(t => t.ID).HasColumnName("EngineSizeID");
            this.Property(t => t.EngineSizeName).HasColumnName("EngineSizeName");
        }
    }
}
