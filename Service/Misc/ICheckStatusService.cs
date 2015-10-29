using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;

namespace Service.Misc
{
    public partial interface ICheckStatusService
    {
        IList<CheckStatus> GetAllCheckStatus();
    }
}
