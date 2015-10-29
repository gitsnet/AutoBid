using Core.Seller;
using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seller
{
    public partial interface ISellerCompanyInfoService
    {
        #region SellerCompanyInfo
        void InsertSellerCompanyInfo(SellerCompanyInfo sellerCompanyInfo);
        void UpdateSellerCompanyInfo(SellerCompanyInfo sellerCompanyInfo);
       
        #endregion
    }
}
