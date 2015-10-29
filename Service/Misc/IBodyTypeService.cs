using Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Misc
{
  public partial  interface IBodyTypeService
  {
      #region:BodyType
      IList<BodyType> GetAllBodyTypes();
      #endregion
  }
}
