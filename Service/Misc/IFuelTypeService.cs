using Core.Misc;
using System.Collections.Generic;
using System.Linq;

namespace Service.Misc
{
    public partial interface IFuelTypeService
    {
        #region:FuelType
        IList<FuelType> GetAllFuelTypes();
        IQueryable<FuelType> GeFuelTypeQueryable();
      #endregion
  }
}
