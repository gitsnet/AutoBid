using Core.Data;
using Core.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seller
{
    public partial class SellerCompanyLogoService : ISellerCompanyLogoService
    {
        private readonly IRepository<SellerCompanyLogo> _sellerCompanyLogoRepository;

        public SellerCompanyLogoService(IRepository<SellerCompanyLogo> sellerCompanyLogoRepository)
        {
            _sellerCompanyLogoRepository = sellerCompanyLogoRepository;
        }


        public void InsertSellerCompanyLogo(SellerCompanyLogo sellerCompanyLogo)
        {
            if (sellerCompanyLogo == null)
                throw new ArgumentNullException("SellerCompanyLogo");
            _sellerCompanyLogoRepository.Insert(sellerCompanyLogo);
        }

        public void UpdateSellerCompanyLogo(SellerCompanyLogo sellerCompanyLogo)
        {
            if (sellerCompanyLogo == null)
                throw new ArgumentNullException("SellerCompanyLogo");
            _sellerCompanyLogoRepository.Update(sellerCompanyLogo);
        }

        
    }
}
