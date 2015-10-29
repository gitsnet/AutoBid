using Core.CarBuyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarBuyer
{
    public partial interface ICarBuyerInfoService
    {
        #region CarBuyerInfo

        IQueryable<CarBuyerInfo> GetAllCarBuyerQueryable();
        IList<CarBuyerInfo> GetAllCarBuyer();
        CarBuyerInfo GetCarBuyerInfoByID(int id);

        #endregion
    }
}
