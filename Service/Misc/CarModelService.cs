using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Misc;
using Core.Data;
namespace Service.Misc
{
    public partial class CarModelService : ICarModelService
    {
        private readonly IRepository<CarModel> _CarModelRepository;
        public CarModelService(IRepository<CarModel> CarModelRepository)
        {
            _CarModelRepository = CarModelRepository;
        }
        public IList<CarModel> GetAllCarModels()
        {
            return _CarModelRepository.Table.ToList<CarModel>();
        }
        public void InsertCarModel(CarModel carModel)
        {
            if (carModel == null)
                throw new ArgumentNullException("carModel");
            _CarModelRepository.Insert(carModel);
        }
        public IQueryable<CarModel> GeModelsQueryable()
        {
            return _CarModelRepository.Table;
        }
        public CarModel GetCarModelByName(string CarModelName) {
            var details= _CarModelRepository.Table.Where<CarModel>(cm => cm.Modelname.ToLower()==CarModelName.ToLower()).FirstOrDefault<CarModel>();
            return details;
        }
    }
}
