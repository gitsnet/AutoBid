using Core.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Company
{
    public partial interface ICompanyTypeService
    {
        #region CompanyType


        CompanyType GetCompanyTypeById(long CompanyTypeId);
        IList<CompanyType> GetAllCompanyType();       

        #endregion
    }
}
