using Core.CarBuyer;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CarBuyer
{
    public partial class CarBuyerInfoService : ICarBuyerInfoService
    {
        private readonly IRepository<CarBuyerInfo> _carbuyerService;
        public CarBuyerInfoService(IRepository<CarBuyerInfo> carbuyerService)
        {
            _carbuyerService = carbuyerService;
        }
        public IQueryable<CarBuyerInfo> GetAllCarBuyerQueryable()
        {
            return _carbuyerService.Table;
        }

        public IList<CarBuyerInfo> GetAllCarBuyer()
        {
            return _carbuyerService.Table.ToList();
        }

        public CarBuyerInfo GetCarBuyerInfoByID(int id)
        {
            CarBuyerInfo carbuyerinfo = GetAllCarBuyerQueryable().Where<CarBuyerInfo>(c => c.ID == id).FirstOrDefault<CarBuyerInfo>();
            return carbuyerinfo;
        }
    }
}
