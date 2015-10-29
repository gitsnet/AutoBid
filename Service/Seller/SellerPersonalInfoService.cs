using Core.Data;
using Core.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seller
{
    public partial class SellerPersonalInfoService : ISellerPersonalInfoService
    {
        private readonly IRepository<SellerPersonalInfo> _sellerPersonalInfoRepository;

        public SellerPersonalInfoService(IRepository<SellerPersonalInfo> sellerPersonalInfoRepository)
        {
            _sellerPersonalInfoRepository = sellerPersonalInfoRepository;
        }


        public void InsertSellerPersonalInfo(SellerPersonalInfo sellerPersonalInfo)
        {
            if (sellerPersonalInfo == null)
                throw new ArgumentNullException("SellerPersonalInfo");
            _sellerPersonalInfoRepository.Insert(sellerPersonalInfo);
        }

        public void UpdateSellerPersonalInfo(SellerPersonalInfo sellerPersonalInfo)
        {
            if (sellerPersonalInfo == null)
                throw new ArgumentNullException("SellerPersonalInfo");
            _sellerPersonalInfoRepository.Update(sellerPersonalInfo);
        }

        public SellerPersonalInfo GetPersonalInformationByUserID(int userId)
        {
            return _sellerPersonalInfoRepository.Table.Where<SellerPersonalInfo>(t => t.UserID == userId).FirstOrDefault<SellerPersonalInfo>();
        }
    }
}
