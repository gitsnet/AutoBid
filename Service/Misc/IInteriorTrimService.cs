using System.Collections.Generic;
using Core.Misc;

namespace Service.Misc
{
    public partial interface IInteriorTrimService
    {
        IList<InteriorTrim> GetAllInteriorTrims();
    }
}
