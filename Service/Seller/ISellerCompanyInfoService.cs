using Core.Seller;
using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seller
{
    public partial interface ISellerPersonalInfoService
    {
        #region SellerPersonalInfo        
        void InsertSellerPersonalInfo(SellerPersonalInfo sellerPersonalInfo);
        void UpdateSellerPersonalInfo(SellerPersonalInfo sellerPersonalInfo);
        SellerPersonalInfo GetPersonalInformationByUserID(int userId);
        #endregion
    }
}
