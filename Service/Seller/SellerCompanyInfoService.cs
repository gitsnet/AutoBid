using Core.Data;
using Core.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seller
{
    public partial class SellerCompanyInfoService : ISellerCompanyInfoService
    {
        private readonly IRepository<SellerCompanyInfo> _sellerCompanyInfoRepository;

        public SellerCompanyInfoService(IRepository<SellerCompanyInfo> sellerCompanyInfoRepository)
        {
            _sellerCompanyInfoRepository = sellerCompanyInfoRepository;
        }


        public void InsertSellerCompanyInfo(SellerCompanyInfo sellerCompanyInfo)
        {
            if (sellerCompanyInfo == null)
                throw new ArgumentNullException("SellerCompanyInfo");
            _sellerCompanyInfoRepository.Insert(sellerCompanyInfo);
        }

        public void UpdateSellerCompanyInfo(SellerCompanyInfo sellerCompanyInfo)
        {
            if (sellerCompanyInfo == null)
                throw new ArgumentNullException("SellerCompanyInfo");
            _sellerCompanyInfoRepository.Update(sellerCompanyInfo);
        }

       
    }
}
