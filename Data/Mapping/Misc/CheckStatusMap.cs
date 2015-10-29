using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Misc
{
   public  class CheckStatusMap:EntityTypeConfiguration<CheckStatus>
    {
       public CheckStatusMap()
       {
           this.ToTable("CheckStatus");
           this.HasKey(t => t.ChkID);
           this.Property(t => t.Type).HasColumnName("Type");
           this.Property(t => t.Text).HasColumnName("Text");
       }

    }
}
