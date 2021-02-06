using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public Car GetCarsByBrandId(int id)
		{
			return _carDal.Get(c => c.BrandId == id);
		}

		public Car GetCarsByColorId(int id)
		{
			return _carDal.Get(c => c.ColorId == id);
		}
	}
}
