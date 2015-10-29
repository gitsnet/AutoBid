using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Misc
{
  public partial  class CheckStatus:BaseEntity
    {
      public virtual long ChkID{get;set;}
      public virtual bool Type { get; set; }
      public virtual string Text { get; set; }
    }
}
