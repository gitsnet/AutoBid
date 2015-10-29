using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;
namespace Service.Misc
{
    public partial class MakeService : IMakeService
    {
        private readonly IRepository<Make> _makeRepository;
        public MakeService(IRepository<Make> makeRepository)
        {
            _makeRepository = makeRepository;
        }
        public IList<Make> GetAllMakes()
        {
            return _makeRepository.Table.ToList<Make>().Where<Make>(m=>(m.Makename!=""||m.Makename!=null) && m.IsRemoved==false).GroupBy(t=>t.Makename).Select(group=>group.First()).ToList<Make>();
        }
        public IQueryable<Make> GetMakesQueryable()
        {
            return _makeRepository.Table;
        }
        public void InsertMake(Make make)
        {
            if (make == null)
                throw new ArgumentNullException("make");
            _makeRepository.Insert(make);
        }
        public Make GetMakeByName(string MakeName)
        {
            var details = _makeRepository.Table.Where<Make>(m => m.Makename.ToLower() == MakeName.ToLower() && !m.IsRemoved).FirstOrDefault<Make>();
            return details;
        }
    }
}
