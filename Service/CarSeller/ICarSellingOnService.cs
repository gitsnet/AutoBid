using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
   public partial interface ICarSellingOnService
   {
       #region:CarSellingOn
       IList<CarSellingOn> GetAllCarSellinOn();
       #endregion
   }
}
