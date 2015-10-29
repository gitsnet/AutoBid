using Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Misc
{
  public partial  interface IMakeService
  {
      #region:Make
      IList<Make> GetAllMakes();
      IQueryable<Make> GetMakesQueryable();
      Make GetMakeByName(string MakeName);
      void InsertMake(Make make);
      #endregion
  }
}
