using Core.Company;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Company
{
    public partial class CompanyTypeService : ICompanyTypeService
    {
        private readonly IRepository<CompanyType> _companyTypeRepository;

        public CompanyTypeService(IRepository<CompanyType> companyTypeRepository)
        {
            _companyTypeRepository = companyTypeRepository;
        }

        public CompanyType GetCompanyTypeById(long companyTypeId)
        {
            if (companyTypeId == 0)
            {
                return null;
                
            }
            return _companyTypeRepository.GetById(companyTypeId);
        }
        public IList<CompanyType> GetAllCompanyType()
        {
            return _companyTypeRepository.Table.ToList<CompanyType>();
        }

       
    }
}
