using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarModelManager : ICarModelService
    {
        ICarModelDal _carModelDal;

        public CarModelManager(ICarModelDal carModelDal)
        {
            _carModelDal = carModelDal;
        }

        public List<CarModel> GetAll()
        {
            return _carModelDal.GetAll();
        }

        public CarModel GetById(int id)
        {
            return _carModelDal.Get(c=>c.Id==id);
        }
    }
}
