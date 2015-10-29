using Core.Seller;
using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seller
{
    public partial interface ISellerCompanyLogoService
    {
        #region SellerCompanyLogo
        void InsertSellerCompanyLogo(SellerCompanyLogo sellerCompanyLogo);
        void UpdateSellerCompanyLogo(SellerCompanyLogo sellerCompanyLogo);
        #endregion
    }
}
