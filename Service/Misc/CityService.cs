using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;
namespace Service.Misc
{
    public partial class CountryService : ICountryService
    {
        private readonly IRepository<Country> _CountryRepository;
        public CountryService(IRepository<Country> CountryRepository)
        {
            _CountryRepository = CountryRepository;
        }
        public IList<Country> GetAllCountry()
        {
            return _CountryRepository.Table.ToList<Country>();
        }
    }
}
