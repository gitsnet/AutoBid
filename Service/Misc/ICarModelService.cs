using Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Misc
{
  public partial  interface ICarModelService
  {
      #region:CarModel
      IList<CarModel> GetAllCarModels();
      void InsertCarModel(CarModel carModel);
      IQueryable<CarModel> GeModelsQueryable();
      CarModel GetCarModelByName(string CarModelName);
      #endregion
  }
}
