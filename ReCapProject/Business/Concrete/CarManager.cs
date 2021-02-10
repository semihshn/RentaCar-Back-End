using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

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

		public List<Car> GetCarsByBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id);
		}

		public List<Car> GetCarsByColorId(int id)
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}

		public List<CarDetailDto> GetCarDetails()
		{
			return _carDal.GetCarDetails();
		}
	}
}
