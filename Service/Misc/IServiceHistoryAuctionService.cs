﻿using System.Collections.Generic;
using Core.Misc;

namespace Service.Misc
{
    public  partial interface IServiceHistoryAuctionService
    {
        IList<ServiceHistoryAuction> GetAllServiceHistoryAuctions();
    }
}
