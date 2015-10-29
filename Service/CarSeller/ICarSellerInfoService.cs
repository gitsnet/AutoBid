using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
    public partial interface ICarSellerInfoService
    {
        #region:CarSellerType
        IList<CarSellerInfo> GetAllCarSellerInfo();
        void InsertCarSellerInfo(CarSellerInfo carSellerInfo);
        void UpdateCarSellerInfo(CarSellerInfo carSellerInfo);
        CarSellerInfo GetCarSellerInfoByCarSellerInfoID(int CarSellerInfoID);
        #endregion
    }
}
