using Core.CarSeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarSeller
{
    public partial interface ICarSellerTypeService
    {
        #region:CarSellerType
        IList<CarSellerType> GetAllCarSellerType();
        IQueryable<CarSellerType> GetCarSellerTypeQueryable();
        
        #endregion
    }
}
