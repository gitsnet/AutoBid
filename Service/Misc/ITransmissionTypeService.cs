using Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Misc
{
    public partial interface ITransmissionTypeService
    {
        #region:TransmissionType
        IList<TransmissionType> GetAllTransmissionTypes();
        IQueryable<TransmissionType> GeTransmissionTypeQueryable();
      #endregion
  }
}
