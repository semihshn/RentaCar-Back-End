using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();
		IDataResult<List<Car>> GetCarsByBrandId(int id);
		IDataResult<List<Car>> GetCarsByColorId(int id);

		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(Car car);

		IDataResult<List<CarDetailDto>> GetCarDetails();
	}
}
